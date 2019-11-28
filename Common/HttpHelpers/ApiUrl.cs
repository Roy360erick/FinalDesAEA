using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.HttpHelpers
{
    public class ApiUrl
    {

        public static string Url(int model)
        {
            string url = BaseUrl() + modelUrl(model);
            return url;
        }

        public static string BaseUrl()
        {
            string url = ConfigurationManager.AppSettings["Url"];
            string port = ConfigurationManager.AppSettings["Port"];
            string api = ConfigurationManager.AppSettings["Api"];
            string baseUrl = url + port + api;

            return baseUrl;
        }

        public static string modelUrl(int model)
        {
            string modelUrl = "";
            switch (model)
            {
                case (int)Numerable.Customer:
                    modelUrl = ConfigurationManager.AppSettings["Customer"];
                    break;
                case (int)Numerable.Product:
                    modelUrl = ConfigurationManager.AppSettings["Product"];
                    break;
                case (int)Numerable.SalesInvoice:
                    modelUrl = ConfigurationManager.AppSettings["SalesInvoice"];
                    break;
                case (int)Numerable.SalesInvoiceDetail:
                    modelUrl = ConfigurationManager.AppSettings["SalesInvoiceDetail"];
                    break;
                case (int)Numerable.Seller:
                    modelUrl = ConfigurationManager.AppSettings["Seller"];
                    break;
                default:
                    break;
            }

            return modelUrl;
        }


    }
}
