using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekno.CORE.Entity;

namespace Tekno.MODEL.Entity
{
    public class UserAdress:CoreEntity
    {
        public int UserID { get; set; }
        public AppUser AppUser { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public bool IsActive { get; set; }
    }
}
