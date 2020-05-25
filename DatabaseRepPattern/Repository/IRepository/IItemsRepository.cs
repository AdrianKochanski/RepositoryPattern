using DatabaseRepPattern.Models;
using DatabaseRepPattern.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseRepPattern.Repository.IRepository
{
    public interface IItemsRepository : IRepository<Item>
    {
        void Update(Item oryginal, ItemUpdateDto update);
    }
}
