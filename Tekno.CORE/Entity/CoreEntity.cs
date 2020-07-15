using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using Tekno.CORE.Entity.Enum;

namespace Tekno.CORE.Entity
{
    public class CoreEntity : IEntity<Guid> // Globally Unique IDentifier - Benzersiz Tanımlayıcı,
    {
        public CoreEntity()
        {
            this.Status = Status.Active;
            this.CreatedDate = DateTime.Now;
            this.CreatedADUserName = WindowsIdentity.GetCurrent().Name;
            this.CreatedComputerName = Environment.MachineName;
            this.CreatedIP = "192.168.1.1";
            this.CreatedBy = 1;
        }

        public Guid ID { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedComputerName { get; set; }
        public string CreatedIP { get; set; }
        public string CreatedADUserName { get; set; }
        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public string ModifiedComputerName { get; set; }
        public string ModifiedIP { get; set; }
        public string ModifiedAdUserName { get; set; }
        public int? ModifiedBy { get; set; }


    }
}