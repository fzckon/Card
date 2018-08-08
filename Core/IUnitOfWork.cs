using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core
{
    public interface IUnitOfWork : IDisposable
    {
        //TRepository GetRepository<TRepository>() where TRepository : class;
        //void ExecuteProcedure(string procedureCommand, params object[] sqlParams);
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
