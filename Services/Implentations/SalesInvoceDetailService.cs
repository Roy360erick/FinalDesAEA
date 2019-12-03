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
    public class SalesInvoceDetailService : IServiceBase<SalesInvoceDetail>
    {
        public EResponseBase<SalesInvoceDetail> Get(int ID)
        {
            EResponseBase<SalesInvoceDetail> response = new EResponseBase<SalesInvoceDetail>();
            try
            {
                using (var context = new DataContext())
                {
                    response.List = context.SalesInvoceDetails.Include("Product").Include("SalesInvoce").Where(x => x.SalesInvoceID == ID).ToList();
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

        public EResponseBase<SalesInvoceDetail> GetList()
        {
            EResponseBase<SalesInvoceDetail> response = new EResponseBase<SalesInvoceDetail>();
            try
            {
                using (var context = new DataContext())
                {
                    response.List = context.SalesInvoceDetails.ToList();
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

        public EResponseBase<SalesInvoceDetail> Add(SalesInvoceDetail model)
        {
            EResponseBase<SalesInvoceDetail> response = new EResponseBase<SalesInvoceDetail>();
            try
            {
                using (var context = new DataContext())
                {
                    model.State = true;
                    context.SalesInvoceDetails.Add(model);
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

        public EResponseBase<SalesInvoceDetail> Update(SalesInvoceDetail model)
        {
            EResponseBase<SalesInvoceDetail> response = new EResponseBase<SalesInvoceDetail>();
            try
            {
                using (var context = new DataContext())
                {
                    var item = context.SalesInvoceDetails.Where(x => x.SalesInvoceDetailID == model.SalesInvoceDetailID).FirstOrDefault();
                    item.Price = model.Price;
                    item.Quantity = model.Quantity;
                    item.SalesInvoceID = model.SalesInvoceID;
                    item.ProductID = model.ProductID;
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

        public EResponseBase<SalesInvoceDetail> Delete(int ID)
        {
            EResponseBase<SalesInvoceDetail> response = new EResponseBase<SalesInvoceDetail>();
            try
            {
                using (var context = new DataContext())
                {
                    var item = context.SalesInvoceDetails.Where(x => x.SalesInvoceDetailID == ID).FirstOrDefault();
                    context.SalesInvoceDetails.Remove(item);
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
