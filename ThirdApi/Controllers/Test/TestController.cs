using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Test;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ThirdApi.Controllers.Test
{
    public class TestController : BaseController
    {
        public TestController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("getDate")]
        public async Task<GetDate.Response> Get(GetDate.Request request)
        {
            var response = await Handle(request);
            return response;
        }
    }
}