using Cars.Commands.ConfigurationCommands;
using Cars.Core.Domain.Enums;
using Cars.Settings;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Cars.ViewModel
{
    public class ConfigurationViewModel : BaseWindowViewModel
    {
        public ConfigurationViewModel(Window window) : base(window)
        {
            this.Window = window;

            AppSettings currentSettings = ApplicationContext.Settings;
            Configuration = new ConfigurationModel
            {
                WindowsAuthentication = currentSettings.WindowsAuthentication,
                DbHost = currentSettings.DbHost,
                DbName = currentSettings.DbName,
                DbPort = currentSettings.DbPort,
                Username = currentSettings.Username,
            };
            SupportedDbType = Enum.GetValues(typeof(DataBaseType)).Cast<DataBaseType>().ToList();

            Save = new SaveCommand(this);

        }
        public ConfigurationModel Configuration { get; set; }
        public  List<DataBaseType> SupportedDbType { get; set; }
        public Window Window { get; set; }
        public ICommand Cancel {  get; set; }
        public ICommand Save { get; set; }
    }
}
