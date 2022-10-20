using System.Text;
using System.Text.Json;

namespace MoneyPot_BlazorFront.Helpers
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        public HttpService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        private async Task<T?> DeserializeAsync<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, options);
        }

        public async Task<HttpResponseWrapper<T?>> GetAsync<T>(string url)
        {
            var responseHTTP = await _httpClient.GetAsync(url);

            if (responseHTTP.IsSuccessStatusCode)
            {
                var response = await DeserializeAsync<T?>(responseHTTP, _jsonSerializerOptions);
                return new HttpResponseWrapper<T?>(response, true, responseHTTP);
            }
            else
            {
                return new HttpResponseWrapper<T?>(default, false, responseHTTP);
            }
        }

        public async Task<T?> GetHelperAsync<T>(string url)
        {
            var response = await GetAsync<T>(url);
            if (!response.IsSuccess)
            {
                throw new ApplicationException(await response.ReadResponseAsync());
            }
            return response.Response;
        }

        public async Task<HttpResponseWrapper<object?>> PostAsync<T>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, stringContent);
            return new HttpResponseWrapper<object?>(null, response.IsSuccessStatusCode, response);
        }

        public async Task<HttpResponseWrapper<TResponse?>> PostAsync<T, TResponse>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, stringContent);
            if (response.IsSuccessStatusCode)
            {
                var responseDeserialized = await DeserializeAsync<TResponse>(response, _jsonSerializerOptions);
                return new HttpResponseWrapper<TResponse?>(responseDeserialized, true, response);
            }
            else
            {
                return new HttpResponseWrapper<TResponse?>(default, false, response);
            }
        }

        public async Task<HttpResponseWrapper<object?>> PutAsync<T>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, stringContent);
            return new HttpResponseWrapper<object?>(null, response.IsSuccessStatusCode, response);
        }

        public async Task<HttpResponseWrapper<object?>> DeleteAsync(string url)
        {
            var res = await _httpClient.DeleteAsync(url);
            return new HttpResponseWrapper<object?>(null, res.IsSuccessStatusCode, res);
        }
    }
}
