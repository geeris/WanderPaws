namespace BudgetBloom.Application.Interfaces
{
    public interface ICustomException
    {
        int StatusCode { get; }
        string Message { get; set; }
    }
}
