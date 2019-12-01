using Common.HttpHelpers;
using Domain.Models;
using Domain.StoreProcedure;
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
    public class SalesInvoceController : ApiController
    {
        private SalesInvoceService SalesInvoceService = new SalesInvoceService();

        // GET: api/SalesInvoce
        [HttpGet]
        public JsonResult<EResponseBase<SalesInvoceSP>> Get()
        {
            return Json(SalesInvoceService.GetList());
        }

        // GET: api/SalesInvoce/5
        [HttpGet]
        public JsonResult<EResponseBase<SalesInvoce>> Get(int id)
        {
            return Json(SalesInvoceService.Get(id));
        }

        // POST: api/SalesInvoce
        [HttpPost]
        public JsonResult<EResponseBase<SalesInvoce>> Post(SalesInvoce SalesInvoce)
        {
            return Json(SalesInvoceService.Add(SalesInvoce));
        }

        // PUT: api/SalesInvoce/5
        [HttpPut]
        public JsonResult<EResponseBase<SalesInvoce>> Put(SalesInvoce SalesInvoce)
        {
            return Json(SalesInvoceService.Update(SalesInvoce));
        }

        // DELETE: api/SalesInvoce/5
        [HttpDelete]
        public JsonResult<EResponseBase<SalesInvoce>> Delete(int id)
        {
            return Json(SalesInvoceService.Delete(id));
        }
    }
}
