using System.ComponentModel.DataAnnotations.Schema;

namespace VetPMS.Domain.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public  string Address { get; set; }
        public  string PhoneNumber { get; set; }
        public  string Email { get; set; }
        public int ?ClinicId { get; set; }
        public Clinic Clinic { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool isActive { get; set; }

        public Owner(string name, string address, string phoneNumber, string email,int? clinicId) =>
             (Name, Address, PhoneNumber, Email,CreatedDate,ClinicId) = (name, address, phoneNumber, email,DateTime.Now,clinicId);

        public void OwnerUpdateDetails(string name, string address, string phoneNumber, string email)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            UpdatedDate = DateTime.Now;
        }

    }
}

