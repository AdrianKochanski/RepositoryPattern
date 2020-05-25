using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseRepPattern.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomersRepository Customers { get; }
        IItemsRepository Items { get; }
        IOrdersRepository Orders { get; }
        ISP_Call SP_Call { get; }
        Task<bool> Save();
    }
}
