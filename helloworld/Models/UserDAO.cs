using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace helloworld.Models
{
    public class UserDAO
    {
        private DataProvider dtp = new DataProvider();
        public DataTable GetUser(string username)
        {
            try
            {
                DataTable dt = new DataTable();
                dtp.connect();
                SqlDataAdapter da = new SqlDataAdapter("select * from [User] where UserName = N'" + username + "'", dtp.con);
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetAllUser()
        {
            try
            {
                DataTable dt = new DataTable();
                dtp.connect();
                SqlDataAdapter da = new SqlDataAdapter("select * from [User]", dtp.con);
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool AddUser(User user)
        {
            try
            {
                dtp.connect();
                dtp.cmd.CommandText = "insert into [User] values (N'" + user.Username + "', N'" + user.Password + "', N'" + user.Token + "', N'" + user.Fullname + "', N'" + user.Phone + "', N'" + user.Email + "', N'" + user.Address + "', N'" + user.Gender + "', N'" + user.Birthday + "')";
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

        public bool DeleteUser(string username)
        {
            try
            {
                dtp.connect();
                dtp.cmd.CommandText = "delete from [User] where  Username = N'" + username + "'";
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

        public bool UpdateUser(string username, User user)
        {
            try
            {
                dtp.connect();
                dtp.cmd.CommandText = "update [User] " + "set Password = N'" + user.Password + "' , "                       
                       + " Token = N'" + user.Token + "', "
                       + " Fullname = N'" + user.Fullname + "', "
                       + " Phone = N'" + user.Phone + "', "
                       + " Email = N'" + user.Email + "', "
                       + " Address = N'" + user.Address + "', "
                       + " Gender = N'" + user.Gender + "', "
                       + " Birthday = N'" + user.Birthday + "' "
                       + " where Username = N'" + username + "'";
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