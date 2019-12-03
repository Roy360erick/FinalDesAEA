using Common.HttpHelpers;
using Domain.Models;
using Domain.StoreProcedure;
using Infraestructure.Context;
using Services.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Services.Implentations
{
    public class SalesInvoceService : IServiceBase<SalesInvoce>
    {
        public EResponseBase<SalesInvoce> Get(int ID)
        {
            EResponseBase<SalesInvoce> response = new EResponseBase<SalesInvoce>();
            try
            {
                using (var context = new DataContext())
                {
                    response.Object = context.SalesInvoces
                        .Include("Customer")
                        .Include("Seller")
                        .Include("SalesInvoceDetails.Product")
                        .Where(x => x.SalesInvoceID == ID && x.State == true).FirstOrDefault();
                   
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

        public EResponseBase<SalesInvoceSP> GetList()
        {
            EResponseBase<SalesInvoceSP> response = new EResponseBase<SalesInvoceSP>();
            try
            {
                
                using (var context = new DataContext())
                {
                    response.List = context.Database.SqlQuery<SalesInvoceSP>("pa_listSales").ToList();
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

        public EResponseBase<SalesInvoce> Add(SalesInvoce model)
        {
            EResponseBase<SalesInvoce> response = new EResponseBase<SalesInvoce>();
            try
            {
                using (var context = new DataContext())
                {
                    model.CreateAt = DateTime.Now;
                    model.State = true;
                    response.Object = context.SalesInvoces.Add(model);
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

        public EResponseBase<SalesInvoce> Update(SalesInvoce model)
        {
            EResponseBase<SalesInvoce> response = new EResponseBase<SalesInvoce>();
            try
            {
                using (var context = new DataContext())
                {
                    var item = context.SalesInvoces.Where(x => x.SalesInvoceID == model.SalesInvoceID).FirstOrDefault();
                    item.Reason = model.Reason;
                    item.SellerID = model.SellerID;
                    item.CustomerID = model.CustomerID;
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

        public EResponseBase<SalesInvoce> Delete(int ID)
        {
            EResponseBase<SalesInvoce> response = new EResponseBase<SalesInvoce>();
            try
            {
                using (var context = new DataContext())
                {
                    var item = context.SalesInvoces.Where(x => x.SalesInvoceID == ID).FirstOrDefault();
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

        EResponseBase<SalesInvoce> IServiceBase<SalesInvoce>.GetList()
        {
            throw new NotImplementedException();
        }
    }
}
