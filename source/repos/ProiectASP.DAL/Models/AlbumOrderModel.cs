using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectASP.DAL.Models
{
    public class AlbumOrderModel
    {
        public int Id { get; set; }
        public int? AlbumId { get; set; }
        public int? OrderId { get; set; }
        public int Quantity { get; set; }
    }
}
