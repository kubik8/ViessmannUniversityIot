﻿namespace UniversityIot.GatewaysDataAccess
{
    using System.Data.Entity;
    using UniversityIot.GatewaysDataAccess.Models;

    public class GatewaysContext : DbContext
    {
        public GatewaysContext()
            : base("UniversityIot.Gateways")
        {
        }

        public GatewaysContext(string connectionName)
            : base(connectionName)
        {
        }

        public IDbSet<Gateway> Gateways { get; set; }

        public IDbSet<GatewaySetting> GatewaySettings { get; set; }
    }
}
