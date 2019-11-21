using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ApiUrlHelpers
{
    public class ApiUrl
    {
        public static string BaseUrl()
        {
            string url = ConfigurationManager.AppSettings["Url"];
            string port = ConfigurationManager.AppSettings["Port"];
            string baseUrl = url + port;

            return baseUrl;
        }

        public string aiuda()
        {
            return "asd";
        }
    }
}
