using Common.HttpHelpers;
using Domain.Models;
using Services.Implentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace WebAPI.Controllers
{
   // [Authorize]
    public class SellerController : ApiController
    {
        private SellerService SellerService = new SellerService();

        // GET: api/Seller
        [HttpGet]
        public JsonResult<EResponseBase<Seller>> Get()
        {
            return Json(SellerService.GetList());
        }

        // GET: api/Seller/5
        [HttpGet]
        public JsonResult<EResponseBase<Seller>> Get(int id)
        {
            return Json(SellerService.Get(id));
        }

        // POST: api/Seller
        [HttpPost]
        public JsonResult<EResponseBase<Seller>> Post(Seller Seller)
        {
            return Json(SellerService.Add(Seller));
        }

        // PUT: api/Seller/5
        [HttpPut]
        public JsonResult<EResponseBase<Seller>> Put(Seller Seller)
        {
            return Json(SellerService.Update(Seller));
        }

        // DELETE: api/Seller/5
        [HttpDelete]
        public JsonResult<EResponseBase<Seller>> Delete(int id)
        {
            return Json(SellerService.Delete(id));
        }
    }
}
