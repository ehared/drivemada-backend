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
    public class RequestManagerTest
    {
        private Mock<IRequestDataManager> _requestDataManagerMock;
        private IRequestManager _requestManager;
        private List<Request> _requests;

        [SetUp]
        public void Setup()
        {
            _requestDataManagerMock = new Mock<IRequestDataManager>();

            _requests = new List<Request>
            {
                new Request {
                    id = 2,
                    userId = 10,
                    completionDate = DateTime.Now,
                    destinationAddress = "123 Bank Street",
                    distance = 22,
                    driverId = 13,
                    fare = 55.50,
                    latitude= 112,
                    longitude = 150,
                    requestDate = DateTime.Now,
                    sourceAddress = "456 Rideau Street"                    
                },
                new Request {
                    id = 3,
                    userId = 10,
                    completionDate = DateTime.Now,
                    destinationAddress = "55 Carson Ave",
                    distance = 35,
                    driverId = 15,
                    fare = 22,
                    latitude= 120,
                    longitude = 134,
                    requestDate = DateTime.Now,
                    sourceAddress = "75 Dalkey Road"
                },
                new Request {
                    id = 4,
                    userId = 10,
                    completionDate = DateTime.Now,
                    destinationAddress = "56 Prince Albert Street",
                    distance = 10,
                    driverId = 15,
                    fare = 32,
                    latitude= 119,
                    longitude = 147,
                    requestDate = DateTime.Now,
                    sourceAddress = "5 Queen Mary Street"
                }
            };

            _requestManager = new RequestManager(_requestDataManagerMock.Object);
        }

        [Test]
        public void ShouldGetAllAvailableRequests()
        {
            _requestDataManagerMock
                .Setup(m => m.GetAvailableRequests())
                .Returns(_requests);

            var requests = (List<Request>)_requestManager.GetAvailableRequests();

            Assert.IsNotNull(requests);
            Assert.AreEqual(requests.Count, 3);
        }

        [Test]
        public void ShouldGetAllClientRequests()
        {
            _requestDataManagerMock
                .Setup(m => m.GetClientRequests(It.IsAny<uint>()))
                .Returns(new List<Request> { _requests[0] });

            var requests = (List<Request>)_requestManager.GetClientRequests(12);

            Assert.IsNotNull(requests);
            Assert.AreEqual(requests.Count, 1);
        }

        [Test]
        public void ShouldGetAllDriverRequests()
        {
            _requestDataManagerMock
                .Setup(m => m.GetDriverRequests(It.IsAny<uint>()))
                .Returns(new List<Request> { _requests[0], _requests[2] });

            var requests = (List<Request>)_requestManager.GetDriverRequests(13);

            Assert.IsNotNull(requests);
            Assert.AreEqual(requests.Count, 2);
        }

        [Test]
        public void ShouldDeleteRequest()
        {
            _requestDataManagerMock
                .Setup(m => m.DeleteRequest(It.IsAny<uint>()))
                .Returns(true);

            var response = _requestManager.DeleteRequest(15);

            Assert.IsTrue(response);
        }

        [Test]
        public void ShouldAddRequest()
        {
            _requestDataManagerMock
                .Setup(m => m.AddRequest(It.IsAny<Request>()))
                .Returns(true);

            var request = new Request
            {
                id = 5,
                userId = 10,
                completionDate = DateTime.Now,
                destinationAddress = "12 Montreal Road",
                distance = 15,
                driverId = 22,
                fare = 46,
                latitude = 122,
                longitude = 155,
                requestDate = DateTime.Now,
                sourceAddress = "45 St Laurent Boulevard"
            };

            var response = _requestManager.AddRequest(request);

            Assert.IsTrue(response);
        }

        [Test]
        public void ShouldFailToAddRequest()
        {
            _requestDataManagerMock
                .Setup(m => m.AddRequest(It.IsAny<Request>()))
                .Returns(false);

            var request = new Request
            {
                id = 5,
                userId = 10,
                completionDate = DateTime.Now,
                destinationAddress = "12 Montreal Road",
                distance = 15,
                driverId = 22,
                fare = 46,
                latitude = 122,
                longitude = 155,
                requestDate = DateTime.Now,
                sourceAddress = "45 St Laurent Boulevard"
            };

            var response = _requestManager.AddRequest(request);

            Assert.IsFalse(response);
        }

        [Test]
        public void ShouldUpdateRequest()
        {
            _requestDataManagerMock
                .Setup(m => m.UpdateRequest(It.IsAny<Request>()))
                .Returns(true);

            var request = _requests[0];
            request.driverId = 22;

            var response = _requestManager.UpdateRequest(request);

            Assert.IsTrue(response);
        }
    }
}
