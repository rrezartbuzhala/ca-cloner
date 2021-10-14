using System;
using System.Threading.Tasks;
using [solutionName].Application.Services.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace [solutionName].PublicApi.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : BaseController
    {
        private readonly IMediator _mediator;
        public AuthenticationController(IMediator medaitor)
        {
            _mediator = medaitor ?? throw new ArgumentNullException(nameof(medaitor));
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] Login.Command command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
