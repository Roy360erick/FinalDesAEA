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
    //[Authorize]
    public class CustomerController : ApiController
    {
        private CustomerService CustomerService = new CustomerService();

        // GET: api/Customer
        [HttpGet]
        public JsonResult<EResponseBase<Customer>> Get()
        {
            return Json(CustomerService.GetList());
        }

        // GET: api/Customer/5
        [HttpGet]
        public JsonResult<EResponseBase<Customer>> Get(int id)
        {
            return Json(CustomerService.Get(id));
        }

        // POST: api/Customer
        [HttpPost]
        public JsonResult<EResponseBase<Customer>> Post(Customer Customer)
        {
            return Json(CustomerService.Add(Customer));
        }

        // PUT: api/Customer/5
        [HttpPut]
        public JsonResult<EResponseBase<Customer>> Put(Customer Customer)
        {
            return Json(CustomerService.Update(Customer));
        }

        // DELETE: api/Customer/5
        [HttpDelete]
        public JsonResult<EResponseBase<Customer>> Delete(int id)
        {
            return Json(CustomerService.Delete(id));
        }
    }
}
