using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.DAL.Entities
{
    public class Info
    {
        public int Id { get; set; }
        public string Information { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int? AlbumId { get; set; }
        public virtual Album Album { get; set; }
    }
}
