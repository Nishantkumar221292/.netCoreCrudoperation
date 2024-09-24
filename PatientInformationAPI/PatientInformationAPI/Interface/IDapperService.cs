
using PatientInformationAPI.Models;

namespace PatientInformationAPI.Interface
{
    public interface IDapperService
    {
            Task<List<PatientInformation>> GetAll();
            Task<PatientInformation> GetTaskById(int idno);
            Task<string> CreateTask(PatientInformation patientInformation);
            Task<string> UpdateTask(PatientInformation patientInformation);
            Task<string> DeleteTask(int idno);
        }
    }