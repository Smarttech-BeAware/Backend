using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace BeAware.Models
{
    public class SqlDataRepository : IDataRepository
    {
        private readonly AppDbContext _context;

        public SqlDataRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddDevice(string email, string name)
        {
            var myUser = _context.Users.Find(email);
            Device device = new Device();
            device.Name = name;
            myUser.Devices.Add(device);
            _context.SaveChanges();
        }

        public void AddMessengerMessage(Device device, string message, string email)
        {
            var user = _context.Users.Find(email);
            var myDevice = user.Devices.First(x => x.Name == device.Name);
            if(myDevice != null)
            {
                myDevice.Messenger += message;
            }
            _context.SaveChanges();
        }

        public void AddReport(FiledReport report)
        {
            _context.Reports.Add(report);
            _context.SaveChanges();
        }

        public void AddValidationRequest(ValidationRequest request)
        {
            _context.Requests.Add(request);
            _context.SaveChanges();
        }

        public void AddWhatsAppMessage(Device device, string message, string email)
        {
            var user = _context.Users.Find(email);
            var myDevice = user.Devices.First(x => x.Name == device.Name);
            if (myDevice != null)
            {
                myDevice.WhatsApp += message;
            }
            _context.SaveChanges();
        }

        public CrimeData GetCrimeData(string sortBy)
        {
            CrimeData data = new CrimeData();
            if(sortBy == "crime")
            {
                data.DrugTrafficking = _context.Reports.Where(x => x.Crime == "Drug Trafficking").Count();
                data.HumanTrafficking = _context.Reports.Where(x => x.Crime == "Human Trafficking").Count();
                data.IllegalTrade = _context.Reports.Where(x => x.Crime == "Illegal Trade").Count();
                data.Kidnapping = _context.Reports.Where(x => x.Crime == "Kidnapping").Count();
                data.SexualHarassment = _context.Reports.Where(x => x.Crime == "Sexual Harassment").Count();
                data.WildlifePoaching = _context.Reports.Where(x => x.Crime == "Wildlife Poaching").Count();
                data.Others = _context.Reports.Where(x => x.Crime == "Others").Count();
            }
            else
            {
                data.NorthCentral = _context.Reports.Where(x => x.Location == "North-Central").Count();
                data.NorthWest = _context.Reports.Where(x => x.Location == "North-West").Count();
                data.NorthEast = _context.Reports.Where(x => x.Location == "North-East").Count();
                data.SouthSouth = _context.Reports.Where(x => x.Location == "South-South").Count();
                data.SouthEast = _context.Reports.Where(x => x.Location == "South-East").Count();
                data.SouthWest = _context.Reports.Where(x => x.Location == "South-West").Count();
            }
            return data;
        }

        public User SignIn(User user)
        {
            var myUser = _context.Users.Find(user.Email);
            if(myUser != null)
            {
                if (myUser.Password == user.Password)
                {
                    return myUser;
                }
            }
            return myUser;
        }

        public void SignUp(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateLocation(Device device, Location location, string email)
        {
            var user = _context.Users.Find(email);
            if(user != null)
            {
                var myDevice = user.Devices.First(x => x.Name == device.Name);
                if(myDevice != null)
                {
                    myDevice.Map.Add(location);
                    _context.SaveChanges();
                }
            }
        }
    }
}
