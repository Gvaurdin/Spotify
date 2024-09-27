using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Spotify.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        private IMediator mediator;
        protected IMediator Mediator => 
            mediator ?? HttpContext.RequestServices.GetService<IMediator>();
    }
}
