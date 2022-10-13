namespace MoneyPot_BlazorFront.Helpers
{
    public class HttpResponseWrapper<T>
    {
        public T Response { get; set; }
        public bool IsSuccess { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }
        public HttpResponseWrapper(T response, bool isSuccess, HttpResponseMessage httpResponseMessage)
        {
            this.Response = response;
            this.IsSuccess = isSuccess;
            this.HttpResponseMessage = httpResponseMessage;
        }

        public async Task<string> ReadResponse()
        {
            return await HttpResponseMessage.Content.ReadAsStringAsync();
        }
    }
}
