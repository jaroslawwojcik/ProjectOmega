﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectOmega.Data.Models.User;
using ProjectOmega.Repositories.UsersRepository;

namespace ProjectOmega.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _users;

        public UsersController(IUsersRepository users)
        {
            _users = users;
        }

        /// <summary>
        /// Returns list of all users
        /// </summary>
        /// <returns>IEnumerable of OrderModel</returns>
        [HttpGet]
        public ActionResult<IEnumerable<UserModel>> Get()
        {
            return Ok(_users.GetAll());
        }


        /// <summary>
        /// Adds new user to DB
        /// </summary>
        /// <param name="order"></param>
        [HttpPost]
        public void Post([FromBody] AddUserModel order)
        {
            _users.Create(order);
        }

        // TODO
        /// <summary>
        /// Updates specified user
        /// </summary>
        /// <param name="user"></param>
        [HttpPut]
        public void Put([FromBody] EditUserModel order)
        {
            _users.Update(order);
        }

        // TODO
        /// <summary>
        /// Deletes specified user
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _users.Remove(id);
        }
    }
}
