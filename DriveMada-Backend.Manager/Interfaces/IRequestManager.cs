using System;
using System.Collections.Generic;
using System.Text;
using DriveMada_Backend.Model;

namespace DriveMada_Backend.Manager.Interfaces
{
    public interface IRequestManager
    {
        bool AddRequest(uint userId, Request request);

        IEnumerable<Request> GetRequests();

        bool DeleteRequest(uint reqId);
    }
}
