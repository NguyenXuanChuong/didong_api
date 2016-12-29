using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace helloworld.Models
{
    public class ResponseDAO
    {
        private DataProvider dtp = new DataProvider();
        public DataTable GetResponse(string token)
        {
            try
            {
                DataTable dt = new DataTable();
                dtp.connect();
                SqlDataAdapter da = new SqlDataAdapter("select * from [Response] where Token = N'" + token + "'", dtp.con);
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetAllResponse()
        {
            try
            {
                DataTable dt = new DataTable();
                dtp.connect();
                SqlDataAdapter da = new SqlDataAdapter("select * from [Response]", dtp.con);
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool AddResponse(Response response)
        {
            try
            {
                dtp.connect();
                dtp.cmd.CommandText = "insert into [Response] values (N'" + response.Token + "', " + response.Latitude + ", " + response.Longitude + ", " + response.IsAgree + ")";
                dtp.cmd.Connection = dtp.con;
                dtp.cmd.ExecuteNonQuery();
                dtp.con.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteResponse(string token)
        {
            try
            {
                dtp.connect();
                dtp.cmd.CommandText = "delete from [Response] where Token = N'" + token + "'";
                dtp.cmd.Connection = dtp.con;
                dtp.cmd.ExecuteNonQuery();
                dtp.con.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}