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
    public class SalesInvoiceProxy
    {
        private string _urlBase = ConstantsUrl.UrlBase;
        private string _endPoint = $"{ConstantsUrl.Prefix}{ConstantsUrl.SalesInvoice}";

        public async Task<EResponseBase<SalesInvoiceSP_Response>> GetAll()
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(_urlBase);
                var response = await client.GetAsync(_endPoint);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new EResponseBase<SalesInvoiceSP_Response>
                    {
                        Code = 404,
                        Message = "Error"
                    };
                }
                var obj = JsonConvert.DeserializeObject<EResponseBase<SalesInvoiceSP_Response>>(answer);
                return obj;
            }
            catch (Exception ex)
            {
                return new EResponseBase<SalesInvoiceSP_Response>
                {
                    Code = 404,
                    Message = ex.Message
                };
            }
        }

        public async Task<EResponseBase<SalesInvoce_Response>> Get(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_urlBase);

            var url = string.Concat(_endPoint, id);
            var response = client.GetAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EResponseBase<SalesInvoce_Response>>(result);
            }
            else
            {
                return new EResponseBase<SalesInvoce_Response>
                {
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }


        public async Task<EResponseBase<SalesInvoce_Response>> Add(SalesInvoce_Request model)
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
                return JsonConvert.DeserializeObject<EResponseBase<SalesInvoce_Response>>(result);
            }
            else
            {
                return new EResponseBase<SalesInvoce_Response>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
        public async Task<EResponseBase<SalesInvoce_Response>> Add(SalesInvoiceRegister_Request model)
        {
            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            client.BaseAddress = new Uri(_urlBase);
            var url = string.Concat(_endPoint);

            var response = await client.PostAsync(url, content);
            var answer = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                return new EResponseBase<SalesInvoce_Response>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
            return JsonConvert.DeserializeObject<EResponseBase<SalesInvoce_Response>>(answer);
        }
        public async Task<EResponseBase<SalesInvoce_Response>> Update(SalesInvoce_Request model)
        {
            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            client.BaseAddress = new Uri(_urlBase);
            var url = string.Concat(_endPoint, model.SalesInvoceID);

            var response = client.PutAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EResponseBase<SalesInvoce_Response>>(result);
            }
            else
            {
                return new EResponseBase<SalesInvoce_Response>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
        public async Task<EResponseBase<SalesInvoce_Response>> Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_urlBase);
            var url = string.Concat(_endPoint, id);

            var response = client.DeleteAsync(url).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EResponseBase<SalesInvoce_Response>>(result);
            }
            else
            {
                return new EResponseBase<SalesInvoce_Response>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
    }
}