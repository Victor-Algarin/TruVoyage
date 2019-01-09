using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TruVoyageDataOjectLayer;
using TruVoyageLogicLayer;
using Microsoft.AspNetCore.Http;
using System.Data.Common;

namespace TruVoyageMVCLayer.Controllers
{
    public class VehicleController : Controller
    {
       
        IVehicleManager vicManager = new VehicleManager();

        // GET: Vehicle
        public ViewResult Index()
        {
            return View (vicManager.GetAvailableVehicles());
        }

        // GET: Vehcicle
        // Full Inventory is not customer facing
        public ActionResult FullVehicleInventory()
        {
            return View(vicManager.GetFullListOfVehicles());
        }

        // GET: Vehicle/Create
        public ActionResult AddNewVehicleToInventory()
        {
            return View();
        }

        // POST: Vehicle/Create
        [HttpPost]
        public ActionResult AddNewVehicleToInventory([Bind(include:"VIN, VehicleType, Make, Model, ModelYear, Color, Mileage, " +
            "EngineSize, PassengerCapacity, PurchasePrice")]Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                if (vicManager.AddNewVehicle(vehicle))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            return View(vehicle);            
        }

        // GET: Vehicle/UpdateVehicleMaintenanceStatus
        public ActionResult UpdateVehicleMaintenanceStatus(string id)
        {
            if (id==null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var vehicle = vicManager.GetFullListOfVehicles().Find(v => v.VIN == (string)id);
            if (vehicle == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return View(vehicle);

        }


        // POST: Vehicle/UpdateVehicleMaintenanceStatus
        [HttpPost]
        public ActionResult UpdateVehicleMaintenanceStatus([Bind("VIN, Mileage, Available, NeedsMaintenance, MaintenacnePersonnelID, LastMaintenance")]Vehicle newVehicle)
        {
            if (ModelState.IsValid)
            {
                var oldVehicle = vicManager.GetFullListOfVehicles().Find(v => v.VIN == (string)newVehicle.VIN);

                if (vicManager.UpdateMaintenanceRecords(oldVehicle, newVehicle))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            return View(newVehicle);            
        }
    }
}