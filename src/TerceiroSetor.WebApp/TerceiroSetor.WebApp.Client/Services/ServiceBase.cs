using Newtonsoft.Json;
using System.Text;
using TerceiroSetor.DTOs;

namespace TerceiroSetor.WebApp.Client.Services
{
    public abstract class ServiceBase
    {
        protected StringContent GetContent(object dado)
        {
            return new StringContent(
                JsonConvert.SerializeObject(dado),
                Encoding.UTF8,
                "application/json");
        }

        protected async Task<T> GetJsonResponse<T>(HttpResponseMessage responseMessage)
        {
            var response = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(response);
        }

        protected bool HandleErrors(HttpResponseMessage response)
        {
            switch ((int)response.StatusCode)
            {
                case 401:
                case 403:
                case 404:
                case 500:
                    throw new HttpRequestException();

                case 400:
                case 422:
                    return false;
            }

            response.EnsureSuccessStatusCode();
            return true;
        }

        protected ResponseResult ResponseOK()
        {
            return new ResponseResult();
        }

    }
}
