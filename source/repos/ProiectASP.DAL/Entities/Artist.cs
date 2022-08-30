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
    [Table("Artist")]
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
