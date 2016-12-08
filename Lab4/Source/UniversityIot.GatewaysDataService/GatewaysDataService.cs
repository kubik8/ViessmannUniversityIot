﻿namespace UniversityIot.GatewaysDataService
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using UniversityIot.GatewaysDataAccess;
    using UniversityIot.GatewaysDataAccess.Models;

    public class GatewaysDataService : IGatewaysDataService
    {
        public async Task<IEnumerable<Gateway>> GetGateways(IEnumerable<int> ids)
        {
            using (var context = new GatewaysContext())
            {
                var gatewaysQuery = context.Gateways.AsQueryable();
                if (ids != null)
                {
                    gatewaysQuery = gatewaysQuery.Where(x => ids.Contains(x.Id));
                }
                
                var gateways = await gatewaysQuery.ToArrayAsync();
                return gateways;
            }
        }

        public async Task<Gateway> GetGateway(int id)
        {
            using (var context = new GatewaysContext())
            {
                var gateway = await context.Gateways.FirstOrDefaultAsync(g => g.Id == id);
                return gateway;
            }
        }

        public async Task<IEnumerable<Datapoint>> GetDatapoints()
        {
            using (var context = new GatewaysContext())
            {
                var gatewaySettings = await context.GatewaySettings.ToListAsync();
                return gatewaySettings;
            }
        }

        public async Task<Datapoint> GetDatapoint(int id)
        {
            using (var context = new GatewaysContext())
            {
                var gatewaySettings = await context.GatewaySettings.FirstOrDefaultAsync(s => s.Id == id);
                return gatewaySettings;
            }
        }
    }
}
