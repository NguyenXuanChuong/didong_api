using helloworld.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace helloworld.Controllers
{
    public class UserController : ApiController
    {
        // GET api/User
        public List<User> Get()
        {
            List<User> listacc = new List<User>();
            UserDAO data = new UserDAO();
            DataTable dt = data.GetAllUser();
            if (dt != null)
            {
                int dtsize = dt.Rows.Count;
                for (int i = 0; i < dtsize; i++)
                {
                    User user = new User();
                    user.Username = dt.Rows[i][0].ToString();
                    user.Password = dt.Rows[i][1].ToString();
                    user.Token = dt.Rows[i][2].ToString();
                    user.Fullname = dt.Rows[i][3].ToString();
                    user.Phone = dt.Rows[i][4].ToString();
                    user.Email = dt.Rows[i][5].ToString();
                    user.Address = dt.Rows[i][6].ToString();
                    user.Gender = dt.Rows[i][7].ToString();
                    user.Birthday = dt.Rows[i][8].ToString();
                    listacc.Add(user);
                }
                return listacc;
            }
            return null;
        }

        // GET api/User/username
        public User Get(string id)
        {
            User acc = new User();
            UserDAO data = new UserDAO();
            DataTable dt = data.GetUser(id);
            if (dt.Rows.Count > 0)
            {
                acc.Username = dt.Rows[0][0].ToString();
                acc.Password = dt.Rows[0][1].ToString();
                acc.Token = dt.Rows[0][2].ToString();
                acc.Fullname = dt.Rows[0][3].ToString();
                acc.Phone = dt.Rows[0][4].ToString();
                acc.Email = dt.Rows[0][5].ToString();
                acc.Address = dt.Rows[0][6].ToString();
                acc.Gender = dt.Rows[0][7].ToString();
                acc.Birthday = dt.Rows[0][8].ToString();
                return acc;

            }
            return null;
        }

        // POST api/User
        public bool Post([FromBody]User value)
        {
            UserDAO data = new UserDAO();
            if (data.AddUser(value))
                return true;
            return false;
        }

        // PUT api/User/5
        public bool Put(string id, [FromBody]User value)
        {
            UserDAO data = new UserDAO();
            if (data.UpdateUser(id, value))
                return true;
            return false;
        }

        // DELETE api/User/5
        public bool Delete(string id)
        {
            UserDAO data = new UserDAO();
            if (data.DeleteUser(id))
                return true;
            return false;
        }
    }
}
