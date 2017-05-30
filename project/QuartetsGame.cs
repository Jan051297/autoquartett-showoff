using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using Newtonsoft.Json;

namespace project
{
    struct QuartetsGameInfo
    {
        public string name;
        public string source;
    }

    struct QuartetsCard
    {
        public int index;
        public object[] propertyValues;
    }

    class QuartetsGame
    {
        public QuartetsGameInfo gameInfo;
        public QuartetsProperties.IProperty[] properties;
        public QuartetsCard[] cards;

        public QuartetsGame()
        {
            gameInfo = new QuartetsGameInfo();
            cards = null;
        }

        public bool Load(string path)
        {
            // Open File
            string json;
            try
            {
                json = File.ReadAllText(path);
            } catch {
                return false;
            }

            // Parse
            try
            {
                dynamic data = JsonConvert.DeserializeObject(json);
                
                // Game Info
                gameInfo.name = data.info.name;
                gameInfo.source = data.info.source;

                // Properties
                properties = new QuartetsProperties.IProperty[data.properties.Count];
                for (int i = 0; i < properties.Length; i++)
                {
                    var property = data.properties[i];
                    var property_name = (string)property[0];
                    var property_type = (string)property[1];

                    QuartetsProperties.PropertyResult property_winner = QuartetsProperties.PropertyResult.Disabled;
                    if(property.Count > 2)
                    {
                        var property_winner_str = (string)property[2];
                        switch(property_winner_str)
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
                    }
                }

                // Cards
                cards = new QuartetsCard[data.data.Count];
                for(int i = 0; i < cards.Length; i++)
                {
                    var card = new QuartetsCard();
                    card.index = i;
                    card.propertyValues = new object[properties.Length];

                    var card_props = data.data[i];
                    for (int p = 0; p < card_props.Count; p++)
                        card.propertyValues[p] = card_props[p];

                    cards[i] = card;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
