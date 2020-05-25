using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseRepPattern.Models.Dtos
{
    public class CustomerUpdateDto
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string login { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string number { get; set; }
        public string country { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string postalcode { get; set; }
        public int houseNumber { get; set; }
        public string description { get; set; }
        public string creditcard { get; set; }
    }
}
