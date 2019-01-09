using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruVoyageDataAccessLayer
{
    static class DBConnection
    {
        internal static SqlConnection GetConnection()
        {
            var connString = @"Data Source=localhost;Initial Catalog=TruVoyageDB;Integrated Security=True";
            var conn = new SqlConnection(connString);
            return conn;
        }
    }
}
