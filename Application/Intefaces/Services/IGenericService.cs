namespace Application.Intefaces.Services
{
    public interface IGenericService<TRequest, TResponse, TEntity>
        where TRequest : class
        where TResponse : class
        where TEntity : class
    {
        Task<TResponse> Add(TRequest request);
        Task Delete(int id);
        Task<List<TResponse>> GetAll();
        Task<TResponse?> GetById(int id);
        Task<TResponse?> Update(TResponse request, int id);
    }
}