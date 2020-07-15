using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekno.MODEL.Entity;
using Tekno.SERVICE.Base;

namespace Tekno.SERVICE.Option
{
    public class AppUserService:BaseService<AppUser>
    {
        public bool CheckLogin(string userName, string password)
        {
            return Any(x => x.Name == userName && x.Password == password);
        }

        public bool CheckUserName(string userName)
        {
            return Any(x => x.Name == userName);
        }

        public bool CheckEmail(string email)
        {
            return Any(x => x.Email == email);
        }

        public AppUser FindByUserName(string userName)
        {
            return GetByDefault(x => x.Name == userName);
        }

    }
}
