using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Web.Http;

namespace WindowsService_HostAPI
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        public String GetString(Int32 id)
        {
            return "This is string returned through the Windows service.";
        }

        [HttpPost]
        public object PostData([FromBody] object data)
        {
            using (var client = new HttpClient())
            {
                var json = new JObject();
                json.Add("id", "Luna");
                json.Add("name", "Silver");
                json.Add("age", 19);
                //Postman에서
                //http://localhost:8080/Values/PostData/3
                // {
                //        "productId":"second",
                //        "qty":2,
                //        "unitPrice":2
                //    }
                client.BaseAddress = new Uri("http://localhost:3000");
                var response = client.PostAsJsonAsync("api/products", json).Result;
            }

            return data;
        }
        // http://localhost:8080/Values/PostData/3
    }
}