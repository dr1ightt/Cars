using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cars.Views
{
    /// <summary>
    /// Interaction logic for WindowsStart.xaml
    /// </summary>
    public partial class WindowsStart : Window
    {
        public WindowsStart()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            CheckServer();

        }

        public async void CheckServer()
        {
            await Task.Delay(3_000);

            if(ApplicationContext.DB.IsOnline())
            {
                LoginWindow window = new LoginWindow();

                window.Show();
                this.Close();
                return;
            }

            ConfigurationWindow configuration = new ConfigurationWindow();
        }
        
    }
}
