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
    public class SellerProxy
    {
        static string baseUrl = ApiUrl.Url((int)Numerable.Seller);
        public async Task<EResponseBase<SellerModel>> GetAll()
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
                    return JsonConvert.DeserializeObject<EResponseBase<SellerModel>>(result);
                }
                else
                {
                    return new EResponseBase<SellerModel>
                    {
                        Code = (int)response.StatusCode,
                        Message = "Error"
                    };
                }
            }
            catch (Exception ex)
            {
                return new EResponseBase<SellerModel>
                {
                    Code = 404,
                    Message = ex.Message
                };
            }
        }

        public async Task<EResponseBase<SellerModel>> Get(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);

            var url = string.Concat(baseUrl, id);
            var response = client.GetAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EResponseBase<SellerModel>>(result);
            }
            else
            {
                return new EResponseBase<SellerModel>
                {
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }


        public async Task<EResponseBase<SellerModel>> Add(SellerModel model)
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
                return JsonConvert.DeserializeObject<EResponseBase<SellerModel>>(result);
            }
            else
            {
                return new EResponseBase<SellerModel>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
        public async Task<EResponseBase<SellerModel>> Update(SellerModel model)
        {
            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var url = string.Concat(baseUrl, model.SellerID);

            var response = client.PutAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EResponseBase<SellerModel>>(result);
            }
            else
            {
                return new EResponseBase<SellerModel>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
        public async Task<EResponseBase<SellerModel>> Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var url = string.Concat(baseUrl, id);

            var response = client.DeleteAsync(url).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EResponseBase<SellerModel>>(result);
            }
            else
            {
                return new EResponseBase<SellerModel>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
    }
}