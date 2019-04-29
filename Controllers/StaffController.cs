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

       [Route("/api/staff/")]
    public class StaffController:Controller
    {private readonly IMapper mapper;
       private readonly ProfileContext context;

        public StaffController(IMapper mapper, ProfileContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

         [HttpPost]
        public async Task<IActionResult> CreateStaff([FromBody]StaffResources productResources)
        {
          //  individualResourses.Id = 0;

            if (!ModelState.IsValid)
              return BadRequest(ModelState);
            
               var product=  mapper.Map<StaffResources, Staff>(productResources);
              
           // individual.Id = 0;
            context.Add(product);
           await context .SaveChangesAsync();

           product=await context.Staffs.SingleOrDefaultAsync(s=>s.Id==product.Id);
           var result= mapper.Map<Staff, StaffResources>(product);


              return Ok(result);
        }

             [HttpPut("{Id}")]
        public async Task<IActionResult> EditStaff(int Id, [FromBody] StaffResources productResources)
        {
            

          if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var product = await context.Staffs.SingleOrDefaultAsync(x => x.Id == Id);
            mapper.Map<StaffResources, Staff>(productResources, product);
            
            await context.SaveChangesAsync();
          product=await context.Staffs.SingleOrDefaultAsync(s=>s.Id==product.Id);
           var result= mapper.Map<Staff, StaffResources>(product);


              return Ok(result);
        }

             [HttpGet("{id}")]
        public async Task<IActionResult> GetStaff(int id)
        {
          
          var product=await context.Staffs
          .SingleOrDefaultAsync(s=>s.Id==id);
          
           if (product==null)
           return NotFound();
           var result= mapper.Map<Staff, StaffResources>(product);
           return Ok(result);
        }

              [HttpGet]
        public async Task<IActionResult> ListStaff()
        {
          
          var product=await context.Staffs
          .ToListAsync();
          
           if (product==null)
           return NotFound();
           var result= mapper.Map<List<Staff>, List<StaffResources>>(product);
           return Ok(result);
        }

        
    }
}