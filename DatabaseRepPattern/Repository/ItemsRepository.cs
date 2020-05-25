using DatabaseRepPattern.Models;
using DatabaseRepPattern.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseRepPattern.Repository
{
    public class ItemsRepository : Repository<Item>, IItemsRepository
    {
        private readonly DataBase _context;
        public ItemsRepository(DataBase context) : base(context)
        {
            _context = context;
        }

        public void Update(Item update)
        {
            var oryginal = _context.Items.FirstOrDefault(c => c.id == update.id);
            if (oryginal != null)
            {
                oryginal.category = update.category;
                oryginal.isNew = update.isNew;
                oryginal.price = update.price;
                oryginal.name = update.name;
                oryginal.description = update.description;
                oryginal.warrantyEnd = update.warrantyEnd;
            }
        }
    }
}
