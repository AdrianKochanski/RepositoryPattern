using AutoMapper;
using DatabaseRepPattern.Models;
using DatabaseRepPattern.Models.Dtos;
using DatabaseRepPattern.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseRepPattern.Repository
{
    public class CustomersRepository : Repository<Customer>, ICustomersRepository
    {
        private readonly DataBase _context;
        private readonly IMapper _mapper;
        public CustomersRepository(DataBase context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Update(Customer oryginal, CustomerUpdateDto update)
        {
            if(oryginal != null && update != null)
            {
                _mapper.Map(update, oryginal);
            }
        }
    }
}

