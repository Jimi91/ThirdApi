using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThirdApi
{
    public class BaseController : Controller
    {
        private IMediator _mediator;

        public BaseController(IMediator m)
        {
            _mediator = m;
        }

        protected async Task<TResponse> Handle<TResponse>(IRequest<TResponse> request)
        {
            return await _mediator.Send(request);
        }
    }
}
