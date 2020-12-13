using System;
using System.Collections.Generic;
using System.Text;
using DriveMada_Backend.Model;

namespace DriveMada_Backend.DataManager.Interfaces
{
    public interface IRequestDataManager
    {
        bool AddRequest(Request request);
        IEnumerable<Request> GetAvailableRequests();
        IEnumerable<Request> GetClientRequests(uint userId);
        IEnumerable<Request> GetDriverRequests(uint driverId);
        bool DeleteRequest(uint reqId);
        bool UpdateRequest(Request request);
    }
}
