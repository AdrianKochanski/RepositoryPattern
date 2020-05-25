using DatabaseRepPattern.Models;
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
        public CustomersRepository(DataBase context) : base(context)
        {
            _context = context;
        }

        public void Update(Customer update)
        {
            var oryginal = _context.Customers.FirstOrDefault(c => c.id==update.id);
            if(oryginal != null)
            {
                oryginal.login = update.login;
                oryginal.name = update.name;
                oryginal.surname = update.surname;
                oryginal.street = update.street;
                oryginal.postalcode = update.postalcode;
                oryginal.number = update.number;
                oryginal.houseNumber = update.houseNumber;
                oryginal.email = update.email;
                oryginal.description = update.description;
                oryginal.creditcard = update.creditcard;
                oryginal.country = update.country;
                oryginal.city = update.city;
            }
        }
    }
}

