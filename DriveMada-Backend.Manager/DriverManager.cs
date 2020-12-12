using DriveMada_Backend.DataManager.Interfaces;
using DriveMada_Backend.Manager.Interfaces;
using DriveMada_Backend.Model;
using System;

namespace DriveMada_Backend.Manager
{
    public class DriverManager : IDriverManager
    {
        private IDriverDataManager _driverDataManager;

        public DriverManager(IDriverDataManager driverDataManager)
        {
            _driverDataManager = driverDataManager ?? throw new ArgumentNullException(nameof(driverDataManager));
        }

        public bool RegisterDriver(Driver driver)
        {
            // TODO: Send Verification email

            return _driverDataManager.SaveDriver(driver);
        }
    }
}
