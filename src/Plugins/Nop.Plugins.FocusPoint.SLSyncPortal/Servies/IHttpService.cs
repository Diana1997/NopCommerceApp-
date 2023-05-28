using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Nop.Plugins.FocusPoint.SLSyncPortal.Servies
{
    public interface IHttpService
    {

        Task<TResponse> Get<TResponse>(string url, CancellationToken cancellationToken);
        Task<string> Get(string url, CancellationToken cancellationToken, bool setLongTimeout = false);
        Task<TResponse> Post<TResponse, TRequest>(string url, TRequest request, CancellationToken cancellationToken);
        /*Task<TResponse> Post<TResponse, TRequest>(string url, TRequest request, CancellationToken cancellationToken);
        Task<TResponse> Post<TResponse>(string url, CancellationToken cancellationToken);
        void AddAuthorization(string schema, string value);
        void AddHeader(string name, string value);
        void ClearHeader();
        void AddContentType(string value);*/
    }
}