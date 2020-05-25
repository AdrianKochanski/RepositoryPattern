using DatabaseRepPattern.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseRepPattern.Repository
{
    public class Seed
    {
        public static void SeedCustomers(DataBase context)
        {
            if (!context.Customers.Any())
            {
                var customerData = System.IO.File.ReadAllText("Repository/SeedData.json");
                var customers = JsonConvert.DeserializeObject<List<Customer>>(customerData);
                foreach(var customer in customers)
                {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash("password", out passwordHash, out passwordSalt);
                    customer.passwordHash = passwordHash;
                    customer.passwordSalt = passwordSalt;
                    customer.name = customer.name.ToLower();
                    customer.surname = customer.surname.ToLower();
                    context.Customers.Add(customer);
                }
                context.SaveChanges();
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passHash, out byte[] passSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passSalt = hmac.Key;
                passHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
