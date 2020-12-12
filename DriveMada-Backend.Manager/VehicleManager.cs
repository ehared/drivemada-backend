using DriveMada_Backend.DataManager.Interfaces;
using DriveMada_Backend.Manager.Interfaces;
using DriveMada_Backend.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriveMada_Backend.Manager
{
    public class VehicleManager : IVehicleManager
    {
        private IVehicleDataManager _vehicleDataManager;

        public VehicleManager(IVehicleDataManager vehicleDataManager)
        {
            _vehicleDataManager = vehicleDataManager ?? throw new ArgumentNullException(nameof(vehicleDataManager));
        }

        public bool AddVehicle(uint userId, Vehicle vehicle)
        {
            return _vehicleDataManager.AddVehicle(userId, vehicle);
        }

        public IEnumerable<Vehicle> GetVehicles(uint uid)
        {
            return _vehicleDataManager.GetVehicles(uid);
        }

        public bool DeleteVehicle(uint vid)
        {
            return _vehicleDataManager.DeleteVehicle(vid);
        }

        public bool UpdateVehicle(Vehicle vehicle)
        {
            return _vehicleDataManager.UpdateVehicle(vehicle);
        }
    }
}
