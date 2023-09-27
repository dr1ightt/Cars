using Cars.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Models
{
    public class ConfugrationModel
    {
        public string DbHost { get; set; }
        public string DbPort { get; set; }
        public DataBaseType DbType { get; set; }
        public string DbName { get; set; }
        public bool WindowsAuthentication { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
