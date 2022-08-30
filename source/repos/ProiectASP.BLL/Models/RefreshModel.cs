using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.BLL.Models
{
    public class RefreshModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
