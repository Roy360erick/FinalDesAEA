using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Common.HttpHelpers;
using Models.Request;
using Models.Response;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Web.Proxy
{
    public class LoginProxy 
    {

        public string _urlBase = ConstantsUrl.UrlBase;
        public string _endPoint = $"{ConstantsUrl.Prefix}{ConstantsUrl.Login}";
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

    }
}