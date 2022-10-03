using Dotnet31.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;


namespace Dotnet31.Controllers
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
            IndexViewModel indexViewModel = new IndexViewModel();
            indexViewModel.DateUtc = new DateTime(ticks: 637802866463298955, kind: DateTimeKind.Utc);
            indexViewModel.DateUtcString = JsonSerializer.Serialize(indexViewModel.DateUtc);

            indexViewModel.DateUnspecified = new DateTime(ticks: 637802866463298955, kind: DateTimeKind.Unspecified);
            indexViewModel.DateUnspecifiedString = JsonSerializer.Serialize(indexViewModel.DateUnspecified);

            indexViewModel.DateLocal = new DateTime(ticks: 637802866463298955, kind: DateTimeKind.Local);
            indexViewModel.DateLocalString = JsonSerializer.Serialize(indexViewModel.DateLocal);

            return View("Index", indexViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CheckDate(DateTime date)
        {
            CheckDateViewModel checkDateViewModel = new CheckDateViewModel();
            checkDateViewModel.DateTimeKindString = date.Date.Kind.ToString();
            checkDateViewModel.DateTimeKind = date.Date.Kind;
            checkDateViewModel.Date = date;
            checkDateViewModel.DateString = JsonSerializer.Serialize(date);
            return View("CheckDate", checkDateViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    public class IndexViewModel
    {
        public DateTime DateUtc { get; set; }
        public string DateUtcString { get; set; }

        public DateTime DateUnspecified { get; set; }
        public string DateUnspecifiedString { get; set; }

        public DateTime DateLocal { get; set; }
        public string DateLocalString { get; set; }
    }

    public class CheckDateViewModel
    {
        public DateTime Date { get; set; }
        public string DateString { get; set; }
        public DateTimeKind DateTimeKind { get; set; }
        public string DateTimeKindString { get; set; }
    }
}
