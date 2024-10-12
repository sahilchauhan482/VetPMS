namespace VetPMS.Application.Queries.Medicines.GetMedicine
{
    public class GetMedicineQuery:IRequest<GetMedicineQueryResponse>
    {
        public int MedicineId { get; set; }
        public int ClinicId { get; set; }
    }
}
