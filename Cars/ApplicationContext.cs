using Cars.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public static class ApplicationContext
    {
        public static AppSettings Settings;

        public static void Initialize()
        {
            InitializeSettings();
        }

        private static AppSettings InitializeSettings()
        {
            string settingsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            settingsPath = Path.Combine(settingsPath, "Garage");

            AppSettingsHelper helper = new AppSettingsHelper(settingsPath);

            return helper.GetSettings();
        }
    }
}
