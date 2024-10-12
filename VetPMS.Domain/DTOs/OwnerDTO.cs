using VetPMS.Domain.Entities;

namespace VetPMS.Domain.DTOs
{
    public class OwnerDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }


        public static explicit operator OwnerDto(Owner owner)
        {
            return new OwnerDto
            {
                Id = owner.Id,
                Name = owner.Name,
                Address = owner.Address,
                PhoneNumber = owner.PhoneNumber,
                Email = owner.Email
            };
        }
    }

   
}
