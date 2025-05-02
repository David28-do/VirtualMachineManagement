using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using VirtualMachineManagement.WebUl.Models;
using VirtualMachineManagement.WebUl.Response;

namespace VirtualMachineManagement.WebUl.Controllers
{
    public class VirtualMachineController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public VirtualMachineController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("Token");
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Login");
            }
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync("https://localhost:7161/api/virtualMachine");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var result = JsonSerializer.Deserialize<ApiResponse<IEnumerable<VirtualMachine>>>(json, options);
                var listaVms = result?.Data.ToList() ?? new List<VirtualMachine>();

                return View(listaVms);
            }

            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                if (id <= 0)
                    return RedirectToAction("Index", "VirtualMachine");

                var token = HttpContext.Session.GetString("Token");
                if (string.IsNullOrEmpty(token))
                {
                    // Opcional: redirigir a login si no hay token
                    return RedirectToAction("Index", "Login");
                }
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


                var response = await client.GetAsync($"https://localhost:7161/api/virtualMachine/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var result = JsonSerializer.Deserialize<ApiResponse<VirtualMachine>>(json, options);
                    var listaVms = result?.Data ?? new VirtualMachine();
                    return View(listaVms);
                }

                return View("Index", "VirtualMachine");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "VirtualMachine");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VirtualMachine model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var token = HttpContext.Session.GetString("Token");
                if (string.IsNullOrEmpty(token))
                {
                    // Opcional: redirigir a login si no hay token
                    return RedirectToAction("Index", "Login");
                }
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var content = new StringContent(
                    JsonSerializer.Serialize(model),
                    Encoding.UTF8,
                    "application/json");

                var response = await client.PostAsync("https://localhost:7161/api/virtualMachine", content);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var result = JsonSerializer.Deserialize<ApiResponse<VirtualMachine>>(json, options);

                    return RedirectToAction("Index", "VirtualMachine");
                }

                ViewBag.Error = $"El rol administrador no tiene los permisos para crear VM";
                return View(model);

            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(VirtualMachine model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var token = HttpContext.Session.GetString("Token");
                if (string.IsNullOrEmpty(token))
                {
                    // Opcional: redirigir a login si no hay token
                    return RedirectToAction("Index", "Login");
                }
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var content = new StringContent(
                    JsonSerializer.Serialize(model),
                    Encoding.UTF8,
                    "application/json");

                var response = await client.PutAsync($"https://localhost:7161/api/virtualMachine/{model.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var result = JsonSerializer.Deserialize<ApiResponse<bool>>(json, options);

                    return RedirectToAction("Index", "VirtualMachine");
                }

                ViewBag.Error = $"El rol administrador no tiene los permisos para crear VM";
                return View(model);

            }
            catch (Exception ex)
            {
                return View(model);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return RedirectToAction("Index", "VirtualMachine");

                var token = HttpContext.Session.GetString("Token");
                if (string.IsNullOrEmpty(token))
                {
                    // Opcional: redirigir a login si no hay token
                    return RedirectToAction("Index", "Login");
                }
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

               
                var response = await client.DeleteAsync($"https://localhost:7161/api/virtualMachine/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var result = JsonSerializer.Deserialize<ApiResponse<bool>>(json, options);
                }

                return RedirectToAction("Index", "VirtualMachine");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "VirtualMachine");
            }
        }
    }
}