using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mediator.Mediator
{
    public abstract class BaseRequest<TResponse> : IRequest<TResponse>
        where TResponse : BaseResponse
    {
    }
}
