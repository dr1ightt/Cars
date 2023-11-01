using Cars.Core.Domain.Enums;
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
        private static AppSettings _defaultSettings = new AppSettings()
        {
            DbHost = "localhost",
            DbName = "master",
            DbPort = 1433,
            DbType = DataBaseType.SqlServer,
            UserName = "",
            Password = "",
            WindowsAuthentication = true
        };
        public static string ConfigurationPath
        {
            get
            {
                string settingsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                settingsPath = Path.Combine(settingsPath, "Cars");

                if (Directory.Exists(settingsPath) == false)
                {
                    Directory.CreateDirectory(settingsPath);
                }

                return settingsPath;
            }
        }


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

            AppSettings appSettings = helper.GetSettings();

            if(appSettings is null)
            {
                appSettings = _defaultSettings;
            }
            return appSettings;
        }
    }
}
