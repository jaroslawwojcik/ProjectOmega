﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectOmega.Data.Models.Order;
using ProjectOmega.Repositories.OrdersRepositories;

namespace ProjectOmega.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _orders;

        public OrdersController(IOrdersRepository orders)
        {
            _orders = orders;
        }
    
        /// <summary>
        /// Returns list of all orders
        /// </summary>
        /// <returns>IEnumerable of OrderModel</returns>
        [HttpGet]
        public ActionResult<IEnumerable<OrderModel>> Get()
        {
            return Ok(_orders.GetAll());
        }

        /// <summary>
        /// Returns order with specified ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<OrderModel> Get(long id)
        {
            return _orders.GetById(id);
        }

      
        /// <summary>
        /// Adds new order to DB
        /// </summary>
        /// <param name="order"></param>
        [HttpPost]
        public void Post([FromBody] AddOrderModel order)
        {
            _orders.Create(order);
        }

        /// <summary>
        /// Updates specified order
        /// </summary>
        /// <param name="order"></param>
        [HttpPut]
        public void Put([FromBody] EditOrderModel order)
        {
            _orders.Update(order);
        }

       
        /// <summary>
        /// Deletes specified order
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _orders.Remove(id);
        }
    }
}
