using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    //Bu entityleri Concrete altına aldığımız gibi IEntity ve IDto yı Abstract diye klasörleyebilirz

    public class User:IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; } // Bu alanlar buyte array olarak tutulur db de binary(500) olarak belirttiğimiz için
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
    }
}
