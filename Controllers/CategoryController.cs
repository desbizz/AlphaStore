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
    [Route("/api/category/")]
    public class CategoryController:Controller
    {
         private readonly IMapper mapper;
       private readonly ProfileContext context;

        public CategoryController(IMapper mapper, ProfileContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

         [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]CategoryResources productResources)
        {
          //  individualResourses.Id = 0;

            if (!ModelState.IsValid)
              return BadRequest(ModelState);
            
               var product=  mapper.Map<CategoryResources, Category>(productResources);
              
           // individual.Id = 0;
            context.Add(product);
           await context .SaveChangesAsync();

           product=await context.Categories.SingleOrDefaultAsync(s=>s.Id==product.Id);
           var result= mapper.Map<Category, CategoryResources>(product);


              return Ok(result);
        }

             [HttpPut("{Id}")]
        public async Task<IActionResult> EditStudent(int Id, [FromBody]SaveCategoryResources productResources)
        {
            

          if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var product = await context.Categories.SingleOrDefaultAsync(x => x.Id == Id);
            mapper.Map<SaveCategoryResources, Category>(productResources, product);
            
            await context.SaveChangesAsync();
          product=await context.Categories.SingleOrDefaultAsync(s=>s.Id==product.Id);
           var result= mapper.Map<Category, CategoryResources>(product);


              return Ok(result);
        }

             [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
          
          var product=await context.Categories
          .SingleOrDefaultAsync(s=>s.Id==id);
          
           if (product==null)
           return NotFound();
           var result= mapper.Map<Category, CategoryResources>(product);
           return Ok(result);
        }

              [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
          
          var product=await context.Categories
          .ToListAsync();
          
           if (product==null)
           return NotFound();
           var result= mapper.Map<List<Category>, List<CategoryResources>>(product);
           return Ok(result);
        }

        
    }
}