//using WanderPaws.Application.Interfaces;
//using MediatR;

//namespace WanderPaws.Implementation.Category.Commands
//{
//    public class DeleteCategoryCommand : IRequest<Unit>
//    {
//        public int Id { get; set; }
//    }

//    public class DeleteCategoryCommandHandler(ICategoryService categoryService) : IRequestHandler<DeleteCategoryCommand, Unit>
//    {
//        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
//        {
//            await categoryService.DeleteCategory(request.Id);

//            return Unit.Value;
//        }
//    }
//}
