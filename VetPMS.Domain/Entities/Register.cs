
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetPMS.Domain.Entities
{
    public class Register:IdentityUser
    {
        public required string FullName { get; set; }
        public required string Gender { get; set; }
        public DateTime LastLoginDate { get; set; }
        [ForeignKey(nameof(Clinic))]
        public int? ClinicId { get; set; }
        public Clinic? Clinic { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDateAndTime { get; set; }
        public DateTime? UpdatedDateAndTime { get; set; }
        public DateTime? DeletedDateAndTime { get; set; }
    }
}
