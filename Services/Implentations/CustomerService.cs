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
    public class CustomerService : IServiceBase<Customer>
    {
        public EResponseBase<Customer> Get(int ID)
        {
            EResponseBase<Customer> response = new EResponseBase<Customer>();
            try
            {
                using (var context = new DataContext())
                {
                    response.Object = context.Customers.Where(x => x.CustomerID == ID && x.State == true).FirstOrDefault();
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

        public EResponseBase<Customer> GetList()
        {
            EResponseBase<Customer> response = new EResponseBase<Customer>();
            try
            {
                using (var context = new DataContext())
                {
                    response.List = context.Customers.Where(x => x.State == true).ToList();
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
        public EResponseBase<Customer> Add(Customer model)
        {
            model.State = true;
            model.CreateAt = DateTime.Now;
            EResponseBase<Customer> response = new EResponseBase<Customer>();
            try
            {
                using (var context = new DataContext())
                {
                    context.Customers.Add(model);
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

        public EResponseBase<Customer> Update(Customer model)
        {
            EResponseBase<Customer> response = new EResponseBase<Customer>();
            try
            {
                using (var context = new DataContext())
                {
                    var item = context.Customers.Find(model.CustomerID);
                    item.Name = model.Name;
                    item.LastName = model.LastName;
                    item.Birthdate = model.Birthdate;
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

        public EResponseBase<Customer> Delete(int ID)
        {
            EResponseBase<Customer> response = new EResponseBase<Customer>();
            try
            {
                using (var context = new DataContext())
                {
                    var item = context.Customers.Where(x => x.CustomerID == ID).FirstOrDefault();
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
