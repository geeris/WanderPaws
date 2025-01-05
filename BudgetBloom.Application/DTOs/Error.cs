namespace BudgetBloom.Application.DTOs
{
    public class Error
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public Dictionary<string, string[]> Errors { get; set; }
    }
}
