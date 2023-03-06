using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public static class HttpClientServices
    {
        public static async Task<T> ExecuteServiceWithOutBody<T>(String serviceUrl, String access_token = "")
        {
            if (!string.IsNullOrEmpty(serviceUrl))
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage();
                request.Method = new HttpMethod("GET");
                request.RequestUri = new Uri(serviceUrl);

                if (!String.IsNullOrWhiteSpace(access_token))
                    request.Headers.Add("Authorization", String.Format("bearer {0}", access_token));

                request.Content = new StringContent("application/json");
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    String json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(json);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new Exception("NotFound");
                }
            }

            return await default(Task<T>);
        }

        public static async Task<T> ExecuteServiceWithBody<T, B>(String serviceUrl, B body, String Verbo, String access_token = "")
        {
            if (!string.IsNullOrEmpty(serviceUrl))
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage();

                if (!String.IsNullOrWhiteSpace(access_token))
                    request.Headers.Add("Authorization", String.Format("bearer {0}", access_token));

                request.Method = new HttpMethod(Verbo);
                request.RequestUri = new Uri(serviceUrl);
                request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK)
                {
                    String json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(json);
                }
            }
            return await default(Task<T>);
        }
    }

    public enum MethodVerbs
    {
        POST,
        GET,
        PUT,
        DELETE
    }
}
