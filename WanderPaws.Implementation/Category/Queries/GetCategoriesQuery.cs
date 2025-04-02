//using WanderPaws.Application.DTOs;
//using MediatR;

//namespace WanderPaws.Implementation.Category.Queries
//{
//    public class GetCategoriesQuery : IRequest<List<CategoryDto>>
//    {
//    }

//    public class GetCategoriesQueryHandler(ICategoryService categoryService) : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
//    {
//        public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
//        {
//            var c = await categoryService.GetCategories();

//            return c;
//        }
//    }
//}
