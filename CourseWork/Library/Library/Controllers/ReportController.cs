using Library.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class ReportController : Controller
    {
        private readonly ISubscriptionCardService _subscriptionCardService;

        public ReportController(ISubscriptionCardService subscriptionCardService) {
            _subscriptionCardService = subscriptionCardService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DownloadReport()
        {
            var file = _subscriptionCardService.GenerateReport();
            using (var stream = new MemoryStream())
            {
                file.SaveAs(stream);
                var content = stream.ToArray();

                file.Dispose();
                return File(content,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "Report.xlsx");
            }
        }

    }
}
