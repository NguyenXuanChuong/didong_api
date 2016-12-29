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
    public class ResponseController : ApiController
    {
        // GET api/response
        public List<Response> Get()
        {
            List<Response> listres = new List<Response>();
            ResponseDAO data = new ResponseDAO();
            DataTable dt = data.GetAllResponse();
            if (dt != null)
            {
                int dtsize = dt.Rows.Count;
                for (int i = 0; i < dtsize; i++)
                {
                    Response response = new Response();
                    response.Token = dt.Rows[i][0].ToString();
                    response.Latitude = float.Parse(dt.Rows[i][1].ToString());
                    response.Longitude = float.Parse(dt.Rows[i][2].ToString());
                    response.IsAgree = Int32.Parse(dt.Rows[i][3].ToString());
                    listres.Add(response);
                }
                return listres;
            }
            return null;
        }

        // GET api/response/5
        public Response Get(string id)
        {
            ResponseDAO data = new ResponseDAO();
            DataTable dt = data.GetResponse(id);
            if (dt.Rows.Count > 0)
            {
                Response response = new Response();
                response.Token = dt.Rows[0][0].ToString();
                response.Latitude = float.Parse(dt.Rows[0][1].ToString());
                response.Longitude = float.Parse(dt.Rows[0][2].ToString());
                response.IsAgree = Int32.Parse(dt.Rows[0][3].ToString());
                return response;

            }
            return null;
        }

        // POST api/response
        public bool Post([FromBody]Response value)
        {
            ResponseDAO data = new ResponseDAO();
            if (data.AddResponse(value))
                return true;
            return false;
        }

        // PUT api/response/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/response/5
        public bool Delete(string id)
        {
            ResponseDAO data = new ResponseDAO();
            if (data.DeleteResponse(id))
                return true;
            return false;
        }
    }
}
