using DriveMada_Backend.DataManager.Interfaces;
using DriveMada_Backend.Manager;
using DriveMada_Backend.Manager.Interfaces;
using DriveMada_Backend.Model;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DriveMada_Backend.Tests
{
    [TestFixture]
    public class VehicleManagerTest
    {
        private Mock<IVehicleDataManager> _vehicleDataManagerMock;
        private IVehicleManager _vehicleManager;
        private List<Vehicle> _vehicles;

        [SetUp]
        public void Setup()
        {
            _vehicleDataManagerMock = new Mock<IVehicleDataManager>();

            _vehicles = new List<Vehicle>
            {
                new Vehicle {
                    id = 25,
                    make = "Honda",
                    model = "Accord",
                    year = 2020,
                    colour = "Black",
                    licensePlate = "AFC 258",
                    size = "Drive X"
                },
                new Vehicle {
                    id = 12,
                    make = "Honda",
                    model = "Civic",
                    year = 2010,
                    colour = "Blue",
                    licensePlate = "EDC 788",
                    size = "Drive XL"
                },
                new Vehicle {
                    id = 10,
                    make = "Toyota",
                    model = "Corolla",
                    year = 2018,
                    colour = "Red",
                    licensePlate = "BDC 558",
                    size = "Drive X"
                }
            };            

            _vehicleManager = new VehicleManager(_vehicleDataManagerMock.Object);
        }

        [Test]
        public void ShouldGetAllVehicles()
        {
            _vehicleDataManagerMock
                .Setup(m => m.GetVehicles(It.IsAny<uint>()))
                .Returns(_vehicles);

            var vehicles = (List <Vehicle>) _vehicleManager.GetVehicles(22);

            Assert.IsNotNull(vehicles);
            Assert.AreEqual(vehicles.Count, 3);
        }

        [Test]
        public void ShouldDeleteVehicle()
        {
            _vehicleDataManagerMock
                .Setup(m => m.DeleteVehicle(It.IsAny<uint>()))
                .Returns(true);

            var response = _vehicleManager.DeleteVehicle(23);
            
            Assert.IsTrue(response);
        }

        [Test]
        public void ShouldAddVehicle()
        {
            _vehicleDataManagerMock
                .Setup(m => m.AddVehicle(It.IsAny<uint>(), It.IsAny<Vehicle>()))
                .Returns(true);

            var vehicle = new Vehicle
            {
                id = 80,
                make = "Hyundai",
                model = "Sonata",
                year = 2011,
                colour = "Silver",
                licensePlate = "B3C AE8",
                size = "Drive XL"
            };

            var response = _vehicleManager.AddVehicle(12, vehicle);

            Assert.IsTrue(response);
        }

        [Test]
        public void ShouldFailToAddVehicle()
        {
            var vehicle = new Vehicle
            {
                id = 80,
                make = "Hyundai",
                model = "Elantra",
                year = 2013,
                colour = "Blue",
                licensePlate = "B3C AE8",
                size = "Drive XL"
            };

            _vehicleDataManagerMock
                .Setup(m => m.AddVehicle(It.IsAny<uint>(), It.IsAny<Vehicle>()))
                .Returns(false);

            var response = _vehicleManager.AddVehicle(12, vehicle);

            Assert.IsFalse(response);
        }

        [Test]
        public void ShouldUpdateVehicle()
        {
            _vehicleDataManagerMock
                .Setup(m => m.UpdateVehicle(It.IsAny<Vehicle>()))
                .Returns(true);

            var vehicle = _vehicles[0];
            vehicle.colour = "Yellow";

            var response = _vehicleManager.UpdateVehicle(vehicle);

            Assert.IsTrue(response);
        }
    }
}
