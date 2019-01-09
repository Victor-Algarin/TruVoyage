using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruVoyageDataAccessLayer;
using TruVoyageDataOjectLayer;

namespace TruVoyageLogicLayer
{
    public class VehicleManager : IVehicleManager
    {  
        /// <summary>
        /// Retrieves all vehicles via the VehicleAccessor's retrieve all vehicles stored procedure call
        /// No parameters are required for this method as it is intended for admin/employees to utilize this feature
        /// </summary>
        /// <returns>List<Vehicle></returns>
        public List<Vehicle> GetFullListOfVehicles()
        {
            var allVehicles = new List<Vehicle>();
            allVehicles = VehicleAccessor.RetrieveAllVehicles();
            return allVehicles;
        }

        /// <summary>
        /// Retrieves all vehicles that are available for rental. Both consumers and employees will utilize this feature
        /// </summary>
        /// <returns></returns>
        public List<Vehicle> GetAvailableVehicles()
        {
            var vehicles = new List<Vehicle>();
            vehicles = VehicleAccessor.RetrievAvailableVehicles();
            return vehicles;
        }

        public bool AddNewVehicle(Vehicle newVehicle)
        {
            try
            {
                return (VehicleAccessor.CreateNewVehicle(newVehicle) == 1);
            }
            catch (Exception)
            {
                throw;
            }             
        }

        public bool UpdateMaintenanceRecords(Vehicle oldVehicleRecords, Vehicle newVehicleRecords)
        {
            try
            {
                return (VehicleAccessor.UpdateMaintenanceRecords(oldVehicleRecords, newVehicleRecords)==1);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
