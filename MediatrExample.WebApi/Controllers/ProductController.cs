using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MediatrExample.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatrExample.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediatr;
        public ProductController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public Task<Response> Post([FromBody]Product message)
        {
            var response = _mediatr.Send(message);
            return response;
        }
    }
}