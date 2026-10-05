using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using webapppélda.Models;
using WebAppPelda.Services;

namespace webapppélda.Controllers
{
    public class HomeController : Controller
    {
        

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Vasarlo(int id)
        {
            Customer customer = new VasarloService().GetById(id);
            return View(customer);
        }
        public IActionResult Sajat()
        {
            List<Customer> customers = new VasarloService().GetAllCustomer();
            return View(customers);
        }

        //CreateVasarlo Dolgai

        [HttpGet]
        public IActionResult CreateCustomer()
        {
            Customer uresVasarlo = new Customer();
            return View(uresVasarlo);
        }

        [HttpPost]

        public IActionResult CreateCustomer(Customer customer)
        {
            string result = new VasarloService().PostCustomer(customer);
            TempData["SuccessMessage"] = result;
            return RedirectToAction(nameof(CreateCustomer));
        }

        public IActionResult PutCustomer(int? id)
        {
            Customer vasarlo = new Customer();
            if (id.HasValue)
            {
                vasarlo = new VasarloService().GetById(id.Value);
            }
            return View(vasarlo);
        }
        [HttpPost]
        public IActionResult PutCustomer(Customer customer)
        {
            string result2 = new VasarloService().PutCustomer(customer);
            TempData["Success message"] = result2;
            return RedirectToAction(nameof(PutCustomer), new { id = customer.Id });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
