using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitProject.Controller
{
    public class DB_Controller
    {
        public static string connectionString = "Data Source=localhost;Initial Catalog=GitDatabase;User ID=sa;Password=123";

        public static SqlConnection GetGlobalConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
