using System.Net.Http.Json;
using VetPMS.Constants;
using VetPMS.Models;

namespace VetPMS.Services
{
    public class AppointmentService
    {  

        private readonly HttpClient _httpClient;

        public AppointmentService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(_HttpClient.Client);
        }

        public async Task<List<AppointmentDTO>> GetAllAppointments()
        {
            var response = await _httpClient.GetFromJsonAsync<AppointmentResponse>(ApiRoutes.Appointment.GetAll);
            var appointments =  response?.appointmentDTO ?? new List<AppointmentDTO>();

            var appointmentList = appointments.Select(appointment => new AppointmentDTO
            {
                Id = appointment.Id,
                Start = appointment.Start,
                BreedId = appointment.BreedId,
                End = appointment.End,
                Title = appointment.Title,
                Comments = appointment.Comments,
                Email  = appointment.Email,
                Phone = appointment.Phone,
                OwnerId = appointment.OwnerId,
                OwnerName = appointment.Owner!.Name,
                BreedName = appointment.Breed!.Name
            }).ToList();

            return appointmentList;
        }

        public async Task AddAppointment(AppointmentDTO appointment)
        {
            try
            {                
                var response = await _httpClient.PostAsJsonAsync(ApiRoutes.Appointment.Create, appointment);

                if (!response.IsSuccessStatusCode)
                {
                    var statusCode = response.StatusCode;
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var dynamicMessage = $"Error {statusCode}: {responseContent}";
                    throw new ApplicationException(dynamicMessage);
                }
            }
            catch (HttpRequestException httpEx)
            {

                var errorMessage = $"A network error occurred: {httpEx.Message}. Please check your connection and try again.";
                throw new ApplicationException(errorMessage, httpEx);
            }
            catch (Exception ex)
            {

                var errorMessage = $"An unexpected error occurred: {ex.Message}. Please try again later.";
                throw new ApplicationException(errorMessage, ex);
            }
        }

        public async Task<AppointmentDTO> GetAppointmentById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{ApiRoutes.Appointment.GetById}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var getAppointmentResponse = await response.Content.ReadFromJsonAsync<GetAppointmentResponse>();
                    return getAppointmentResponse?.appointmentDTO ?? throw new Exception("Appointment not found");
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Failed to retrieve Appointment: {response.ReasonPhrase}, Content: {content}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching Appointment details: {ex.Message}");
            }
        }

        public async Task UpdateAppointment(AppointmentDTO appointment)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{ApiRoutes.Appointment.Update}/{appointment.Id}", appointment);
                if (!response.IsSuccessStatusCode)
                {
                    var statusCode = response.StatusCode;
                    var responseContent = await response.Content.ReadAsStringAsync();


                    var dynamicMessage = $"Error {statusCode}: {responseContent}";

                    throw new ApplicationException(dynamicMessage);
                }
            }
            catch (HttpRequestException httpEx)
            {

                var errorMessage = $"A network error occurred: {httpEx.Message}. Please check your connection and try again.";
                throw new ApplicationException(errorMessage, httpEx);
            }
            catch (Exception ex)
            {

                var errorMessage = $"An unexpected error occurred: {ex.Message}. Please try again later.";
                throw new ApplicationException(errorMessage, ex);
            }

        }


        public async Task DeleteAppointment(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiRoutes.Appointment.Delete}/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    var statusCode = response.StatusCode;
                    var responseContent = await response.Content.ReadAsStringAsync();
                    throw new ApplicationException($"Error {statusCode}: {responseContent}");
                }
            }
            catch (HttpRequestException httpEx)
            {
                throw new ApplicationException($"A network error occurred: {httpEx.Message}. Please check your connection and try again.", httpEx);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An unexpected error occurred: {ex.Message}. Please try again later.", ex);
            }
        }


    }
}
