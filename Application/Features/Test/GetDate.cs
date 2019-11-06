using Mediator.Mediator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Test
{
    public class GetDate
    {
        public class Request : BaseRequest<Response>
        {
            public int num { get; set; }
        }

        public class Response : BaseResponse
        {
            //public DateTime datum = DateTime.Now;
            public int redenBroj;
        }

        public class Handler : BaseHandler<Request, Response>
        {
            public override async Task<Response> Handle(Request request, System.Threading.CancellationToken cancellationToken)
            {
                return new Response { redenBroj = request.num };
            }
        }
    }
}
