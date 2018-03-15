using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Kayit
{
    public class GirisModel
    {
        public string email { get; set; }
        public string password { get; set; }
        public bool rememberme { get; set; }
    }
}
