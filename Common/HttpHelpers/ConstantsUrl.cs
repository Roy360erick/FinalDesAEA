using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.HttpHelpers
{
    public static class ConstantsUrl
    {
        public static string UrlBase = ConfigurationManager.AppSettings["UrlBase"];
        public static string Prefix = ConfigurationManager.AppSettings["Prefix"];
        public static string Login = ConfigurationManager.AppSettings["Login"];
        public static string Customer = ConfigurationManager.AppSettings["Customer"];
        public static string Product = ConfigurationManager.AppSettings["Product"];
        public static string Seller = ConfigurationManager.AppSettings["Seller"];
        public static string SalesInvoice = ConfigurationManager.AppSettings["SalesInvoice"];
        public static string SalesInvoiceDetail = ConfigurationManager.AppSettings["SalesInvoiceDetail"];
    }
}
