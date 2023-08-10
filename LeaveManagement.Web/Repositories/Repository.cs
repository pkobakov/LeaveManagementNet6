using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Data.ApplicationDbContext context;

        public Repository(Data.ApplicationDbContext context) 
        {
            this.context = context;
        }

        public async Task<T> AddAsync(T item)
        {
            await this.context.AddAsync(item);
            await this.context.SaveChangesAsync();  
            return item;
        }

        public async Task DeleteAsync(int id)
        {
            var item = await GetAsync(id); 
            this.context.Set<T>().Remove(item);
            await this.context.SaveChangesAsync();
            
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var item = await GetAsync(id);
           return item != null;    
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this.context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(int? id)
        {
            if (id == null) 
            {
                return null;
            }

            return await this.context.Set<T>().FindAsync(id);
        }

        public async Task<int> GetCountAsync()
        {
            var list = await GetAllAsync();
            return list.Count;
        }

        public async Task UpdateAsync(T entity)
        {
            //this.context.Entry(entity).State = EntityState.Modified;
            this.context.Update(entity);    
            await this.context.SaveChangesAsync();
        }
    }
}
