using System;
using System.Threading.Tasks;
using [solutionName].Application.Services.Account;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace [solutionName].PublicApi.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : BaseController
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] Register.Command command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
