using QualityMonitoringSystem.Interfaces;
using QualityMonitoringSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace QualityMonitoringSystem.Dal
{
    public class StaffDatabaseAccess : IDatabaseAccess<Staff>
    {
        private QualityMonitoringSystemEntities db = new QualityMonitoringSystemEntities();

        public List<Staff> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Staff>> GetAllAsync()
        {
            return await this.db.Staffs.ToListAsync();
        }

        public async Task<Staff> FindByIdAsync(int? id)
        {
            return await this.db.Staffs.FindAsync(id);
        }

        public void Add(Staff item)
        {
            this.db.Staffs.Add(item);
        }

        public async Task SaveChangesAsync()
        {
            await this.db.SaveChangesAsync();
        }

        public DbEntityEntry Entry(Staff entity)
        {
            return this.db.Entry(entity);
        }

        public void Remove(Staff entity)
        {
            this.db.Staffs.Remove(entity);
        }

        public void Dispose()
        {
            this.db.Dispose();
        }
    }
}