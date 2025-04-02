using WanderPaws.Domain;

namespace WanderPaws.Application.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public eCategoryType Type { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public bool IsPredefined { get; set; }
        public List<CategoryDto> Children { get; set; }
    }
}
