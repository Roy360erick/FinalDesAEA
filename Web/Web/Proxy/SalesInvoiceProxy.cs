using Common;
using Common.ApiUrlHelpers;
using Common.HttpHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Web.Models;

namespace Web.Proxy
{
    public class SalesInvoiceProxy
    {
        static string baseUrl = ApiUrl.Url((int)Numerable.SalesInvoice);
        public async Task<EResponseBase<SalesInvoiceModel>> GetAll()
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(baseUrl);

                var url = string.Concat(baseUrl);
                var response = client.GetAsync(url).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<EResponseBase<SalesInvoiceModel>>(result);
                }
                else
                {
                    return new EResponseBase<SalesInvoiceModel>
                    {
                        Code = (int)response.StatusCode,
                        Message = "Error"
                    };
                }
            }
            catch (Exception ex)
            {
                return new EResponseBase<SalesInvoiceModel>
                {
                    Code = 404,
                    Message = ex.Message
                };
            }
        }

        public async Task<EResponseBase<SalesInvoiceModel>> Get(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);

            var url = string.Concat(baseUrl, id);
            var response = client.GetAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EResponseBase<SalesInvoiceModel>>(result);
            }
            else
            {
                return new EResponseBase<SalesInvoiceModel>
                {
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }


        public async Task<EResponseBase<SalesInvoiceModel>> Add(SalesInvoiceModel model)
        {
            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var url = string.Concat(baseUrl);

            var response = client.PostAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EResponseBase<SalesInvoiceModel>>(result);
            }
            else
            {
                return new EResponseBase<SalesInvoiceModel>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
        public async Task<EResponseBase<SalesInvoiceModel>> Update(SalesInvoiceModel model)
        {
            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var url = string.Concat(baseUrl, model.SalesInvoceID);

            var response = client.PutAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EResponseBase<SalesInvoiceModel>>(result);
            }
            else
            {
                return new EResponseBase<SalesInvoiceModel>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
        public async Task<EResponseBase<SalesInvoiceModel>> Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var url = string.Concat(baseUrl, id);

            var response = client.DeleteAsync(url).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EResponseBase<SalesInvoiceModel>>(result);
            }
            else
            {
                return new EResponseBase<SalesInvoiceModel>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
    }
}