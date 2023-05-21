using System.Diagnostics;
using Domain.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBootRepository _repository;

    public HomeController(ILogger<HomeController> logger, IBootRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }
    [Authorize]
    public IActionResult Index()
    {
        try
        {
            ViewBag.message = "Моя первая Docker программа";

            var brand = _repository.GetFullBoots();
            ViewBag.Brand = brand.FirstOrDefault()?.BrandName ?? "Not found";

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