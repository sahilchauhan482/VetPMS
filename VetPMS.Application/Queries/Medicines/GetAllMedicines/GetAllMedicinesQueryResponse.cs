using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Queries.Medicines.GetAllMedicines
{
    public record GetAllMedicinesQueryResponse(List<MedicineDto> MedicineDTO);
   
}
