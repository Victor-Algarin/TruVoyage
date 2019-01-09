using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruVoyageDataOjectLayer;

namespace TruVoyageDataAccessLayer
{
    public class VehicleAccessor
    {
        /// <summary>
        /// This will be used to retrieve all vehicles regardless of availablity. This allows employees to see each vehicle and it's maintenance status
        /// </summary>
        /// <returns>List<Vehicle></returns>
        public static List<Vehicle> RetrieveAllVehicles()
        {
            var vehicles = new List<Vehicle>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retrieve_all_vehicles";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        vehicles.Add(new Vehicle() {
                            VIN = reader.GetString(0),
                            VehicleType = reader.GetString(1),
                            Make = reader.GetString(2),
                            Model = reader.GetString(3),
                            ModelYear = reader.GetInt32(4),
                            Color = reader.GetString(5),
                            Mileage = reader.GetInt32(6),
                            EngineSize = reader.GetString(7),
                            PassengerCapacity = reader.GetInt32(8),
                            PurchasePrice = reader.GetDecimal(9),
                            MaintenacnePersonnelID = reader.GetInt32(10),
                            LastMaintenance = reader.GetDateTime(11),
                            Available = reader.GetBoolean(12),
                            NeedsMaintenance = reader.GetBoolean(13)                                                                                  
                        });
                    }
                    reader.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return vehicles;
        }

        public static List<Vehicle> RetrievAvailableVehicles()
        {
            var vehicles = new List<Vehicle>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retrieve_all_available_vehicles";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        vehicles.Add(new Vehicle()
                        {
                            VIN = reader.GetString(0),
                            VehicleType = reader.GetString(1),
                            Make = reader.GetString(2),
                            Model = reader.GetString(3),
                            ModelYear = reader.GetInt32(4),
                            Color = reader.GetString(5),
                            Mileage = reader.GetInt32(6),
                            EngineSize = reader.GetString(7),
                            PassengerCapacity = reader.GetInt32(8),
                            PurchasePrice = reader.GetDecimal(9),
                            MaintenacnePersonnelID = reader.GetInt32(10),
                            LastMaintenance = reader.GetDateTime(11),
                            Available = reader.GetBoolean(12),
                            NeedsMaintenance = reader.GetBoolean(13)
                        });
                    }
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return vehicles;
        }

        public static int CreateNewVehicle(Vehicle newVehicle)
        {
            int result = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_add_vehicle_to_inventory";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@VIN", newVehicle.VIN);
            cmd.Parameters.AddWithValue("@VehicleType", newVehicle.VehicleType);
            cmd.Parameters.AddWithValue("@Make", newVehicle.Make);
            cmd.Parameters.AddWithValue("@Model", newVehicle.Model);
            cmd.Parameters.AddWithValue("@ModelYear", newVehicle.ModelYear);
            cmd.Parameters.AddWithValue("@Color", newVehicle.Color);
            cmd.Parameters.AddWithValue("@Mileage", newVehicle.Mileage);
            cmd.Parameters.AddWithValue("@EngineSize", newVehicle.EngineSize);
            cmd.Parameters.AddWithValue("@PassengerCapacity", newVehicle.PassengerCapacity);
            cmd.Parameters.AddWithValue("@PurchasePrice", newVehicle.PurchasePrice);

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public static int UpdateMaintenanceRecords(Vehicle oldVehicleRecords, Vehicle newVehicleRecords)
        {
            int result = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_update_vehicle_maintenance_records";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@VIN", oldVehicleRecords.VIN);

            cmd.Parameters.AddWithValue("@OldMileage", oldVehicleRecords.Mileage);
            cmd.Parameters.AddWithValue("@OldAvailable", oldVehicleRecords.Available);
            cmd.Parameters.AddWithValue("@OldNeedsMaintenance", oldVehicleRecords.NeedsMaintenance);
            cmd.Parameters.AddWithValue("@OldMaintenancePersonnelID", oldVehicleRecords.MaintenacnePersonnelID);
            cmd.Parameters.AddWithValue("@OldLastMaintenanceDate", oldVehicleRecords.LastMaintenance);

            cmd.Parameters.AddWithValue("@NewMileage", newVehicleRecords.Mileage);
            cmd.Parameters.AddWithValue("@NewAvailable", newVehicleRecords.Available);
            cmd.Parameters.AddWithValue("@NewNeedsMaintenance", newVehicleRecords.NeedsMaintenance);
            cmd.Parameters.AddWithValue("@NewMaintenancePersonnelID", newVehicleRecords.MaintenacnePersonnelID);
            cmd.Parameters.AddWithValue("@NewLastMaintenanceDate", newVehicleRecords.LastMaintenance);

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
    }       
}
