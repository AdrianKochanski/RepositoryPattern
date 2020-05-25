using DatabaseRepPattern.Models;
using DatabaseRepPattern.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseRepPattern.Repository
{
    public class OrdersRepository : Repository<Order>, IOrdersRepository
    {
        private readonly DataBase _context;
        public OrdersRepository(DataBase context) : base(context)
        {
            _context = context;
        }

        public void Update(Order update)
        {
            var oryginal = _context.Orders.FirstOrDefault(c => c.id==update.id);
            if(oryginal != null)
            {
                oryginal.street = update.street;
                oryginal.country = update.country;
                oryginal.city = update.city;
                oryginal.dateDelivery = update.dateDelivery;
                oryginal.houseNr = update.houseNr;
                oryginal.isPaid = update.isPaid;
                oryginal.paymentType = update.paymentType;
                oryginal.postalCode = update.postalCode;
            }
        }
    }
}

