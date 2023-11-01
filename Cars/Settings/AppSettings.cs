using Cars.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Settings
{
    public class AppSettings
    {
        public string DbHost { get; set; }
        public int DbPort { get; set; }
        public DataBaseType DbType { get; set; }
        public string DbName { get; set; }
        public bool WindowsAuthentication {  get; set; }
        public string UserName { get; set; }
        public object Username { get; internal set; }
        public string Password { get; set; }
    }
}
