using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruVoyageDataOjectLayer;

namespace TruVoyageLogicLayer
{
    public interface IVehicleManager
    {
        System.Collections.Generic.List<Vehicle> GetFullListOfVehicles();
        System.Collections.Generic.List<Vehicle> GetAvailableVehicles();
        bool AddNewVehicle(Vehicle newVehicle);
        bool UpdateMaintenanceRecords(Vehicle oldVehicleRecords, Vehicle newVehicleRecords);
    }
}
