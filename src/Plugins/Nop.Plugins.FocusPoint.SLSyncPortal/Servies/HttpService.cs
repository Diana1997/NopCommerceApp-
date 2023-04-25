using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Nop.Plugins.FocusPoint.SLSyncPortal.Exceptions;


namespace Nop.Plugins.FocusPoint.SLSyncPortal.Servies
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _client;
        private bool _disposedValue;

        public HttpService()
        {
            _client = new HttpClient { Timeout = TimeSpan.FromMinutes(3) };
        }


        public async Task<TResponse> Get<TResponse>(string url, CancellationToken cancellationToken)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;


            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var response = await _client.GetAsync(url, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();


                return JsonConvert.DeserializeObject<TResponse>(jsonString);
            }

            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new RestApiResponseException((int)response.StatusCode,
                    await response.Content.ReadAsStringAsync());
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new RestApiResponseException((int)response.StatusCode, "EntityNotFound");
            }

            throw new RestApiResponseException("RequestFailed");
        }

        public async Task<string> Get(string url, CancellationToken cancellationToken)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;


            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var response = await _client.GetAsync(url, cancellationToken);

            if (!response.IsSuccessStatusCode)
                throw new RestApiResponseException("RequestFailed");


            var jsonString = await response.Content.ReadAsStringAsync();


            return jsonString;
        }


        /*public async Task<TResponse> Post<TResponse, TRequest>(string url, TRequest request, CancellationToken cancellationToken, List<JsonConverter> converters = null)
        {
    
            var json = JsonConvert.SerializeObject(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(url, data, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                throw new RestApiResponseException("RequestFailed");
            }
            var model = await response.Content.ReadAsStringAsync();
         
            var returnData =  JsonConvert.DeserializeObject<TResponse>(model);

            return returnData;
        }
        
        

        public async Task<TResponse> Post<TResponse>(string url, CancellationToken cancellationToken)
        {
            var response = await _client.PostAsync(url, null, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
               throw new RestApiResponseException("RequestFailed");
            }
            var model = await response.Content.ReadAsStreamAsync();

         //   var returnData = await JsonSerializer.DeserializeAsync<TResponse>(model, cancellationToken: cancellationToken);

        //    return returnData;
            return default;
        }

        public void AddAuthorization(string schema, string value)
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(schema, value);
        }

        public void AddHeader(string name, string value)
        {
            _client.DefaultRequestHeaders.Add(name, value);
        }

        public void ClearHeader()
        {
            _client.DefaultRequestHeaders.Clear();
        }

        public void AddContentType(string value)
        {
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", value);
        }*/

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _client?.Dispose();
                }

                _disposedValue = true;
            }
        }


        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}