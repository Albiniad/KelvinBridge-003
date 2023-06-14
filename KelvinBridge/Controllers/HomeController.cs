using KelvinBridge.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using KelvinBridge.Repository;

namespace KelvinBridge.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<BridgeModel> _variantsRepository;

        public HomeController()
        {
            _variantsRepository = new VariantsRepository();
        }

        public IActionResult Index()
        {
            ViewBag.Variants = _variantsRepository.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult CalculateVoltage(string Rx, string R0x)
        {
            var voltage = 0d;

            if (double.TryParse(Rx?.Replace(".", ","), out var _Rx) &&
                double.TryParse(R0x?.Replace(".", ","), out var _R0x)) voltage = (_R0x - _Rx) * 1;

            return Json(voltage);
        }

        [HttpPost]
        public IActionResult CalculateK(string Rx, string R0x)
        {
            var k = 0d;

            if (double.TryParse(Rx?.Replace(".", ","), out var _Rx) &&
                double.TryParse(R0x?.Replace(".", ","), out var _R0x)) k = (_R0x - _Rx) / _R0x * 100;

            return Json(Math.Abs(k) < 5);
        }

        [HttpPost]
        public IActionResult CalculateResult(string Ra, string RM, string RN, string Rn, string Rm)
        {
            Random random = new Random();
            double randomNumber = random.NextDouble() / 10;
            double rx = 0d;

            if (double.TryParse(Ra.Replace(".", ","), out var _Ra) &&
                double.TryParse(RM.Replace(".", ","), out var _RM) &&
                double.TryParse(RN.Replace(".", ","), out var _RN))
            {
                rx = _Ra * (_RN / _RM) * (1 + randomNumber);
            }

            return Json(rx);
        }
    }
}