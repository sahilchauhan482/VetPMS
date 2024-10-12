namespace VetPMS.Application.Queries.Medicines.GetAllMedicines
{
    public class GetAllMedicinesQuery:IRequest<GetAllMedicinesQueryResponse>
    {
        public int ClinicId { get; set; }
    }
}
