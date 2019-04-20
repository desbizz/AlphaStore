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
     [Route("/api/product/")]
    public class ProductController :Controller
    {
        private readonly IMapper mapper;
        private readonly ProfileContext context;

        public ProductController(IMapper mapper, ProfileContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

         [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]SaveProductResources productResources)
        {
          //  individualResourses.Id = 0;

            if (!ModelState.IsValid)
              return BadRequest(ModelState);
            
               var product=  mapper.Map<SaveProductResources, Product>(productResources);
              
           // individual.Id = 0;
            context.Add(product);
           await context .SaveChangesAsync();

           product=await context.Products.SingleOrDefaultAsync(s=>s.Id==product.Id);
           var result= mapper.Map<Product, ProductResources>(product);


              return Ok(result);
        }

             [HttpPut("{Id}")]
        public async Task<IActionResult> EditStudent(int Id, [FromBody]SaveProductResources productResources)
        {
            

          if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var product = await context.Products.SingleOrDefaultAsync(x => x.Id == Id);
            mapper.Map<SaveProductResources, Product>(productResources, product);
            
            await context.SaveChangesAsync();
          product=await context.Products.SingleOrDefaultAsync(s=>s.Id==product.Id);
           var result= mapper.Map<Product, ProductResources>(product);


              return Ok(result);
        }

             [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
          
          var product=await context.Products
          .SingleOrDefaultAsync(s=>s.Id==id);
          
           if (product==null)
           return NotFound();
           var result= mapper.Map<Product, ProductResources>(product);
           return Ok(result);
        }

        //  [HttpGet]
        // public async Task<List<ProductResources>> GetIndividuals(queryItem filterResourse)
        // {
        //   //  var filter = mapper.Map<IndividualQueryResourses, IndividualQuery>(filterResourse);
        //      var result = new List<Student>();
        //   //   StringBuilder b = new StringBuilder(filterResourse.MatricNumber);
        //    //  filterResourse.MatricNumber.Replace("%252F", "");
        //     var query = context.Students
        //     .Include(f=>f.Levels)
        //     .Include(s=>s.SubUnits)
        //     .ThenInclude(u=>u.Units)
        //     .Include(p=>p.Payment)
        //     .ThenInclude(f=>f.Fees)
        //        .AsQueryable();
        //     if (filterResourse.Surname!= null)
        //         query = query.Where(i => i.Surname == filterResourse.Surname );
        //     if (filterResourse.MatricNumber!= null)
        //         query = query.Where(i =>  i.MatricNumber == filterResourse.MatricNumber);

        //      if (filterResourse.Firstname!= null)
        //         query = query.Where(i =>  i.Firstname == filterResourse.Firstname);
                
        //       result= await query.ToListAsync();

            

        //     return mapper.Map<List<Student>, List<StudentResources>>(result);
           
        // }


        
    }
}