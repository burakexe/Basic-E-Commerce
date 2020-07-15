using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using Tekno.CORE.Entity;
using Tekno.MODEL.Entity;
using Tekno.MODEL.Maps;

namespace Tekno.MODEL
{
    public class TeknoDB : DbContext
    {
        public TeknoDB()
        {
            Database.Connection.ConnectionString = "server=DESKTOP-OD0V8PN;database=TechDB;Trusted_Connection=True;";

        }


        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderPayment> OrderPayments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<UserAdress> UserAdresses { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new SubCategoryMap());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var modifierEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added).ToList();

            string identity = WindowsIdentity.GetCurrent().Name;
            string computerName = Environment.MachineName;
            DateTime dateTime = DateTime.Now;
            //todo: user eklenecek.
            int user = 1;
            string ip = "192.168.1.1";

            foreach (var item in modifierEntries)
            {
                var entity = item.Entity as CoreEntity;
                if (item != null)
                {
                    entity.CreatedADUserName = identity;
                    entity.CreatedComputerName = computerName;
                    entity.CreatedDate = dateTime;
                    entity.CreatedBy = user;
                    entity.CreatedIP = ip;
                }
                else if (item.State == EntityState.Modified)
                {
                    entity.ModifiedAdUserName = identity;
                    entity.ModifiedComputerName = computerName;
                    entity.ModifiedDate = dateTime;
                    entity.ModifiedBy = user;
                    entity.ModifiedIP = ip;
                }
            }
            return base.SaveChanges();
        }
    }
}