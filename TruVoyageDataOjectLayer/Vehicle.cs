using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruVoyageDataOjectLayer
{
    public class Vehicle
    {
        public string VIN { get; set; }
        public string VehicleType { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public string Color { get; set; }
        public int Mileage { get; set; }
        public string EngineSize { get; set; }
        public int PassengerCapacity { get; set; }
        public bool Available { get; set; }
        public bool NeedsMaintenance { get; set; }
        public DateTime LastMaintenance { get; set; }
        public int MaintenacnePersonnelID { get; set; }
        public decimal PurchasePrice { get; set; }
    }
}
