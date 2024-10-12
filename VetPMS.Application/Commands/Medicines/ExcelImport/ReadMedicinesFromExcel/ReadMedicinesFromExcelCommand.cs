using Microsoft.AspNetCore.Http;
using VetPMS.Application.Commands.Medicines.CreateMedicine;

namespace VetPMS.Application.Commands.Medicines.ExcelImport.ReadMedicinesFromExcel
{
    public class ReadMedicinesFromExcelCommand:IRequest<List<CreateMedicineCommand>>
    {
        public IFormFile ExcelFile { get; }

        public ReadMedicinesFromExcelCommand(IFormFile excelFile)
        {
            ExcelFile = excelFile;
        }
    }
}
