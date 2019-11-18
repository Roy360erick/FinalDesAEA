using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Proxy;

namespace Web.Controllers
{
    public class CustomerController : Controller
    {
        CustomerProxy proxy = new CustomerProxy();

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Get()
        {
            var response = Task.Run(() => proxy.Get());
            return Json(response.Result.List, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(CustomerModel customer)
        {
            var response = Task.Run(() => proxy.Add(customer));
            //string message = response.Result.Message;
            return Json(new { Message = "Success", JsonRequestBehavior.AllowGet });
        }
    }
}