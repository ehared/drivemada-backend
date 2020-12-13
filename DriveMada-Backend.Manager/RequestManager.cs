using DriveMada_Backend.DataManager.Interfaces;
using DriveMada_Backend.Manager.Interfaces;
using DriveMada_Backend.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriveMada_Backend.Manager
{
    public class RequestManager : IRequestManager
    {
        private IRequestDataManager _requestDataManager;

        public RequestManager(IRequestDataManager requestDataManager)
        {
            _requestDataManager = requestDataManager ?? throw new ArgumentNullException(nameof(requestDataManager));
        }

        public bool AddRequest(Request request)
        {
            return _requestDataManager.AddRequest(request);
        }
        
        public IEnumerable<Request> GetAvailableRequests()
        {
            return _requestDataManager.GetAvailableRequests();
        }

        public IEnumerable<Request>GetClientRequests(uint userId)
        {
            return _requestDataManager.GetClientRequests(userId);
        }

        public IEnumerable<Request> GetDriverRequests(uint driverId)
        {
            return _requestDataManager.GetDriverRequests(driverId);
        }

        public bool DeleteRequest(uint reqId)
        {
            return _requestDataManager.DeleteRequest(reqId);
        }

        public bool UpdateRequest(Request request)
        {
            return _requestDataManager.UpdateRequest(request);
        }
       
    }
}
