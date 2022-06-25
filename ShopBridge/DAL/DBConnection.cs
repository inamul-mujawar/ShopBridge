using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopBridge.DAL
{
    public class DBConnection
    {
        protected SqlConnection con = null;

        public DBConnection()
        {
            string query = ConfigurationManager.ConnectionStrings["SQLServerConnection"].ToString();
            con = new SqlConnection(query);
        }
    }
}