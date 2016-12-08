﻿namespace UniversityIot.VitoControlApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;
    using MediatR;
    using UniversityIot.VitoControlApi.Models;

    /// <summary>
    /// Users controller
    /// </summary>
    [RoutePrefix("users")]
    public class UsersController : ApiControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>       
        [CLSCompliant(false)]
        public UsersController(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Gets the user
        /// </summary>
        /// <param name="user">The identifier.</param>
        /// <returns>
        /// User model
        /// </returns>
        [Route("{id}")]
        public async Task<IHttpActionResult> Get([FromUri]GetUserRequest user)
        {
            GetUserResponse responseModel = await this.HandleRequestAsync<GetUserRequest, GetUserResponse>(user);
            return this.CreateHttpActionResult(responseModel);
        }
    }
}