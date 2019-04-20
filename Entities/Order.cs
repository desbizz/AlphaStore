using System;
using System.ComponentModel.DataAnnotations;

namespace AlphaStore.Entities
{
    public class Order
    {
        public int Id { get; set; }


        public Supplier Suppliers { get; set; }
        public int SupplierId { get; set; }
        public int NumberOrdered { get; set; }
         public int NumberShipped { get; set; }
        
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]    
         public DateTime OrderedDate { get; set; }

    }
}