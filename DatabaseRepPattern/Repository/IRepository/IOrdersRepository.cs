using DatabaseRepPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseRepPattern.Repository.IRepository
{
    public interface IOrdersRepository : IRepository<Order>
    {
        void Update(Order order);
    }
}
