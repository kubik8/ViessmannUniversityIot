using System;

namespace University.Selenium.Framework.Utilities
{
    public static class Settings
    {
        public static String[] arguments = Environment.GetCommandLineArgs();
        public static string driver { get {return arguments[0] ;}   }

        public static string baseUrl { get { return "http://google.com"; } }
        public static string mainPageUrl { get { return "http://localhost:3000/#!/login"; } }
        public static string temperaturePageUrl { get { return "http://localhost:3000/#!/temperature"; } }

        public static string ExistingUserLogin { get { return "john.doe@viessmann.com"; } }
        public static string ExistingUserPassword { get { return "ViessmannJD"; } }

        public static string NewUserLogin { get { return "test"; } }
        public static string NewUserPassword { get { return "test"; } }

        public static  string loginPageLink { get { return "/Account/LogOn"; } }

        public static TimeSpan implicitWaitTimeout { get { return TimeSpan.FromSeconds(30); } }

    }
}
