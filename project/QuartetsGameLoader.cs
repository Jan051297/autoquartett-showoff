using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class InvalidQuartetsJSON : Exception
    {
        public InvalidQuartetsJSON(string error) :
            base("InvalidQuartetsJSON: " + error)
        {
        }
    }

    public class QuartetsGameLoader
    {
        public static string BasePath = "../../../data/";

        private struct QuartetsJSON
        {
            public QuartetsGameInfo info;
            public string[][] properties;
            public object[][] cards;
        }

        public QuartetsGameData Load(string name, bool extensive = true)
        {
            QuartetsJSON json = ReadFromFile(BasePath + name + ".json");

            // Setup Game Data
            QuartetsGameData gameData = new QuartetsGameData();
            gameData.info = json.info;

            gameData.info.path = BasePath;
            gameData.info.filename = name;

            if (gameData.info.imagePath == null)
                gameData.info.imagePath = name + "/";

            // Deserialize Data beyond info
            if (extensive)
            {
                // Properties
                int propertyNameIndex = DeserializeProperties(ref json, gameData);

                // Cards
                DeserializeCards(ref json, gameData, propertyNameIndex);
            }

            // Amount Cards
            gameData.info.amountCards = json.cards.Length;

            // Done!
            return gameData;
        }

        private QuartetsGameInfo[] discoveredGames = null;
        public void DiscoverGames()
        {
            // Find .json
            var files = Directory.GetFiles(BasePath,
                "*.json",
                SearchOption.TopDirectoryOnly);
            
            discoveredGames = new QuartetsGameInfo[files.Length];

            // Parse
            for (int index = 0; index < discoveredGames.Length; index++)
            {
                string path = files[index];
                string name = path.ToLower().Remove(0, BasePath.Length).Replace(".json", "");

                // Parse
                try
                {
                    discoveredGames[index] = Load(name, false).info;
                }
                catch(Exception e)
                {
                    // Error "Info"
                    QuartetsGameInfo info = new QuartetsGameInfo();
                    info.name = name +" [Invalid]";
                    info.source = "Error loading JSON:\n" + e.Message;

                    discoveredGames[index] = info;
                }
            }
        }

        public QuartetsGameInfo[] GetDiscoveredGames()
        {
            return discoveredGames;
        }

        private QuartetsJSON ReadFromFile(string path)
        {
            // Read File
            string json;
            try
            {
                json = File.ReadAllText(path);
            }
            catch
            {
                throw new InvalidQuartetsJSON("Failed to open File " + path);
            }

            // Deserialize JSON
            try
            {
                return JsonConvert.DeserializeObject<QuartetsJSON>(json);
            }
            catch (Exception e)
            {
                throw new InvalidQuartetsJSON("Failed to parse JSON: " + e.Message);
            }
        }

        // Read all properties from JSON
        // Returns: index of the Name attribute
        private int DeserializeProperties(ref QuartetsJSON json, QuartetsGameData gameData)
        {
            var propertiesData = json.properties;

            // Properties
            // Name Property is not stored
            int property_index_name = -1;
            gameData.properties = new QuartetsProperties.IProperty[propertiesData.Length - 1];

            // Deserialize
            for(int index = 0, propertyIndex = 0; index < propertiesData.Length; index++)
            {
                var propertyData = propertiesData[index];

                // Check amount of arguments
                // name, type[, winner-result]
                if (propertyData.Length < 2)
                    throw new InvalidQuartetsJSON("Invalid Property (index " + index + "), not enough arguments");
                if (propertyData.Length > 3)
                    throw new InvalidQuartetsJSON("Invalid Property (index " + index + ", name " + propertyData[0].ToString() + "), too many arguments");

                // Property Result
                QuartetsProperties.PropertyResult desiredResult = QuartetsProperties.PropertyResult.Disabled;

                if (propertyData.Length == 3)
                    desiredResult = DeserializePropertyResult(propertyData[2]);

                // Property Type
                QuartetsProperties.IProperty property = DeserializeProperty(propertyData[0], propertyData[1], desiredResult);
                if (property.GetType() == typeof(QuartetsProperties.NameProperty))
                {
                    property_index_name = index;
                    continue;
                }

                // Store Property
                gameData.properties[propertyIndex] = property;
                propertyIndex++;
            }

            // Require Name Property
            if (property_index_name < 0)
                throw new InvalidQuartetsJSON("Missing 'name' property!");

            return property_index_name;
        }

        private QuartetsProperties.PropertyResult DeserializePropertyResult(string result)
        {
            switch(result.ToLower())
            {
                case "higher":
                    return QuartetsProperties.PropertyResult.Higher;

                case "lower":
                    return QuartetsProperties.PropertyResult.Lower;

                default:
                    return QuartetsProperties.PropertyResult.Invalid;
            }
        }

        private QuartetsProperties.IProperty DeserializeProperty(string name, string strtype, QuartetsProperties.PropertyResult desiredResult)
        {
            switch(strtype.ToLower())
            {
                case "integer":
                    return new QuartetsProperties.IntegerProperty(desiredResult, name);

                case "string":
                    return new QuartetsProperties.StringProperty(name);

                case "name":
                    return new QuartetsProperties.NameProperty();

                default:
                    throw new InvalidQuartetsJSON("Unrecognized Property '" + name + "'");
            }
        }

        private void DeserializeCards(ref QuartetsJSON json, QuartetsGameData gameData, int namePropertyIndex)
        {
            // Check amount of Cards
            // At least 1 required
            var cardsData = json.cards;
            if (cardsData.Length == 0)
                throw new InvalidQuartetsJSON("No cards were found!");

            // Cards
            QuartetsCard[] cards = new QuartetsCard[json.cards.Length];
            for(int index = 0; index < cards.Length; index++)
            {
                // Check amount of Properties
                var cardData = cardsData[index];
                if (cardData.Length < gameData.properties.Length)
                    throw new InvalidQuartetsJSON("Card at index " + index + " only has " + cardData.Length + " properties (required " + gameData.properties.Length + ")");

                // Card
                var card = new QuartetsCard();
                card.name = cardData[namePropertyIndex].ToString();

                // Card Properties
                // -1 >= propertyValues does not store name, since it's
                // stored in QuartetsCard.name already
                card.propertyValues = new object[cardData.Length - 1];

                for(int dataIndex = 0, propertyIndex = 0; dataIndex < cardData.Length; dataIndex++)
                {
                    if (dataIndex == namePropertyIndex)
                        continue;

                    // Check/Convert Property Value
                    var property = gameData.properties[propertyIndex];
                    var value = property.CheckValueType(cardData[dataIndex]);

                    card.propertyValues[propertyIndex] = value ??
                        throw new InvalidQuartetsJSON("Card " + dataIndex + ": Invalid value type for property '" + property.GetName() + "': " + cardData[dataIndex].ToString());

                    propertyIndex++;
                }

                // Image
                try
                {
                    var path = gameData.info.path + "/" + gameData.info.imagePath + "/" +
                        card.name + "." + gameData.info.imageFileExtension;
                    card.image = Image.FromFile(path);
                } catch {
                    // Image is not required, so just ignore Exception
                }

                // Store
                card.gameData = gameData;
                cards[index] = card;
            }

            // Done
            gameData.cards = cards;
        }
    }
}
