using Microsoft.AspNetCore.Mvc;
using Shopping.Client.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Shopping.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IConfiguration configuration, IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _httpClient = httpClientFactory.CreateClient("ShoppingAPIClient");
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("api/v1/product");
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var productList = JsonSerializer.Deserialize<IEnumerable<Product>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(productList);
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
