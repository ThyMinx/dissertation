using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityMonitoringSystem.Interfaces
{
    public interface IDatabaseAccess<T>: IDisposable
    {
        List<T> GetAll();

        Task<List<T>> GetAllAsync();

        Task<T> FindByIdAsync(int? id);

        void Add(T item);

        Task SaveChangesAsync();

        DbEntityEntry Entry(T entity);

        void Remove(T entity);
    }
}
