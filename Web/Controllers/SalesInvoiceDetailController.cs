﻿using Models.Request;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.Proxy;

namespace Web.Controllers
{
    public class SalesInvoiceDetailController : Controller
    {
        SalesInvoiceDetailProxy proxy = new SalesInvoiceDetailProxy();

        // GET: SalesInvoiceDetail
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var response = Task.Run(() => proxy.GetAll());
            return Json(response.Result.List, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            var response = Task.Run(() => proxy.Get(id));
            return Json(response.Result.Object, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(SalesInvoceDetail_Request model)
        {
            var response = Task.Run(() => proxy.Add(model));
            string message = response.Result.Message;
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpPut]
        public ActionResult Update(SalesInvoceDetail_Request model)
        {
            var response = Task.Run(() => proxy.Update(model));
            string message = response.Result.Message;
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var response = Task.Run(() => proxy.Delete(id));
            string message = response.Result.Message;
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
    }
}