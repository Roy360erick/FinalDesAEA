using Common;
using Common.HttpHelpers;
using Models.Request;
using Models.Response;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Web.Proxy
{
    public class ProductProxy
    {
        private string _urlBase = ConstantsUrl.UrlBase;
        private string _endPoint = $"{ConstantsUrl.Prefix}{ConstantsUrl.Product}";
        public async Task<EResponseBase<Product_Response>> GetAll()
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(_urlBase);
                var response = client.GetAsync(_endPoint).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<EResponseBase<Product_Response>>(result);
                }
                else
                {
                    return new EResponseBase<Product_Response>
                    {
                        Code = (int)response.StatusCode,
                        Message = "Error"
                    };
                }
            }
            catch (Exception ex)
            {
                return new EResponseBase<Product_Response>
                {
                    Code = 404,
                    Message = ex.Message
                };
            }
        }

        public async Task<EResponseBase<Product_Response>> Get(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_urlBase);

            var url = string.Concat(_endPoint, id);
            var response = client.GetAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EResponseBase<Product_Response>>(result);
            }
            else
            {
                return new EResponseBase<Product_Response>
                {
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }


        public async Task<EResponseBase<Product_Response>> Add(Product_Request model)
        {
            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            client.BaseAddress = new Uri(_urlBase);
            var url = string.Concat(_endPoint);

            var response = client.PostAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EResponseBase<Product_Response>>(result);
            }
            else
            {
                return new EResponseBase<Product_Response>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
        public async Task<EResponseBase<Product_Response>> Update(Product_Request model)
        {
            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            client.BaseAddress = new Uri(_urlBase);
            var url = string.Concat(_endPoint, model.ProductID);

            var response = client.PutAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EResponseBase<Product_Response>>(result);
            }
            else
            {
                return new EResponseBase<Product_Response>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
        public async Task<EResponseBase<Product_Response>> Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_urlBase);
            var url = string.Concat(_endPoint, id);

            var response = client.DeleteAsync(url).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EResponseBase<Product_Response>>(result);
            }
            else
            {
                return new EResponseBase<Product_Response>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
    }
}