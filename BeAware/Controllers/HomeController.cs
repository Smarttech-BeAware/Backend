using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BeAware.Models;
using System.Text.Json;

namespace BeAware.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataRepository _dataRepository;

        public HomeController(ILogger<HomeController> logger, IDataRepository dataRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //APIs
        [HttpGet]
        [Route("{controller}/getcrimedata")]
        public IActionResult GetCrimeData([FromQuery]string sortmethod)
        {
            var crimeData = _dataRepository.GetCrimeData(sortmethod);
            return Json(crimeData);
        }

        [HttpPost]
        [Route("{controller}/adddevice")]
        public void AddDevice([FromQuery] string email, [FromQuery] string name)
        {
            _dataRepository.AddDevice(email, name);
        }

        [HttpPost]
        [Route("{controller}/signin")]
        public IActionResult SignIn([FromQuery] string email, [FromQuery] string password)
        {
            User user = new User()
            {
                Email = email,
                Password = password
            };
            return Json(_dataRepository.SignIn(user));
        }

        [HttpPost]
        [Route("{controller}/signup")]
        public void SignUp([FromQuery] string name, [FromQuery]string email, [FromQuery]string password)
        {
            User user = new User()
            {
                Name = name,
                Email = email,
                Password = password
            };
            _dataRepository.SignUp(user);
        }

        [HttpPost]
        [Route("{controller}/addrequest")]
        public void AddRequest([FromBody] string reportJson)
        {
            var report = JsonSerializer.Deserialize<FiledReport>(reportJson);
            _dataRepository.AddReport(report);
        }

        [HttpPost]
        [Route("{controller}/addplatformvalidation")]
        public void AddPlatformValidation([FromBody] string requestJson)
        {
            var request = JsonSerializer.Deserialize<ValidationRequest>(requestJson);
            _dataRepository.AddValidationRequest(request);
        }

        [HttpPost]
        [Route("{controller}/updatelocation")]
        public void UpdateLocation([FromQuery] string name, [FromQuery] string email, [FromBody] string locationJson )
        {
            Device device = new Device();
            device.Name = name;
            Location location = JsonSerializer.Deserialize<Location>(locationJson);

            _dataRepository.UpdateLocation(device, location, email);

        }

        [HttpPost]
        [Route("{controller}/addwhatsappmessage")]
        public void AddWhatsAppMessage([FromQuery] string name, [FromQuery] string email, [FromQuery] string message)
        {
            Device device = new Device();
            device.Name = name;
            _dataRepository.AddWhatsAppMessage(device, message, email);
        }

        [HttpPost]
        [Route("{controller}/addmessengermessage")]
        public void AddMessengerMessage([FromQuery] string name, [FromQuery] string email, [FromQuery] string message)
        {
            Device device = new Device();
            device.Name = name;
            _dataRepository.AddMessengerMessage(device, message, email);
        }

        [HttpGet]
        [Route("{controller}/pushnotif")]
        public void PushNotificationToAll()
        {

        }

        [HttpGet]
        [Route("{controller}/sendemail")]
        public void SendEmail([FromQuery] string victimOf, [FromQuery] string details)
        {
            string message = $"Your ward might be a victim of {victimOf}, kindly inspect his/her {details} data as" +
                $" soom as possible";
        }
    }
}
