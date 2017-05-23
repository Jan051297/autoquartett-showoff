using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Json;

namespace project
{
    struct QuartetsGameInfo
    {
        public string name;
        public string source;
    }

    class QuartetsGame
    {
        public QuartetsGameInfo gameInfo;

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
                var data = JsonParser.Deserialize(json);

                // Game Info
                /*
                gameData.info = new QuartetsGameInfo();
                gameData.info.name = data.info.name;
                gameData.info.source = data.info.source;*/
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
