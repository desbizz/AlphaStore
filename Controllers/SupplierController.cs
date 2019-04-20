using System.Threading.Tasks;
using AlphaStore.Entities;
using AlphaStore.Recources;
using AlphaStore.Repositories;
using AlphaStore.SaveRecources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlphaStore.Controllers
{
    [Route("/api/supplier/")]
    public class SupplierController:Controller
    {
         private readonly IMapper mapper;
        private readonly ProfileContext context;

        public SupplierController(IMapper mapper, ProfileContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

         [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]SaveSupplierResources productResources)
        {
          //  individualResourses.Id = 0;

            if (!ModelState.IsValid)
              return BadRequest(ModelState);
            
               var product=  mapper.Map<SaveSupplierResources, Supplier>(productResources);
              
           // individual.Id = 0;
            context.Add(product);
           await context .SaveChangesAsync();

           product=await context.Suppliers.SingleOrDefaultAsync(s=>s.Id==product.Id);
           var result= mapper.Map<Supplier, SupplierResources>(product);


              return Ok(result);
        }

             [HttpPut("{Id}")]
        public async Task<IActionResult> EditStudent(int Id, [FromBody]SaveSupplierResources productResources)
        {
            

          if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var product = await context.Suppliers.SingleOrDefaultAsync(x => x.Id == Id);
            mapper.Map<SaveSupplierResources, Supplier>(productResources, product);
            
            await context.SaveChangesAsync();
          product=await context.Suppliers.SingleOrDefaultAsync(s=>s.Id==product.Id);
           var result= mapper.Map<Supplier, SupplierResources>(product);


              return Ok(result);
        }

             [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
          
          var product=await context.Suppliers
          .SingleOrDefaultAsync(s=>s.Id==id);
          
           if (product==null)
           return NotFound();
           var result= mapper.Map<Supplier, SupplierResources>(product);
           return Ok(result);
        }

        
    }
}