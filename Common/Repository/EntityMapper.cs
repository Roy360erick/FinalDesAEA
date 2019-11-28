using AutoMapper;
using Common.HttpHelpers;
using Domain.Models;
using Models.Request;
using Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    public class EntityMapper<TSource, TDestination> where TSource : class where TDestination : class
    {

        public EntityMapper()
        {
            Mapper.CreateMap<EResponseBase<Product>, EResponseBase<Product_Response>>();
            Mapper.CreateMap<EResponseBase<Product_Response>, EResponseBase<Product>>();
            Mapper.CreateMap<EResponseBase<Product_Request>, EResponseBase<Product>>();

            Mapper.CreateMap<EResponseBase<Customer>, EResponseBase<Customer_Response>>();
            Mapper.CreateMap<EResponseBase<Customer_Response>, EResponseBase<Customer>>();
            Mapper.CreateMap<EResponseBase<Customer_Request>, EResponseBase<Customer>>();

            Mapper.CreateMap<SalesInvoce, SalesInvoce_Response>();
            Mapper.CreateMap<SalesInvoce_Response, SalesInvoce>();
            Mapper.CreateMap<SalesInvoce_Request, SalesInvoce>();

            Mapper.CreateMap<SalesInvoceDetail, SalesInvoceDetail_Response>();
            Mapper.CreateMap<SalesInvoceDetail_Response, SalesInvoceDetail>();
            Mapper.CreateMap<SalesInvoceDetail_Request, SalesInvoceDetail>();

            Mapper.CreateMap<Seller, Seller_Response>();
            Mapper.CreateMap<Seller_Response, Seller>();
            Mapper.CreateMap<Seller_Request, Seller>();

        }

        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }

    }
}
