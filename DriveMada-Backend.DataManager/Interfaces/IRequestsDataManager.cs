using System;
using System.Collections.Generic;
using System.Text;
using DriveMada_Backend.Model;

namespace DriveMada_Backend.DataManager.Interfaces
{
    public interface IRequestDataManager
    {
        bool AddRequest(uint userId, Request request);
        IEnumerable<Request> GetRequests();

        bool DeleteRequest(uint reqId);

       
    }
}
