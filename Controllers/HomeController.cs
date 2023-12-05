using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpPost("login")]
    public IActionResult Login(User newUser)
    {
        if (ModelState.IsValid)
        {
            HttpContext.Session.SetString("UserName", newUser.Name);
            HttpContext.Session.SetInt32("Number", 0);
            return View("DisplayButtons");
        }
        else
        {
            return View("Index");
        }
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return View("Index");
    }

    // [HttpGet("addone")]
    [HttpGet("modify/{type}")]
    public IActionResult Random(string type)
    {
        int? IntVariable = HttpContext.Session.GetInt32("Number");
        Random rand = new Random();
        if (type == "add")
        {
            int NewNumber = (int)IntVariable + rand.Next(1,10);
            HttpContext.Session.SetInt32("Number", NewNumber);
        }
        return View("DisplayButtons");
    }
    [HttpGet("modify/{type}/{number}")]
    public IActionResult Modify(string type, int number)
    {
        int? IntVariable = HttpContext.Session.GetInt32("Number");
        if (type == "add")
        {
            int NewNumber = (int)IntVariable + number;
            HttpContext.Session.SetInt32("Number", NewNumber);
        }
        if (type == "subtract")
        {
            int NewNumber = (int)IntVariable - number;
            HttpContext.Session.SetInt32("Number", NewNumber);
        }
        if (type == "multiply")
        {
            int NewNumber = (int)IntVariable * number;
            HttpContext.Session.SetInt32("Number", NewNumber);
        }
        return View("DisplayButtons");

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
}
