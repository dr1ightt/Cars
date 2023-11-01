using Cars.Core.Domain.Enums;

namespace Cars.ViewModel
{
    public class ConfigurationModel
    {
        public bool WindowsAuthentication { get; internal set; }
        public string DbHost { get; internal set; }
        public string DbName { get; internal set; }
        public int DbPort { get; internal set; }
        public DataBaseType DbType { get; internal set; }
        public object Username { get; internal set; }
    }
}