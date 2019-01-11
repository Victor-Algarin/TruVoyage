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
    public class ReservationsAccessor
    {
        public static Vehicle RentVehicleByVIN(string VIN, Vehicle oldVehicle, Vehicle newVehicle)
        {
            Vehicle rentedVehicle = null;
            int result = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_select_specific_vehicle_for_rental";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@VIN", oldVehicle.VIN);
            cmd.Parameters.AddWithValue("@OldAvailable", oldVehicle.Available);
            cmd.Parameters.AddWithValue("@NewAvailable", newVehicle.Available);

            try
            {                
                conn.Open();
                result = cmd.ExecuteNonQuery();
                var reader = cmd.ExecuteReader();                

                while (reader.HasRows)
                {
                    rentedVehicle.Equals(new Vehicle() {
                        VIN = reader.GetString(0),
                        Make = reader.GetString(1),
                        Model = reader.GetString(2),
                        ModelYear = reader.GetInt32(3),
                        VehicleTypeID = reader.GetString(4),
                        VehicleClassID = reader.GetString(5),
                        Color = reader.GetString(6),
                        Mileage = reader.GetInt32(7),
                        EngineSize = reader.GetString(8),
                        PassengerCapacity = reader.GetInt32(9),
                        PurchasePrice = reader.GetDecimal(10),
                        Available = reader.GetBoolean(11),
                        NeedsMaintenance = reader.GetBoolean(12)
                    });
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

            return rentedVehicle;
        }
    }
}
