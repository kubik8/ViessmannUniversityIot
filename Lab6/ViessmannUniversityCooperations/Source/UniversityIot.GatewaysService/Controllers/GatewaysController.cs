﻿namespace UniversityIot.GatewaysService.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;
    using AutoMapper;
    using UniversityIot.GatewaysDataService;

    /// <summary>
    /// Gateways controller
    /// </summary>
    [RoutePrefix("gateways")]
    public class GatewaysController : ApiController
    {
        /// <summary>
        /// The gateways data service
        /// </summary>
        private readonly IGatewaysDataService gatewaysDataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GatewaysController" /> class.
        /// </summary>
        /// <param name="gatewaysDataService">The gateways data service.</param>
        public GatewaysController(IGatewaysDataService gatewaysDataService)
        {
            this.gatewaysDataService = gatewaysDataService;
        }

        /// <summary>
        /// Gets the specified ids.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>List of gateways</returns>
        [Route("")]
        public async Task<IHttpActionResult> Get([FromUri] int[] ids)
        {
            var gateways = await this.gatewaysDataService.GetGateways(ids);

            var mappedGateways = Mapper.Map<List<Messages.Gateway>>(gateways);
            return Ok(mappedGateways);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Gateway object</returns>
        [Route("{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var gateway = await this.gatewaysDataService.GetGateway(id);
            if (gateway == null)
            {
                return NotFound();
            }

            var mappedGateway = Mapper.Map<Messages.Gateway>(gateway);
            return Ok(mappedGateway);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <returns>List of settings</returns>
        [Route("settings")]
        public async Task<IHttpActionResult> GetSettings()
        {
            var settings = await this.gatewaysDataService.GetSettings();

            var mappedSettings = Mapper.Map<IEnumerable<Messages.GatewaySetting>>(settings);
            return Ok(mappedSettings);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <returns>Single setting</returns>
        [Route("settings/{id}")]
        public async Task<IHttpActionResult> GetSettings(int id)
        {
            var setting = await this.gatewaysDataService.GetSetting(id);

            var mappedSettings = Mapper.Map<Messages.GatewaySetting>(setting);
            return Ok(mappedSettings);
        }
    }
}