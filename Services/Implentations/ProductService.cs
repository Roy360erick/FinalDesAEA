using Common.HttpHelpers;
using Domain.Models;
using Infraestructure.Context;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implentations
{
    public class ProductService : IServiceBase<Product>
    {

        public EResponseBase<Product> Get(int ID)
        {
            EResponseBase<Product> response = new EResponseBase<Product>();
            try
            {
                using (var context = new DataContext())
                {
                    response.Object = context.Products.Where(x => x.ProductID == ID && x.State == true).FirstOrDefault();
                }
                response.IsSuccess = true;
                response.Message = "Success";
                return response;
            }
            catch (Exception ex )
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                return response;
            }
        }

        public EResponseBase<Product> GetList()
        {
            EResponseBase<Product> response = new EResponseBase<Product>();
            try
            {
                using (var context = new DataContext())
                {
                    response.List = context.Products.Where(x => x.State == true).ToList();
                }
                response.IsSuccess = true;
                response.Message = "Success";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                return response;
            }
        }
    
        public EResponseBase<Product> Add(Product model)
        {
            EResponseBase<Product> response = new EResponseBase<Product>();
            try
            {
                using (var context = new DataContext())
                {
                    model.CreateAt = DateTime.Now;
                    model.State = true;
                    context.Products.Add(model);
                    context.SaveChanges();
                }
                response.IsSuccess = true;
                response.Message = "Success";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                return response;
            }
        }

        public EResponseBase<Product> Update(Product model)
        {
            EResponseBase<Product> response = new EResponseBase<Product>();
            try
            {
                using (var context = new DataContext())
                {
                    var item = context.Products.Where(x => x.ProductID == model.ProductID).FirstOrDefault();
                    item.Name = model.Name;
                    item.Stock = model.Stock;
                    item.Price = model.Price;
                    item.Remarks = model.Remarks;
                    context.SaveChanges();
                }
                response.IsSuccess = true;
                response.Message = "Success";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                return response;
            }
        }

        public EResponseBase<Product> Delete(int ID)
        {
            EResponseBase<Product> response = new EResponseBase<Product>();
            try
            {
                using (var context = new DataContext())
                {
                    var item = context.Products.Where(x => x.ProductID == ID).FirstOrDefault();
                    item.State = false;
                    context.SaveChanges();
                }
                response.IsSuccess = true;
                response.Message = "Success";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                return response;
            }
        }

    }
}
