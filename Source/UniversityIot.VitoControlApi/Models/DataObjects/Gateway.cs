using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityIot.VitoControlApi.Enums;

namespace UniversityIot.VitoControlApi.Models.DataObjects
{
    public class Gateway
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public GatewayStatus Status { get; set; }

        public string SerialNumber { get; set; }

        public User User { get; set; }
    }
}