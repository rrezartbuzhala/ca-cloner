using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace [solutionName].PublicApi.Controllers
{
    [ApiController]
    [Authorize]
    public class BaseController : ControllerBase
    {
        
    }
}