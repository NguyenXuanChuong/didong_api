using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace helloworld.Models
{
    public class AccidentDAO
    {
        private DataProvider dtp = new DataProvider();
        public DataTable GetAccident(string kinhvido)
        {
            try
            {
                DataTable dt = new DataTable();
                dtp.connect();
                string[] str = kinhvido.Split(',');
                if (str.Length != 2)
                    return dt;
                SqlDataAdapter da = new SqlDataAdapter("select * from [Accident] where Latitude = " + float.Parse(str[0]) + " and Longitude = " + float.Parse(str[1]) + "", dtp.con);
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetAllAccident()
        {
            try
            {
                DataTable dt = new DataTable();
                dtp.connect();
                SqlDataAdapter da = new SqlDataAdapter("select * from [Accident]", dtp.con);
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool AddAccident(Accident accident)
        {
            try
            {
                dtp.connect();
                dtp.cmd.CommandText = "insert into [Accident] values (" + accident.Level + ", N'" + accident.Description + "', N'" + accident.Image + "', N'" + accident.Token + "', " + accident.Latitude + ", " + accident.Longitude + ", N'" + accident.Licenseplate + "', N'" + accident.Street + "', N'" + accident.TimeStart + "', N'" + accident.TimeEnd + "')";
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

        public bool DeleteAccident(string kinhvido)
        {
            try
            {
                dtp.connect();
                string[] str = kinhvido.Split(',');
                if (str.Length != 2)
                    return false;

                dtp.cmd.CommandText = "delete from [Accident] where  Latitude = " + float.Parse(str[0]) + " and Longitude = " + float.Parse(str[1]) + "";
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

        public bool UpdateAccident(string del, Accident accident)
        {
            try
            {
                dtp.connect();
                dtp.cmd.CommandText = "update [Accident] " + "set Level = " + accident.Level + " , "
                       + " Description = N'" + accident.Description + "', "
                       + " Image = N'" + accident.Image + "', "
                       + " Token = N'" + accident.Token + "', "
                       + " Licenseplate = N'" + accident.Licenseplate + "', "
                       + " Street = N'" + accident.Street + "', "
                       + " TimeStart = N'" + accident.TimeStart + "', "
                       + " TimeEnd = N'" + accident.TimeEnd + "' "
                       + " where Latitude = " + accident.Latitude + " and Longitude = " + accident.Longitude + " ";
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