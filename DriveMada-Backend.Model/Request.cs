using System;
using System.Collections.Generic;
using System.Text;

namespace DriveMada_Backend.Model
{
    public class Request
    {
        public uint id { get; set;}
        public uint userId { get; set; }
        public uint driverId { get; set; }

        public double latitude { get; set; }

        public double longitude { get; set; }
    
        public string sourceAddress { get; set; }

        public string destinationAddress { get; set; }

        public double fare { get; set; }

        public double distance { get; set; }

        public DateTime requestDate { get; set; }

        public DateTime completionDate { get; set; }
    }
}
