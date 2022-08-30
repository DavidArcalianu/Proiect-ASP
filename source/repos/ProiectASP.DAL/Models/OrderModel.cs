using System;
using System.Collections.Generic;

namespace ProiectASP.DAL.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public String Address { get; set; }

        public double Price { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime? ShippingDate { get; set; }

        public int? UserId { get; set; }
    }
}
