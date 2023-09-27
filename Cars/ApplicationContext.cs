using Cars.Core.Domain.Repositories;
using Cars.Factories;
using Cars.Settings;
using Microsoft.Data.SqlClient;
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
        public static AppSettings Settings { get; private set; }
        public static IUnitOfWork DB { get; private set; }

        public static void Initialize()
        {
            Settings = InitializeSettings();
            DB = DbFactories.Get(Settings);
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
