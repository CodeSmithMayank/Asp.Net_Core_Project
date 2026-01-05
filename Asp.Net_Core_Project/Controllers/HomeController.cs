using System.Diagnostics;
using Asp.Net_Core_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Core_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        
        //Here we are injecting dependency
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            
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

        public string GetEmployeeDataMethod()
        {
            return _employeeRepository.GetEmployee(10).Name;
        }
    }
}
