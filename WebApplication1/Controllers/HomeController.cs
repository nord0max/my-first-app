using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        try
        {
            ViewBag.message = "Моя первая Docker программа";
            using (ApplicationContext db = new ApplicationContext())
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