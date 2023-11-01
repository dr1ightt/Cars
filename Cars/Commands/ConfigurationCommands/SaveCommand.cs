using Cars.Settings;
using Cars.ViewModel;
using Cars.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cars.Commands.ConfigurationCommands
{
    public class SaveCommand : ICommand
    {
        private readonly ConfigurationViewModel _viewModel;

        public SaveCommand(ConfigurationViewModel viewModel)
        {
            _viewModel = viewModel ?? throw new ArgumentException(nameof(viewModel));
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            AppSettingsHelper helper = new AppSettingsHelper(ApplicationContext.ConfigurationPath);
            ConfigurationModel config = _viewModel.Configuration;
            PasswordBox passwordBox = (PasswordBox)parameter;

            AppSettings appSettings = new AppSettings
            {
                WindowsAuthentication = config.WindowsAuthentication,
                DbHost = config.DbHost,
                DbName = config.DbName,
                DbPort = (int)config.DbPort,
                DbType = (Core.Domain.Enums.DataBaseType)config.DbType
            };

            if(config.WindowsAuthentication == false)
            {
                appSettings.Username = config.Username;
                appSettings.Password = passwordBox.Password;
            }

            helper.SaveSettings(appSettings);

            WindowsStart startWindow = new WindowsStart();
            startWindow.Show();
            _viewModel.Window.Close();
        }
    }
}
