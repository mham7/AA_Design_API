﻿using BusinessLogic.Interfaces.Services.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderservice;
        public OrderController(IOrderService orderService)
        {
            _orderservice = orderService;
        }

        [HttpGet("list")]
        public async Task<object> GetOrderList()
        {
            return await _orderservice.GetOrderList();  
        }

        [HttpPatch("price")]
        public async Task<decimal?> PatchPrice(long id,long amount)
        {
            return await _orderservice.PatchPrice(id,amount);
        }



        [HttpGet("date/{days}")]
        public async Task<object> GetOrderByDate(int days,string status)
        {
            return await _orderservice.GetOrderByDate(days, status);
        }

        [HttpPut("status")]
        public async Task<object> PutStatus(long orderid, string status)
        {
            return await _orderservice.PutStatus(orderid, status);
        }


        [HttpGet("{id}")]
        public async Task<object> GetOrderDetails(long id)
        {
            return await _orderservice.GetOrderDetails(id);
        }
    }
}
