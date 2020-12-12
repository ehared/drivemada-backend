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

        public bool AddRequest(uint userId, Request request)
        {
            return _requestDataManager.AddRequest(userId, request);
        }
        
        public IEnumerable<Request> GetRequests()
        {
            return _requestDataManager.GetRequests();
        }

        public bool DeleteRequest(uint reqId)
        {
            return _requestDataManager.DeleteRequest(reqId);
        }

       
    }
}
