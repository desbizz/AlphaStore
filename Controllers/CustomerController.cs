using System.Collections.Generic;
using System.Threading.Tasks;
using AlphaStore.Entities;
using AlphaStore.Recources;
using AlphaStore.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlphaStore.Controllers
{
       [Route("/api/customer/")]
    public class CustomerController:Controller
    {
      private readonly IMapper mapper;
       private readonly ProfileContext context;

        public CustomerController()
        {
        }

        public CustomerController(IMapper mapper, ProfileContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

         [HttpPost]
        public async Task<IActionResult> CreateCustumer([FromBody]CustomerResources productResources)
        {
          //  individualResourses.Id = 0;

            if (!ModelState.IsValid)
              return BadRequest(ModelState);
            
               var product=  mapper.Map<CustomerResources, Customer>(productResources);
              
           // individual.Id = 0;
            context.Add(product);
           await context .SaveChangesAsync();

           product=await context.Customers.SingleOrDefaultAsync(s=>s.Id==product.Id);
           var result= mapper.Map<Customer, CustomerResources>(product);


              return Ok(result);
        }

             [HttpPut("{Id}")]
        public async Task<IActionResult> EditCustomer(int Id, [FromBody]CustomerResources productResources)
        {
            

          if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var product = await context.Customers.SingleOrDefaultAsync(x => x.Id == Id);
            mapper.Map<CustomerResources, Customer>(productResources, product);
            
            await context.SaveChangesAsync();
          product=await context.Customers.SingleOrDefaultAsync(s=>s.Id==product.Id);
           var result= mapper.Map<Customer, CustomerResources>(product);


              return Ok(result);
        }

             [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
          
          var product=await context.Customers
          .SingleOrDefaultAsync(s=>s.Id==id);
          
           if (product==null)
           return NotFound();
           var result= mapper.Map<Customer, CustomerResources>(product);
           return Ok(result);
        }

              [HttpGet]
        public async Task<IActionResult> ListCCustomer()
        {
          
          var product=await context.Customers
          .ToListAsync();
          
           if (product==null)
           return NotFound();
           var result= mapper.Map<List<Customer>, List<CustomerResources>>(product);
           return Ok(result);
        }

        
      
    }
}