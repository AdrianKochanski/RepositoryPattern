using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseRepPattern.Models
{
    public class Customer
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public string surname { get; set; }
        [Required]
        public string login { get; set; }
        [Required]
        public byte[] passwordHash { get; set; }
        [Required]
        public byte[] passwordSalt { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public DateTime lastActive { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string number { get; set; }
        [Required]
        public string country { get; set; }
        [Required]
        public string street { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string postalcode { get; set; }
        [Required]
        public int houseNumber { get; set; }
        public string description { get; set; }
        public string creditcard { get; set; }
        public ICollection<Item> items { get; set; }
        public ICollection<Order> orders { get; set; }
    }
}
