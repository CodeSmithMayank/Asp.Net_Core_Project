using System.Diagnostics;
using Asp.Net_Core_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Core_Project.Controllers
{
    public class HomeController : Controller
    {
        //This HomeController is not creating an instance of IEmployeeRepository using new keyword


        private readonly IEmployeeRepository _employeeRepository;

        //Here we are injecting dependency
        // We are inject IEmployeeRepository in HomeController class using its constructor it's known as contructor injection
        // HomeController have a dependency on IEmployeeRepository service , so this service is injected into HomeController using HomeController Constructor
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            //This we are not doing because it completely depends on this class , may be later on we have multiple class then it will an issue
            //_employeeRepository = new MockEmployeeRepository();


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

        public ViewResult GetEmployeeDataMethod()
        {
            Employee obj = _employeeRepository.GetEmployee(10);
            ViewData["EmpData"] = obj;
            ViewData["pagetitle"] = "Employee Details";
            //this we are using because it's provided by base Controller class which is availiable for this HomeController
            return View(obj);

            //If We have inside Views folder only & of same methodname
            //return View("Test");

            //If we have a view in some other different folder then we have to pass path inside view ( return View("MyViews/myview.cshtml"); ) or ( return View("~/MyViews/myview.cshtml"); ) or ( return View("../MyViews/myview.cshtml"); )
            // This is an absolute file path 
            //return View("MyViews/myview.cshtml");

            //return View("../MyViews/myview.cshtml"); ( Here this .means take up at one level in heirarchy ) ( no of times u have to mentioned . , no of levels u wanna up )

        }
    }
}
