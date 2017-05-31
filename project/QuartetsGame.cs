using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using Newtonsoft.Json;
using System.Drawing;

namespace project
{
    public struct QuartetsGameInfo
    {
        public string name;
        public string source;
        public int amountCards;
    }

    public struct QuartetsCard
    {
        public QuartetsGame game;
        public int index;
        public string name;
        public Image image;
        public object[] propertyValues;

        public QuartetsCard(QuartetsGame g)
        {
            game = g;
            name = "[QuartetsCard:Invalid]";
            index = -1;
            image = null;
            propertyValues = null;
        }

        public bool IsValid()
        {
            return game != null &&
                index > -1 &&
                propertyValues != null;
        }
    }

    public class InvalidQuartetsJSON : Exception
    {
        public InvalidQuartetsJSON(string error) : 
            base("Invalid JSON: " + error)
        {
        }
    }

    public class QuartetsGame
    {
        public static string BasePath = "../../../data/";

        public QuartetsGameInfo gameInfo;
        public QuartetsProperties.IProperty[] properties = null;
        public QuartetsCard[] cards = null;

        static public QuartetsGameInfo[] DiscoverGames()
        {
            // Find .json
            var files = Directory.GetFiles(BasePath, "*.json", SearchOption.TopDirectoryOnly);
            QuartetsGameInfo[] games = new QuartetsGameInfo[files.Length];

            // Parse
            for(int index = 0; index < games.Length; index++)
            {
                string path = files[index];
                string name = path.ToLower().Remove(0, BasePath.Length).Replace(".json", "");

                // Game Info
                QuartetsGameInfo info;
                info.name = name;
                info.source = "?";
                info.amountCards = 0;

                // Parse
                try
                {
                    dynamic data = JsonConvert.DeserializeObject(File.ReadAllText(path));
                    info.name = data.info.name;
                    info.source = data.info.source;
                    info.amountCards = data.cards.Count;
                } catch {
                    info.name += "[Invalid]";
                    info.source = "Error loading JSON!";
                }

                games[index] = info;
            }

            return games;
        }

        public QuartetsGame()
        {
            gameInfo = new QuartetsGameInfo();
        }

        public bool Load(string path)
        {
            // Open JSON File
            string json;
            try
            {
                json = File.ReadAllText(BasePath + path + ".json");
            } catch {
                throw new InvalidQuartetsJSON("Failed to open File " + path);
            }

            // Parse
            dynamic data = null;
            try
            {
                data = JsonConvert.DeserializeObject(json);
            } catch {
                throw new InvalidQuartetsJSON("Failed to parse JSON!");
            }

            // Game Info
            try
            {
                gameInfo.name = data.info.name;
                gameInfo.source = data.info.source;
            } catch {
                throw new InvalidQuartetsJSON("JSON does not contain valid Info");
            }

            // Properties
            int card_name_index = -1; // Property Index of (required) Name attribute

            properties = new QuartetsProperties.IProperty[data.properties.Count];
            for (int i = 0; i < properties.Length; i++)
            {
                var property = data.properties[i];
                var property_name = (string)property[0];
                var property_type = (string)property[1];

                QuartetsProperties.PropertyResult property_winner = QuartetsProperties.PropertyResult.Disabled;
                if(property.Count > 2)
                {
                    switch((string)property[2])
                    {
                        case "higher":
                            property_winner = QuartetsProperties.PropertyResult.Higher;
                            break;
                        case "lower":
                            property_winner = QuartetsProperties.PropertyResult.Lower;
                            break;
                    }
                }

                switch (property_type)
                {
                    case "integer":
                        properties[i] = new QuartetsProperties.IntegerProperty(property_winner, property_name);
                        break;
                    case "string":
                        properties[i] = new QuartetsProperties.StringProperty(property_name);
                        break;
                    case "name":
                        properties[i] = new QuartetsProperties.NameProperty();
                        card_name_index = i;
                        break;
                }
            }

            // Name
            // Every card requires a Name property!
            if (card_name_index == -1)
                throw new InvalidQuartetsJSON("No name property found!");

            // Cards
            cards = new QuartetsCard[data.cards.Count];
            gameInfo.amountCards = cards.Length;

            for(int i = 0; i < cards.Length; i++)
            {
                var card = new QuartetsCard(this);
                card.index = i;

                // Properties
                card.propertyValues = new object[properties.Length];

                var card_props = data.cards[i];
                for (int p = 0; p < card_props.Count; p++)
                    card.propertyValues[p] = card_props[p];

                card.name = (string)card_props[card_name_index];

                // Image
                try
                {
                    card.image = Image.FromFile(BasePath + path + "/" + card.name + ".jpg");
                } catch {
                    // Thats not so bad, i guess..
                }

                // Store
                cards[i] = card;
            }

            // Done
            return true;
        }
    }
}
