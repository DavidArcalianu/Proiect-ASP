using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectASP.DAL.Entities
{
    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }

        [Range(0, int.MaxValue)]
        public double Price { get; set; }

        public string Address { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime? ShippingDate { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<AlbumOrder> AlbumOrders { get; set; }
        
    }
}
