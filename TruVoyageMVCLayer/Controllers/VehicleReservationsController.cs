using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TruVoyageMVCLayer.Controllers
{
    public class VehicleReservationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}