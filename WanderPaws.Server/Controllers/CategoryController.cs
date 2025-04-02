//using WanderPaws.Application.DTOs;
//using WanderPaws.Implementation.Category.Commands;
//using WanderPaws.Implementation.Category.Queries;
//using MediatR;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace WanderPaws.Server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    [Authorize]
//    public class CategoryController(IMediator mediator) : ControllerBase
//    {
//        [HttpGet]
//        public async Task<List<CategoryDto>> Get([FromQuery] GetCategoriesQuery request)
//        {
//            //var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

//            return await mediator.Send(request);
//        }

//        //[HttpGet("{id}")]
//        //public async Task<ActionResult> GetById([FromBody] GetCategoryQuery request)
//        //{
//        //    return Ok(await mediator.Send(request));
//        //}

//        [HttpPost("create")]
//        public async Task<ActionResult> Create([FromBody] CreateCategoryCommand request)
//        {
//            await mediator.Send(request);
//            return Ok(new { message = "New category has been added." });
//        }

//        [HttpPost("delete")]
//        public async Task<ActionResult> Delete([FromBody] DeleteCategoryCommand request)
//        {
//            await mediator.Send(request);
//            return Ok(new { message = "The category has been removed." });
//        }
//    }
//}
