using System.ComponentModel.DataAnnotations;

namespace AlphaStore.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string  ProductName  { get; set; }

     public Category Categories { get; set; }
     public int CategoryId { get; set; }

      public float PriceBuy { get; set; }
      public float PriceSell { get; set; }

      public Supplier Supliers { get; set; }
      public int SupplierId { get; set; }
      public string Coments { get; set; }

        public int QuantityId { get; set; }
        public Quantity Quantities { get; set; }

    
         public Product()
        {
            
            Quantities = new Quantity();
        }

     
    }
}