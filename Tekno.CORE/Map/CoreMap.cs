using System.Data.Entity.ModelConfiguration;
using Tekno.CORE.Entity;

namespace Tekno.CORE.Map
{
    public class CoreMap<T> : EntityTypeConfiguration<T> where T : CoreEntity
    {
        public CoreMap()
        {
            Property(x => x.ID).HasColumnName("ID").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Status).HasColumnName("Status").IsOptional();
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsOptional();
            Property(x => x.CreatedComputerName).HasColumnName("CreatedComputerName");
            Property(x => x.CreatedIP).HasColumnName("CreatedIP");
            Property(x => x.CreatedADUserName).HasColumnName("CreatorUserName");
            Property(x => x.CreatedBy).HasColumnName("Createdby");
            Property(x => x.CreatedComputerName).HasColumnName("CreatedComputerName").IsOptional();
            Property(x => x.CreatedADUserName).HasColumnName("CreatedADUserName").IsOptional();
            Property(x => x.CreatedBy).HasColumnName("CreateBy");
            Property(x => x.ModifiedIP).HasColumnName("ModifiedIP");
            Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").IsOptional();
            Property(x => x.ModifiedComputerName).HasColumnName("ModifiedComputerName").IsOptional();
            Property(x => x.ModifiedIP).HasColumnName("ModifiedIP").IsOptional();
            Property(x => x.ModifiedAdUserName).HasColumnName("ModifierUserName").IsOptional();
            Property(x => x.ModifiedBy).HasColumnName("Modifiedby").IsOptional();
        }
    }
}