using AutoMapper;
using DatabaseRepPattern.Models;
using DatabaseRepPattern.Models.Dtos;
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
        private readonly IMapper _mapper;
        public ItemsRepository(DataBase context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Update(Item oryginal, ItemUpdateDto update)
        {
            if (oryginal != null)
            {
                _mapper.Map(update, oryginal);
            }
        }
    }
}
