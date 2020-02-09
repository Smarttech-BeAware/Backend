using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeAware.Models
{
    public interface IDataRepository
    {
        void AddWhatsAppMessage(Device device, string message, string email);
        void AddMessengerMessage(Device device, string message, string email);
        void SignUp(User user);
        User SignIn(User user);
        void AddReport(FiledReport report);
        void AddValidationRequest(ValidationRequest request);
        void UpdateLocation(Device device, Location location, string email);
        void AddDevice(string email, string name);
        CrimeData GetCrimeData(string sortBy);
    }
}
