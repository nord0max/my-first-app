using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration _config;

    public HomeController(ILogger<HomeController> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }

    public IActionResult Index()
    {
        try
        {
            ViewBag.message = "Моя первая Docker программа";
            using (ApplicationContext db = new ApplicationContext(_config.GetValue<string>("connectionString")))
            {
                var brand = db.Brands.FirstOrDefault();
                ViewBag.Brand = brand.Name;
            }
        }
        catch (Exception e)
        {
            ViewBag.Brand = e.Message;
        }
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
}