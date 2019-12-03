using Common.HttpHelpers;
using Domain.Models;
using Domain.StoreProcedure;
using Models.Request;
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
        private SalesInvoceDetailService SalesInvoceDetailService = new SalesInvoceDetailService();

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

        [HttpPost]
        public JsonResult<EResponseBase<SalesInvoce>> Post(SalesInvoiceRegister_Request model)
        {
            var salesInvoice = new SalesInvoce
            {
                SalesInvoceID = 0,
                Number = model.SalesInvoice.Number,
                discount = model.SalesInvoice.Discount,
                Payed = model.SalesInvoice.Payed,
                Reason = model.SalesInvoice.Reason,
                CustomerID = model.SalesInvoice.CustomerID,
                SellerID = model.SalesInvoice.SellerID
            };
            salesInvoice.SalesInvoceDetails = model.SalesInvoceDetails.Select(x => new SalesInvoceDetail {
                Price = x.Price,
                Quantity = x.Quantity,
                ProductID = x.ProductID
            }).ToList();

            var response = SalesInvoceService.Add(salesInvoice);
            return Json(response);
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
