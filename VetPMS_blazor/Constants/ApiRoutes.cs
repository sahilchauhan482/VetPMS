namespace VetPMS.Constants
{
    public class ApiRoutes
    {
        public static class Patients
        {
            public const string GetAll = "api/Patient/getAllPatients";
            public const string GetById = "api/Patient/getPatientById";
            public const string Create = "api/Patient/createPatient";
            public const string Update = "api/Patient/updatePatient";
            public const string Delete = "api/Patient/deletePatient";
        }

        public static class Owners
        {
            public const string GetAll = "api/Owner/GetAll";
            public const string Create = "api/Owner/CreateOwner";
            public const string Update = "api/Owner/UpdateOwner";
            public const string Delete = "api/Owner/DeleteOwner";
            public const string GetById = "api/Owner";
            public const string EmailExist = "api/Owner/CheckEmailExists?Email";
            public const string PhoneExist = "api/Owner/CheckPhoneNumberExists?phoneNumber";

        }

        public static class Breeds
        {
            public const string GetAll = "api/Breed/GetAll";

        }

        public static class Registers
        {
            public const string Create = "api/Register/CreateUser";
            public const string GetAll = "api/Register/GetAllUsers";
            public const string EmailExist = "api/Register/CheckEmailExists?Email";
            public const string PhoneExist = "api/Register/CheckPhoneNumberExists?phoneNumber";
        }

        public static class Authentication
        {
            public const string Login = "api/Account/Login";
            public const string Reset = "api/Account/GenerateResetPasswordToken";
            public const string NewPassword = "api/Account/ResetPassword";
        }
        public static class Medicines
        {
            public const string GetAll = "api/Medicine/getAllMedicines";
            public const string Create = "api/Medicine/createMedicine";
            public const string Update = "api/Medicine/updateMedicine";
            public const string Delete = "api/Medicine/deleteMedicine";
            public const string GetById = "api/Medicine/getMedicine";
            public const string ImportExcel = "/api/Medicine/bulkCreateFromExcel";

        }
        public static class Appointment
        {
            public const string GetAll = "api/Appointment/GetAll";
            public const string Create = "api/Appointment/CreateAppointment";
            public const string Update = "api/Appointment/UpdateAppointment";
            public const string Delete = "api/Appointment/DeleteAppointment";
            public const string GetById = "api/Appointment";

        }

        public static class Clinic
        {
            public const string GetAll = "api/Clinic/GetAll";
            public const string Create = "api/Clinic/CreateClinic";
            public const string Update = "api/Clinic/UpdateClinic";
            public const string Delete = "api/Clinic/DeleteClinic";
            public const string GetById = "api/Clinic";

        }
    }
}
