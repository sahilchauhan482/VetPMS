namespace VetPMS.Domain.Entities
{
    public class Clinic
    {
        public int Id { get; set; }
        public string ClinicName { get; set; }
        public string ClinicEmail { get; set; }
        public string ClinicPhone { get; set; }
        public string ClinicAddress { get; set; }
        public DateTime EstablishedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Owner> Owners { get; set; }
        public ICollection<Breed> Breeds { get; set; }

        public Clinic(
            string clinicName, string clinicEmail, string clinicPhone, string clinicAddress,
            DateTime establishedDate) =>
            (ClinicName, ClinicEmail, ClinicPhone, ClinicAddress, EstablishedDate, CreatedDate) =
            (clinicName, clinicEmail, clinicPhone, clinicAddress, establishedDate, DateTime.Now);

        public void UpdateClinicDetails(
            string clinicName, string clinicEmail, string clinicPhone, string clinicAddress,
            DateTime establishedDate)
        {
            ClinicName = clinicName;
            ClinicEmail = clinicEmail;
            ClinicPhone = clinicPhone;
            ClinicAddress = clinicAddress;
            EstablishedDate = establishedDate;
            UpdatedDate = DateTime.Now;
        }
    }
}
