using System.Collections.Generic;
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
      [Route("/api/store/")]
    public class StoreController:Controller
    {
          private readonly IMapper mapper;
       private readonly ProfileContext context;

        public StoreController(IMapper mapper, ProfileContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

         [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody]StoreResources productResources)
        {
          //  individualResourses.Id = 0;

            if (!ModelState.IsValid)
              return BadRequest(ModelState);
            
               var product=  mapper.Map<StoreResources, Store>(productResources);
              
           // individual.Id = 0;
            context.Add(product);
           await context .SaveChangesAsync();

           product=await context.Stores.SingleOrDefaultAsync(s=>s.Id==product.Id);
           var result= mapper.Map<Store, StoreResources>(product);


              return Ok(result);
        }

             [HttpPut("{Id}")]
        public async Task<IActionResult> EditCategory(int Id, [FromBody]StoreResources productResources)
        {
            

          if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var product = await context.Stores.SingleOrDefaultAsync(x => x.Id == Id);
            mapper.Map<StoreResources, Store>(productResources, product);
            
            await context.SaveChangesAsync();
          product=await context.Stores.SingleOrDefaultAsync(s=>s.Id==product.Id);
           var result= mapper.Map<Store, StoreResources>(product);


              return Ok(result);
        }

             [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
          
          var product=await context.Stores
          .SingleOrDefaultAsync(s=>s.Id==id);
          
           if (product==null)
           return NotFound();
           var result= mapper.Map<Store, StoreResources>(product);
           return Ok(result);
        }

              [HttpGet]
        public async Task<IActionResult> ListCategories()
        {
          
          var product=await context.Stores
          .ToListAsync();
          
           if (product==null)
           return NotFound();
           var result= mapper.Map<List<Store>, List<StoreResources>>(product);
           return Ok(result);
        }
    }
}