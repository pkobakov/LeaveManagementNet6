namespace LeaveManagement.Application.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T item);
        Task AddRangeAsync(IList<T> entities);
        Task<int> GetCountAsync();
        Task<bool> ExistsAsync(int id);   
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);

    }
}
