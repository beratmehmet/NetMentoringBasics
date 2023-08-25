using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONETLibrary
{
    public static class DBConfig
    {
        public static string ConnectionString { get; set; } = "Server=BMT\\MSSQLSERVER01;Database=ADONETDB;Trusted_Connection=True;TrustServerCertificate=True;";
    }

}
