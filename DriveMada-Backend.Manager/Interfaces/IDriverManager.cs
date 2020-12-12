using DriveMada_Backend.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriveMada_Backend.Manager.Interfaces
{
    public interface IDriverManager
    {
        bool RegisterDriver(Driver driver);
    }
}
