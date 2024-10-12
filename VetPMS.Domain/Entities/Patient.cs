using System.ComponentModel.DataAnnotations.Schema;

namespace VetPMS.Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Colour { get; set; }
        public int BreedId {  get; set; }
        public Breed? Breed {  get; set; }
        public int OwnerId { get; set; }
        public Owner? Owner { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool isActive { get; set; }

        private Patient() { }

        public Patient(string name,int breedId, DateTime dob,string colour, int ownerId,int clinicId)=>
            (Name, BreedId, DOB,Colour,OwnerId, CreatedDate,ClinicId)=(name,breedId,dob,colour,ownerId,DateTime.Now,clinicId);


        public void PatientUpdateDetails(string name, int breedId, DateTime dob, string colour, int ownerId)
        {
            Name = name;
            BreedId = breedId;
            DOB = dob;
            Colour = colour;
            OwnerId = ownerId;
            UpdatedDate = DateTime.Now;
        }

    }
}
