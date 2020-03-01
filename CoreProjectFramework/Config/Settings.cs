using AutoFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFramework.Config
{
    public class Settings
    {
        public static string TestType { get; set;}
        public static string AUT { get; set; }
        //public static string Build { get; set; }
        public static BrowserType BrowserType { get; set; }

        public static string BrowserUsed { get; set; }

        public static string Exetype { get; set; }

        //public static string IsLog { get; set; }
        //public static string LogPath { get; set; }
    }
}
