using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseRepPattern.Models
{
    public class OrderItem
    {
        [Required]
        public int itemId { get; set; }
        [ForeignKey("itemId")]
        public Item Item { get; set; }
        [Required]
        public int orderId { get; set; }
        [ForeignKey("orderId")]
        public Order Order { get; set; }
        [Required]
        public int amount { get; set; }
    }
}