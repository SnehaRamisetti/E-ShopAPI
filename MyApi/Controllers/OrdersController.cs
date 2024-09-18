using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApi.Data;
using MyApi.Models.Domain; 
using MyApi.Models.DTO; 
using MyApi.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
         
        private readonly IOrderRepository orderRepo;
        private readonly IMapper mapper;
         
        public OrdersController( IOrderRepository orderRepo,IMapper mapper)
        {
            this.orderRepo=orderRepo;
            this.mapper=mapper;
        }

        //HTTPGET : Get all the products from the database

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           //Get Data from Database-Domain models
            var orders= await  orderRepo.GetAllAsync();

            //Using AutoMapper to map the obj
             //Map domain models to DTO
             var ordersDto = mapper.Map<List<OrderDto>>(orders);

            //return the DTOs
            return Ok(ordersDto);
        }

         //Get one product by ID

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id){

            // var product=dbContext.Products.Find(id);
            var order= await orderRepo.GetByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }
             //Map domain models to DTO
             var orderDto = mapper.Map<OrderDto>(order);

            //return the DTOs
            return Ok(orderDto);
        }

        //Create : Order
        //Post
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddOrderRequestDto addOrderRequestDto)
        {
            if(ModelState.IsValid){
            //Convert DTO to domain model
            var orderDomain =  mapper.Map<Order>(addOrderRequestDto);

            await  orderRepo.CreateAsync(orderDomain);
            
            //Convert to domain to DTO
            var orderDto = mapper.Map<OrderDto>(orderDomain);

            return CreatedAtAction(nameof(GetById),new { id= orderDto.OrderId},orderDto);
            }
            else{
                return BadRequest();
            }

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,[FromBody] UpdateOrderRequestDto updateOrderRequestDto)
        {
           //Map dto to domain model;
           var orderDomain = mapper.Map<Order>(updateOrderRequestDto);
           orderDomain = await orderRepo.UpdateAsync(id,orderDomain);

           if(orderDomain == null)
           {
            return NotFound();
           }

           //Convert domain model to dto
           var orderDto = mapper.Map<OrderDto>(orderDomain);

          return Ok(orderDto);

        }

        //Delete a product by ID
        [HttpDelete]
        [Route("{id:Guid}")]
         public async Task<IActionResult> Delete([FromRoute] Guid id){
    
            // var product=dbContext.Products.Find(id);
            var order= await orderRepo.DeleteAsync(id);

            if (order == null)
            {
                return NotFound();
            }

             //Map domain models to DTO
            var orderDto = mapper.Map<OrderDto>(order);

            return Ok(orderDto);
        }
    }
}