using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseRepPattern.Models.Dtos
{
    public class OrderDto
    {
        [Key]
        public int id { get; set; }
        [Required]
        public DateTime dateOrder { get; set; }
        public DateTime dateDelivery { get; set; }
        public ICollection<OrderItem> orderItems { get; set; }
        [Required]
        public string paymentType { get; set; }
        [Required]
        public Boolean isPaid { get; set; }
        public string country { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string postalCode { get; set; }
        [Required]
        public string street { get; set; }
        [Required]
        public int houseNr { get; set; }
    }
}
