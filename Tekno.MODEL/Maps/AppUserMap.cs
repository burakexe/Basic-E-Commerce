using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekno.CORE.Map;
using Tekno.MODEL.Entity;

namespace Tekno.MODEL.Maps
{
    public class AppUserMap:CoreMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("dbo.Users");
            Property(x => x.Address).IsOptional();
            Property(x => x.BirthDate).HasColumnType("datetime2").IsOptional();
            Property(x => x.Email).HasMaxLength(100).IsOptional();
            Property(x => x.ImagePath).HasMaxLength(255).IsOptional();
            Property(x => x.Password).HasMaxLength(20).IsRequired();
            Property(x => x.Name).IsRequired();
            Property(x => x.FirstName).IsRequired();
            Property(x => x.LastName).IsRequired();
            Property(x => x.PhoneNumber).IsOptional();

        }
    }
}
