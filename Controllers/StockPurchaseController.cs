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
      [Route("/api/stockpurchase/")]
    public class StockPurchaseController:Controller
    {
         private readonly IMapper mapper;
        private readonly ProfileContext context;

        public StockPurchaseController(IMapper mapper, ProfileContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

         [HttpPost]
        public async Task<IActionResult> CreateStock([FromBody]SaveStockPurchaseResources stockResources)
        {
          //  individualResourses.Id = 0;

            if (!ModelState.IsValid)
              return BadRequest(ModelState);
            
               var Stock=  mapper.Map<SaveStockPurchaseResources, StockPurchase>(stockResources);
              
           // individual.Id = 0;
            context.Add(Stock);
           await context .SaveChangesAsync();

           Stock=await context.StockPurchases.SingleOrDefaultAsync(s=>s.Id==stockResources.Id);
           var result= mapper.Map<StockPurchase, SaveStockPurchaseResources>(Stock);


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
        public async Task<IActionResult> GetStock(int id)
        {
          
          var Stock=await context.StockPurchases
          .SingleOrDefaultAsync(s=>s.Id==id);
          
           if (Stock==null)
           return NotFound();
           var result= mapper.Map<StockPurchase, StockPurchaseResources>(Stock);
           return Ok(result);
        }

        
    }
}