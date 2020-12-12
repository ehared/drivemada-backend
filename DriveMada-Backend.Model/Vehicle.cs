using System;
using System.Collections.Generic;
using System.Text;

namespace DriveMada_Backend.Model
{
    public class Vehicle
    {
        public uint id { get; set; }
        public string make {  get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public string colour { get; set; }
        public string licensePlate { get; set; }

        public string size { get; set; }

        public static implicit operator Vehicle(List<Vehicle> v)
        {
            throw new NotImplementedException();
        }
    }
}
