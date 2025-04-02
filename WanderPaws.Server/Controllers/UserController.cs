using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WanderPaws.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase
    {
        
    }
}
