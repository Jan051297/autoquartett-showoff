using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

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
                dynamic data = JsonConvert.DeserializeObject(json);
                // Game Info
                
                var info = new QuartetsGameInfo();
                info.name = data.info.name;
                info.source = data.info.source;
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
