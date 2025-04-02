//using WanderPaws.Application.DTOs;
//using WanderPaws.Application.Interfaces;
//using WanderPaws.DataAccess;
//using Microsoft.EntityFrameworkCore;

//namespace WanderPaws.Implementation.Services
//{
//    public class CategoryService(WanderPawsContext db) : ICategoryService
//    {
//        public async Task<List<CategoryDto>> GetCategories()
//        {
//            var categories = db.Categories.Where(c => c.ParentId == null).Include(x => x.ChildCategories);
//            var category = new List<CategoryDto>();

//            async Task<List<CategoryDto>> GetCategoryChildrenRecursive(IEnumerable<Domain.Entities.Category> categories)
//            {
//                var categoryWithChildren = new List<CategoryDto>();

//                foreach (var category in categories)
//                {
//                    categoryWithChildren.Add(new CategoryDto
//                    {
//                        Id = category.Id,
//                        Name = category.Name,
//                        Type = category.Type,
//                        IsPredefined = category.UserId == null ? true : false,
//                        ParentId = category.ParentId,
//                        Children = await GetCategoryChildrenRecursive(category.ChildCategories)
//                    });
//                }

//                return categoryWithChildren;
//            }

//            foreach (var category1 in categories)
//            {
//                category.Add(new CategoryDto
//                {
//                    Id = category1.Id,
//                    Name = category1.Name,
//                    Type = category1.Type,
//                    IsPredefined = category1.UserId == null ? true : false,
//                    ParentId = category1.ParentId,
//                    Children = await GetCategoryChildrenRecursive(category1.ChildCategories)
//                });
//            }

//            return await GetCategoryChildrenRecursive(categories);
//        }

//        public async Task CreateCategory(WanderPaws.Domain.Entities.Category category)
//        {
//            db.Categories.Add(category);

//            await db.SaveChangesAsync();
//        }

//        public async Task DeleteCategory(int id)
//        {
//            var category = await db.Categories.SingleAsync(c => c.Id == id);

//            db.Categories.Remove(category);

//            await db.SaveChangesAsync();
//        }
//    }
//}
