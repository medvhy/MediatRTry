using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatRTry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ValuesController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // POST api/values
        [HttpPost]
        //public async Task<IActionResult> Post([FromBody]SomeEvent value)
        //public async Task<IActionResult> Post([FromBody]PingCommand value)
        public async Task<IActionResult> Post([FromBody]DataViewModel value)
        {
            await _mediator.Publish(new SomeEvent(value.Message));
            return Ok(await _mediator.Send(new PingCommand(value.Message)));
        }
    }

    public class DataViewModel
    {
        public string Message { get; set; }
    }
}
