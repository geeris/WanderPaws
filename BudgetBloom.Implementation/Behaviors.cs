//using BudgetBloom.DataAccess;
//using MediatR;

//namespace BudgetBloom.Implementation
//{
//    public interface IHasDbContext
//    {
//        BudgetBloomContext DbContext { get; set; }
//    }

//    public class DbContextInjectionBehavior<TRequest, TResponse>(BudgetBloomContext dbContext) : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
//    {
//        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
//        {
//            // Attach DbContext to the request if needed (optional)
//            if (request is IHasDbContext dbRequest)
//            {
//                dbRequest.DbContext = dbContext;
//            }

//            // Call the next handler in the pipeline
//            return await next();
//        }
//    }
//}
