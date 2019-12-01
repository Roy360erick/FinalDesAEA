﻿using Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.Proxy;

namespace Web.Controllers
{
    public class SellerController : Controller
    {
        SellerProxy proxy = new SellerProxy();
        // GET: Seller
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
        public ActionResult Add(Seller_Request model)
        {
            if (model.SellerID == 0)
            {
                var response = Task.Run(() => proxy.Add(model));
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var response = Task.Run(() => proxy.Update(model));
                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            var response = Task.Run(() => proxy.Delete(id));
            string message = response.Result.Message;
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
    }
}