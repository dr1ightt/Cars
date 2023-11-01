using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cars.ViewModel
{
    public class BaseWindowViewModel
    {
        public BaseWindowViewModel(Window window)
        {
            Window = window ?? throw new ArgumentNullException(nameof(window));
        }

        public Window Window { get; set; }
    }
}
