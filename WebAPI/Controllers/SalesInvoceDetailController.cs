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
    public class SalesInvoceDetailController : ApiController
    {
        private SalesInvoceDetailService SalesInvoceDetailService = new SalesInvoceDetailService();

        // GET: api/SalesInvoceDetail
        [HttpGet]
        public JsonResult<EResponseBase<SalesInvoceDetail>> Get()
        {
            return Json(SalesInvoceDetailService.GetList());
        }

        // GET: api/SalesInvoceDetail/5
        [HttpGet]
        public JsonResult<EResponseBase<SalesInvoceDetail>> Get(int id)
        {
            return Json(SalesInvoceDetailService.Get(id));
        }

        // POST: api/SalesInvoceDetail
        [HttpPost]
        public JsonResult<EResponseBase<SalesInvoceDetail>> Post(SalesInvoceDetail SalesInvoceDetail)
        {
            return Json(SalesInvoceDetailService.Add(SalesInvoceDetail));
        }

        // PUT: api/SalesInvoceDetail/5
        [HttpPut]
        public JsonResult<EResponseBase<SalesInvoceDetail>> Put(SalesInvoceDetail SalesInvoceDetail)
        {
            return Json(SalesInvoceDetailService.Update(SalesInvoceDetail));
        }

        // DELETE: api/SalesInvoceDetail/5
        [HttpDelete]
        public JsonResult<EResponseBase<SalesInvoceDetail>> Delete(int id)
        {
            return Json(SalesInvoceDetailService.Delete(id));
        }
    }
}
