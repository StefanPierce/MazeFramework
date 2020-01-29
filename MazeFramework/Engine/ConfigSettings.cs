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
        public static int iResWidth { get; } = 400;
        public static int iResHeight { get; } = 224;
        public static int maxRoomWidth { get; } = 20;
        public static int minRoomWidth { get; } = 5;
        public static int maxRoomHeight { get;} = 20;
        public static int minRoomHeight { get;} = 5;

        public static int roomCount { get; } = 25;

        public static int enemiePlacement { get; } = 50;



        public static void loadConfig()
        {
            string s = ConfigurationManager.AppSettings.Get("roomCount");
            Console.WriteLine(s);
        }

        public static void saveConfig()
        {

        }




    }
}
