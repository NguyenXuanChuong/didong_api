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
    public class AccidentController : ApiController
    {
        // GET api/accident
        public List<Accident> Get()
        {
            List<Accident> listacc = new List<Accident>();
            AccidentDAO data = new AccidentDAO();
            DataTable dt = data.GetAllAccident();
            if (dt != null)
            {
                int dtsize = dt.Rows.Count;
                for (int i = 0; i < dtsize; i++)
                {
                    Accident accident = new Accident();
                    accident.Level = Int32.Parse(dt.Rows[i][0].ToString());
                    accident.Description = dt.Rows[i][1].ToString();
                    accident.Image = dt.Rows[i][2].ToString();
                    accident.Token = dt.Rows[i][3].ToString();
                    accident.Latitude = float.Parse(dt.Rows[i][4].ToString());
                    accident.Longitude = float.Parse(dt.Rows[i][5].ToString());
                    accident.Licenseplate = dt.Rows[i][6].ToString();
                    accident.Street = dt.Rows[i][7].ToString();
                    accident.TimeStart = dt.Rows[i][8].ToString();
                    accident.TimeEnd = dt.Rows[i][9].ToString();
                    listacc.Add(accident);
                }
                return listacc;
            }
            return null;
        }

        // GET api/accident/5
        public Accident Get(string id)
        {
            Accident accident = new Accident();
            AccidentDAO data = new AccidentDAO();
            DataTable dt = data.GetAccident(id);
            if (dt.Rows.Count > 0)
            {
                accident.Level = Int32.Parse(dt.Rows[0][0].ToString());
                accident.Description = dt.Rows[0][1].ToString();
                accident.Image = dt.Rows[0][2].ToString();
                accident.Token = dt.Rows[0][3].ToString();
                accident.Latitude = float.Parse(dt.Rows[0][4].ToString());
                accident.Longitude = float.Parse(dt.Rows[0][5].ToString());
                accident.Licenseplate = dt.Rows[0][6].ToString();
                accident.Street = dt.Rows[0][7].ToString();
                accident.TimeStart = dt.Rows[0][8].ToString();
                accident.TimeEnd = dt.Rows[0][9].ToString();
                return accident;

            }
            return null;
        }

        // POST api/accident
        public bool Post([FromBody]Accident value)
        {
            AccidentDAO data = new AccidentDAO();
            if (data.AddAccident(value))
                return true;
            return false;
        }

        // PUT api/accident/5
        public bool Put(string id, [FromBody]Accident value)
        {
            AccidentDAO data = new AccidentDAO();
            if (data.UpdateAccident(id, value))
                return true;
            return false;
        }

        // DELETE api/accident/5
        public bool Delete(string id)
        {
            AccidentDAO data = new AccidentDAO();
            if (data.DeleteAccident(id))
                return true;
            return false;
        }
    }
}
