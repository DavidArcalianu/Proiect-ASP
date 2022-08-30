using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace ProiectASP.DAL.Entities
{
    [Table ("Album")]
    public class Album
    {
        public int Id { get; set;  }
        public string Name { get; set; }
        public virtual Artist Artist { get; set; }
        public string Genre { get; set; }

        [Range(0, int.MaxValue)]
        public double Price { get; set; }
        public string Image { get; set; }

        public virtual ICollection<AlbumOrder> AlbumOrders { get; set; }

        public virtual Info Info { get; set; }
    }
}
