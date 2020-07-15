using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekno.CORE.Entity;

namespace Tekno.MODEL.Entity
{

    public enum Role
    {
        none,
        member,
        admin,
        superuser
    }

    public class AppUser:CoreEntity
    {

        public AppUser()
        {
            IsActive = false;
        }



        [Required(ErrorMessage ="Lütfen Adınızı Yazın")]
        [StringLength(50, MinimumLength =3, ErrorMessage ="Adınızı 3-50 karakter arasında girebilirsiniz.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadınızı Yazın")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Soyadınızı 3-50 karakter arasında girebilirsiniz.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen E-Posta Adresinizi yazın")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$")]
        [EmailAddress(ErrorMessage = "E-Posta adresi hatalı")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen şifre yazın")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password")]

        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Lütfen 11 haneli TC Kimlik Numaraınızı Girin")]
        public int TCKN { get; set; }

        [Required(ErrorMessage = "Employee Address is required")]
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public DateTime? BirthDate { get; set; }
        public Guid ActivationCode { get; set; }
        public bool IsActive { get; set; }
        public Role Role { get; set; }
        public virtual List<Order> Orders { get; set; }

        //public virtual IEnumerable<UserAdress> UserAdress { get; set; }
    }
}
