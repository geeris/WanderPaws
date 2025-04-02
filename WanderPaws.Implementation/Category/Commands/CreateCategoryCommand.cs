//using WanderPaws.Application.Interfaces;
//using WanderPaws.Domain;
//using MediatR;
//using Microsoft.AspNetCore.Http;

//namespace WanderPaws.Implementation.Category.Commands
//{
//    public class CreateCategoryCommand : IRequest<Unit>
//    {
//        public string Name { get; set; }
//        public eCategoryType Type { get; set; }
//        public int? ParentId { get; set; }
//    }

//    public class CreateCategoryCommandHandler(ICategoryService categoryService, IHttpContextAccessor contextAccessor) : IRequestHandler<CreateCategoryCommand, Unit>
//    {
//        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
//        {
//            var check = contextAccessor.HttpContext.User.Identity.Name;

//            await categoryService.CreateCategory(new Domain.Entities.Category {
//                Name = request.Name,
//                Type = request.Type,
//                ParentId = request.ParentId,
//                UserId = null // to be added
//            });

//            return Unit.Value;
//        }
//    }
//}
