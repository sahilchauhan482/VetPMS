using System.ComponentModel.DataAnnotations.Schema;

namespace VetPMS.Domain.Entities
{
    public class Breed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool isActive { get; set; }

        public Breed(string name, string origin,int clinicId) =>
            (Name, Origin,CreatedDate,ClinicId) = (name, origin,DateTime.Now,clinicId);

       
        public void UpdateBreedDetails(string name, string origin)
        {
            Name = name;
            Origin = origin;
            UpdatedDate = DateTime.Now;
        }
    }
}
