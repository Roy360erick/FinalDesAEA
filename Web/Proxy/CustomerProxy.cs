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
using Web.Helpers;
using Web.Models;

namespace Web.Proxy
{
    public class CustomerProxy
    {
        public async Task<ResponseProxy<CustomerModel>> GetAll()
        {
            var client = new HttpClient();
            string baseUrl = ApiUrlHelper.BaseUrl();
            client.BaseAddress = new Uri(baseUrl);

            var url = string.Concat(baseUrl, "/Api", "/Customer");
            var response = client.GetAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ResponseProxy<CustomerModel>>(result);
            }
            else
            {
                return new ResponseProxy<CustomerModel>
                {
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }

        public async Task<ResponseProxy<CustomerModel>> Get(int id)
        {
            var client = new HttpClient();
            string baseUrl = ApiUrlHelper.BaseUrl();
            client.BaseAddress = new Uri(baseUrl);

            var url = string.Concat(baseUrl, "/Api", "/Customer/",id);
            var response = client.GetAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ResponseProxy<CustomerModel>>(result);
            }
            else
            {
                return new ResponseProxy<CustomerModel>
                {
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }


        public async Task<ResponseProxy<CustomerModel>> Add(CustomerModel model)
        {
            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            var baseUrl = ApiUrlHelper.BaseUrl();
            client.BaseAddress = new Uri(baseUrl);
            var url = string.Concat(baseUrl, "/Api", "/Customer");

            var response = client.PostAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ResponseProxy<CustomerModel>>(result);
            }
            else
            {
                return new ResponseProxy<CustomerModel>
                {
                    Success = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
        public async Task<ResponseProxy<CustomerModel>> Update(CustomerModel model)
        {
            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            var baseUrl = ApiUrlHelper.BaseUrl();
            client.BaseAddress = new Uri(baseUrl);
            var url = string.Concat(baseUrl, "/Api", "/Customer/", model.CustomerID);

            var response = client.PutAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ResponseProxy<CustomerModel>>(result);
            }
            else
            {
                return new ResponseProxy<CustomerModel>
                {
                    Success = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
        public async Task<ResponseProxy<CustomerModel>> Delete(int id)
        {
            var client = new HttpClient();
            var baseUrl = ApiUrlHelper.BaseUrl();
            client.BaseAddress = new Uri(baseUrl);
            var url = string.Concat(baseUrl, "/Api", "/Customer/",id);

            var response = client.DeleteAsync(url).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ResponseProxy<CustomerModel>>(result);
            }
            else
            {
                return new ResponseProxy<CustomerModel>
                {
                    Success = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }


    }
}