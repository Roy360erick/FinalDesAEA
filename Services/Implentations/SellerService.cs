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
    public class SellerService : IServiceBase<Seller>
    {
        public EResponseBase<Seller> Get(int ID)
        {
            EResponseBase<Seller> response = new EResponseBase<Seller>();
            try
            {
                using (var context = new DataContext())
                {
                    response.Object = context.Sellers.Where(x => x.SellerID == ID && x.State == true).FirstOrDefault();
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

        public EResponseBase<Seller> GetList()
        {
            EResponseBase<Seller> response = new EResponseBase<Seller>();
            try
            {
                using (var context = new DataContext())
                {
                    response.List = context.Sellers.Where(x => x.State == true).ToList();
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

        public EResponseBase<Seller> Add(Seller model)
        {
            EResponseBase<Seller> response = new EResponseBase<Seller>();
            try
            {
                using (var context = new DataContext())
                {
                    model.CreateAt = DateTime.Now;
                    model.State = true;
                    context.Sellers.Add(model);
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

        public EResponseBase<Seller> Update(Seller model)
        {
            EResponseBase<Seller> response = new EResponseBase<Seller>();
            try
            {
                using (var context = new DataContext())
                {
                    var seller = context.Sellers.Where(x => x.SellerID == model.SellerID).FirstOrDefault();
                    seller.Name = model.Name;
                    seller.LastName = model.LastName;
                    seller.Email = model.Email;
                    seller.Birthdate = model.Birthdate;
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

        public EResponseBase<Seller> Delete(int ID)
        {
            EResponseBase<Seller> response = new EResponseBase<Seller>();
            try
            {
                using (var context = new DataContext())
                {
                    var item = context.Sellers.Where(x => x.SellerID == ID).FirstOrDefault();
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
