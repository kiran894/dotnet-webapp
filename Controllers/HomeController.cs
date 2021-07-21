using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetGrafana.Models;
using Prometheus;




namespace dotnetGrafana.Controllers
{
   
    
    public class HomeController : Controller
    {
        Counter counter = Metrics.CreateCounter("my_counter", "index page counter");
        
#pragma warning disable CA1416 // Validate platform compatibility
        System.Diagnostics.PerformanceCounter cpuUsage = new System.Diagnostics.PerformanceCounter();
#pragma warning restore CA1416 // Validate platform compatibility
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
         
     


        public IActionResult Index()
        {
            counter.Inc();
              
               
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
}
