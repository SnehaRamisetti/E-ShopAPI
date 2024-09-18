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
using Microsoft.AspNetCore.Authorization;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
     
    public class ProductsController : ControllerBase
    {
        // private readonly OrdersDbContext dbContext;
        private readonly IProductRepository productRepo;
        private readonly IMapper mapper;

        public ProductsController(IProductRepository productRepo,IMapper mapper)
        {
             
            this.productRepo=productRepo;
            this.mapper=mapper;
        }

        //HTTPGET : Get all the products from the database

        [HttpGet]
        [Authorize(Roles="Reader")]
        public async Task<IActionResult> GetAll()
        {
           //Get Data from Database-Domain models
            var products= await  productRepo.GetAllAsync();

            //Using AutoMapper to map the obj
             //Map domain models to DTO
             var productsDto = mapper.Map<List<ProductDto>>(products);

            //return the DTOs
            return Ok(productsDto);
        }

        //Get one product by ID

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles="Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id){

            // var product=dbContext.Products.Find(id);
            var product= await productRepo.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }
             //Map domain models to DTO
             var productDto = mapper.Map<ProductDto>(product);

            //return the DTOs
            return Ok(productDto);
        }
        
        //Create a new product

        [HttpPost]
        [Authorize(Roles="Writer")]
        public async Task<IActionResult> Create([FromBody] AddProductRequestDto addProductRequestDto)
        {
            //Convert DTO to domain model
            var productDomain =  mapper.Map<Product>(addProductRequestDto);

            await  productRepo.CreateAsync(productDomain);
            
            //Convert to domain to DTO
            var productDto = mapper.Map<ProductDto>(productDomain);

            return CreatedAtAction(nameof(GetById),new { id= productDto.ProductId},productDto);
        }

        //Update the exisiting product

        [HttpPut]
        [Route("{id:Guid}")]
         [Authorize(Roles="Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id,[FromBody] UpdateProductRequestDto updateProductRequestDto)
        {
           //Map dto to domain model;
           var productDomain = mapper.Map<Product>(updateProductRequestDto);
           productDomain = await productRepo.UpdateAsync(id,productDomain);

           if(productDomain == null)
           {
            return NotFound();
           }
                                      
           //Convert domain model to dto
           var productDto = mapper.Map<ProductDto>(productDomain);

          return Ok(productDto);

        }

        //Delete a product by ID
        [HttpDelete]
        [Route("{id:Guid}")]
         [Authorize(Roles="Writer,Reader")]
         public async Task<IActionResult> Delete([FromRoute] Guid id){
    
            // var product=dbContext.Products.Find(id);
            var product= await productRepo.DeleteAsync(id);

            if (product == null)
            {
                return NotFound();
            }

             //Map domain models to DTO
            var productDto = mapper.Map<ProductDto>(product);

            return Ok(productDto);
        }
    }
            
}

///////////////////////////////////////////
 //Map domain models to DTO
            // var productsDto = new List<ProductDto>();

            // foreach(var product in products){
            //     productsDto.Add(new ProductDto()
            //     {
            //         ProductId = product.ProductId,
            //         ProductName = product.ProductName,
            //         Price = product.Price
            //     });
            // };

            //Using AutoMapper to map the obj
             //Map domain models to DTO
            //  var productsDto = mapper.Map<List<ProductDto>>(products);

            // //return the DTOs
            // return Ok(productsDto);
  

        