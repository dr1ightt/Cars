using Cars.Core.DataAccessLayer;
using Cars.Core.DataAccessLayer.SqlServer;
using Cars.Core.Domain.Repositories;
using Cars.Settings;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Factories
{
    public static class DbFactories
    {
        public static IUnitOfWork Get(AppSettings appSettings)
        {
            switch (appSettings.DbType)
            {
                case Core.Domain.Enums.DataBaseType.SqlServer:
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    builder.InitialCatalog = appSettings.DbName;
                    builder.DataSource = appSettings.DbHost;
                    builder.IntegratedSecurity = appSettings.WindowsAuthentication;
                    builder.TrustServerCertificate = true;

                    if (appSettings.WindowsAuthentication == false)
                    {
                    builder.UserID = appSettings.UserName;
                    builder.Password = appSettings.Password;
                    }

                    string connectionstring = builder.ToString();

                    return new SqlUnitOfWork(connectionstring);
                    break;

                case Core.Domain.Enums.DataBaseType.MySql:
                    return new EmptyUnitOfWork();
                case Core.Domain.Enums.DataBaseType.InMemory:
                    return new EmptyUnitOfWork();
                default:
                    throw new NotSupportedException($"{appSettings.DbType} not supported");
            }

         
        }
    }
}
