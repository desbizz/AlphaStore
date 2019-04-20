using System.ComponentModel.DataAnnotations;
using AlphaStore.Entities;

namespace AlphaStore.SaveRecources
{
    public class SaveProductResources
    {
         public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string  ProductName  { get; set; }


     public int CategoryId { get; set; }

      public float Price_Buy { get; set; }
      public float Price_Sell { get; set; }


      public int SupplierId { get; set; }
      public string Coments { get; set; }

      public int QuantityId { get; set; }


        public double Price { get; set; }
        //  public SaveProductResources()
        // {

        //     Quantities = new Quantity();
        // }
    }
}