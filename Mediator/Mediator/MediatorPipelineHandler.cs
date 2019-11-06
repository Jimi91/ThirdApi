using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mediator.Mediator
{
    public class MediatorPipelineHandler<TRequest, TResponse> : IRequestHandler<TRequest,TResponse>
        where TRequest : IRequest<TResponse>
            where TResponse : class
    {
        private readonly IRequestHandler<TRequest, TResponse> _handler;
        public MediatorPipelineHandler(IRequestHandler<TRequest, TResponse> handler)
        {
            _handler = handler;
        }

        

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            TResponse response = await _handler.Handle(request, System.Threading.CancellationToken.None);
            return response;
        }
    }
}
