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
    public class ProductProxy
    {
        static string baseUrl = ApiUrl.Url((int)Numerable.Product);
        public async Task<EResponseBase<ProductModel>> GetAll()
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
                    return JsonConvert.DeserializeObject<EResponseBase<ProductModel>>(result);
                }
                else
                {
                    return new EResponseBase<ProductModel>
                    {
                        Code = (int)response.StatusCode,
                        Message = "Error"
                    };
                }
            }
            catch (Exception ex)
            {
                return new EResponseBase<ProductModel>
                {
                    Code = 404,
                    Message = ex.Message
                };
            }
        }

        public async Task<EResponseBase<ProductModel>> Get(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);

            var url = string.Concat(baseUrl, id);
            var response = client.GetAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EResponseBase<ProductModel>>(result);
            }
            else
            {
                return new EResponseBase<ProductModel>
                {
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }


        public async Task<EResponseBase<ProductModel>> Add(ProductModel model)
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
                return JsonConvert.DeserializeObject<EResponseBase<ProductModel>>(result);
            }
            else
            {
                return new EResponseBase<ProductModel>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
        public async Task<EResponseBase<ProductModel>> Update(ProductModel model)
        {
            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var url = string.Concat(baseUrl, model.ProductID);

            var response = client.PutAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EResponseBase<ProductModel>>(result);
            }
            else
            {
                return new EResponseBase<ProductModel>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
        public async Task<EResponseBase<ProductModel>> Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var url = string.Concat(baseUrl, id);

            var response = client.DeleteAsync(url).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EResponseBase<ProductModel>>(result);
            }
            else
            {
                return new EResponseBase<ProductModel>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
    }
}