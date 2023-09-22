using System.Data;

namespace Cars.Settings
{
    public class AppSettings
    {
        public string DBHost { get; set; }
        public string DBPort { get; set; }
        public DbType DbType { get; set; }
        public string DbName { get; set; }
        public bool WindowsAuthentication { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
