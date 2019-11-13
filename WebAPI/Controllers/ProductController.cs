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
    public class ProductController : ApiController
    {
        private ProductService productService = new ProductService();

        // GET: api/Product
        [HttpGet]
        public JsonResult<EResponseBase<Product>> Get()
        {
            return Json(productService.GetList());
        }

        // GET: api/Product/5
        [HttpGet]
        public JsonResult<EResponseBase<Product>> Get(int id)
        {
            return Json(productService.Get(id));
        }

        // POST: api/Product
        [HttpPost]
        public JsonResult<EResponseBase<Product>> Post(Product Product)
        {
            return Json(productService.Add(Product));
        }

        // PUT: api/Product/5
        [HttpPut]
        public JsonResult<EResponseBase<Product>> Put(Product Product)
        {
            return Json(productService.Add(Product));
        }

        // DELETE: api/Product/5
        [HttpDelete]
        public JsonResult<EResponseBase<Product>> Delete(int id)
        {
            return Json(productService.Delete(id));
        }
    }
}
