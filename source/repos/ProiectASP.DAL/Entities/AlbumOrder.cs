using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectASP.DAL.Entities
{
    [Table ("AlbumOrder")]
    public class AlbumOrder
    {
        public int Id { get; set; }

        public int? AlbumId { get; set; }

        public int? OrderId { get; set; }

        [DefaultValue(1)]
        public int Quantity { get; set; }

        public virtual Album Album { get; set; }
        public virtual Order Order { get; set; }
    }
}
