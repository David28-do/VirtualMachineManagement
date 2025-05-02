using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using VirtualMachineManagement.WebUl.Contracts;
using VirtualMachineManagement.WebUl.Models;
using VirtualMachineManagement.WebUl.Response;

namespace VirtualMachineManagement.WebUl.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoginServiceHelper _loginServiceHelper;
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(ILogger<HomeController> logger, ILoginServiceHelper loginServiceHelper, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _loginServiceHelper = loginServiceHelper;
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginInputModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var client = _httpClientFactory.CreateClient();

                var content = new StringContent(
                    JsonSerializer.Serialize(model),
                    Encoding.UTF8,
                    "application/json");

                var response = await client.PostAsync("https://localhost:7161/api/token", content);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var result = JsonSerializer.Deserialize<AuthResponse>(json,options);

                    // Guardar token en sesión o cookie, etc.
                    HttpContext.Session.SetString("Token", result.Token);

                    return RedirectToAction("Index", "VirtualMachine");
                }

                ViewBag.Error = "Credenciales inválidas";
                return View(model);

            }
            catch (Exception ex)
            {
                return View(model);
            }
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
