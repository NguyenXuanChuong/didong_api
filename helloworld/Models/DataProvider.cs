using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace helloworld.Models
{
    public class DataProvider
    {
        public SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        private string dbConn = ConfigurationManager.ConnectionStrings["DbTraffic"].ToString();

        public void connect()
        {
            con.ConnectionString = dbConn;
            con.Open();
        }
    }
}