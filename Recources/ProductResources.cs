using System.ComponentModel.DataAnnotations;
using AlphaStore.Entities;

namespace AlphaStore.Recources
{
    public class ProductResources
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string  ProductName  { get; set; }

     public Category Categories { get; set; }


      public float Price_Buy { get; set; }
      public float Price_Sell { get; set; }

      public Supplier Supliers { get; set; }
     
      public string Coments { get; set; }

     
        public Quantity Quantities { get; set; }

        public double Price { get; set; }
         public ProductResources()
        {
            
            Quantities = new Quantity();
        } 
    }
}