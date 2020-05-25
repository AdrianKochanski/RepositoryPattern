using DatabaseRepPattern.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseRepPattern.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBase _db;
        public ICustomersRepository Customers { get; private set; }
        public IItemsRepository Items { get; private set; }
        public IOrdersRepository Orders { get; private set; }
        public ISP_Call SP_Call { get; private set; }

        public UnitOfWork(DataBase db)
        {
            _db = db;
            Customers = new CustomersRepository(_db);
            Items = new ItemsRepository(_db);
            Orders = new OrdersRepository(_db);
            SP_Call = new SP_Call(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task<bool> Save()
        {
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
