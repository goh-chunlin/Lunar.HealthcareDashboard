using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using healthcare_dashboard.Models;
using healthcare_dashboard.Services;

namespace healthcare_dashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAzureApiForFhirService _azureApiForFhirService;  

        public HomeController(IAzureApiForFhirService azureApiForFhirService)
        {
            _azureApiForFhirService = azureApiForFhirService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _azureApiForFhirService.GetAllPatientsAsync());
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
    }
}
