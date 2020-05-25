using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseRepPattern.Models.Dtos
{
    public class ItemDto
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public string description { get; set; }
        [Required]
        public decimal price { get; set; }
        public DateTime warrantyEnd { get; set; }
        public string category { get; set; }
        public Boolean isNew { get; set; }
        public ICollection<OrderItem> orderItems { get; set; }
    }
}
