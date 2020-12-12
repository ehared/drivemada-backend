using System;
using System.Collections.Generic;
using System.Text;
using DriveMada_Backend.Model;

namespace DriveMada_Backend.DataManager.Interfaces
{
    public interface IVehicleDataManager
    {
        bool AddVehicle(uint userId, Vehicle vehicle);
        IEnumerable<Vehicle> GetVehicles(uint uid);

        bool DeleteVehicle(uint vid);

        bool UpdateVehicle(Vehicle vehicle);
    }
}
