using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Collections.Specialized;

namespace MazeFramework.Engine
{
    class ConfigSettings
    {
        public static int iResWidth  = 400;
        public static int iResHeight  = 224;
        public static int maxRoomWidth  = 20;
        public static int minRoomWidth = 5;
        public static int maxRoomHeight = 20;
        public static int minRoomHeight = 5;

        public static int roomCount = 25;

        public static int seed = 301095;

        //public static int enemiePlacement { get; } = 50;



        public static void loadConfig()
        {
            loadFromConfig(ref roomCount, "roomCount");
            loadFromConfig(ref iResWidth, "iResWidth");
            loadFromConfig(ref iResHeight, "iResHeight");
            loadFromConfig(ref maxRoomWidth, "maxRoomWidth");
            loadFromConfig(ref minRoomWidth, "minRoomWidth");
            loadFromConfig(ref maxRoomHeight, "maxRoomHeight");
            loadFromConfig(ref minRoomHeight, "minRoomHeight");




        }

        private static void loadFromConfig(ref int i, string s)
        {
            
            try
            {
                i = getConfigValue(s);
                Console.WriteLine(i);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error getting setting from config : {e.Message}");
                Console.WriteLine($"Keeping at default value : {roomCount}");
            }

            
        }

        private static int getConfigValue(string key)
        {
            string s = ConfigurationManager.AppSettings.Get(key);
            return int.Parse(s);
        }

        public static void saveConfig()
        {

        }




    }
}
