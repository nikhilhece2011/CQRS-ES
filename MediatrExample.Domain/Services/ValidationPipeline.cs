using MediatR;
using MediatrExample.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrExample.Domain.Services
{
    public class ValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : EntityBase where TResponse : Response
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!((EntityBase)request).Valid)
            {
                var response = (TResponse)new Response(request.Notifications, true);
                return response;
            }

            var result =await next();
            return result;
        }
    }
}
