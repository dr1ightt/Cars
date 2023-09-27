using Cars.Core.Domain.Enums;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cars.ViewModel
{
    public class ConfigurationViewModel
    {
        public ConfigurationViewModel() 
        {
            Configuration = new ConfigurationModel();
            SupportedDbType = Enum.GetValues(typeof(DataBaseType)).Cast<DataBaseType>().ToList();

        }
        public ConfigurationModel Configuration { get; set; }
        public  List<DataBaseType> SupportedDbType { get; set; }
        public ICommand Cancel {  get; set; }
        public ICommand Save { get; set; }
    }
}
