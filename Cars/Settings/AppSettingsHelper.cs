using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cars.Settings
{
    public class AppSettingsHelper
    {
        private readonly string _configurationPath;

        public AppSettingsHelper(string configurationPath)
        {
            _configurationPath = configurationPath;
        }

        public AppSettings GetSettings()
        {
            string filename = Path.Combine(_configurationPath, "Cars.settings");

            if(File.Exists(filename) == false)
            {
                return null;
            }

            string settingRaw = File.ReadAllText(filename);

            AppSettings settings = JsonConvert.DeserializeObject<AppSettings>(settingRaw);
            return settings;
        }

        public void SaveSettings(AppSettings settings)
        {
            string settingsRaw = JsonConvert.SerializeObject(settings);
            string filename = Path.Combine(_configurationPath, "Cars.settings");

            File.WriteAllText(filename, settingsRaw);

        }
    }
}
