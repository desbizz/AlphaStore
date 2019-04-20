using System;
using System.ComponentModel.DataAnnotations;

namespace AlphaStore.SaveRecources
{
    public class SaveStockPurchaseResources
    {
          public int Id { get; set; }
           public int ProductId { get; set; }

        public int StaffId { get; set; }
      
        public int StoreId { get; set; }
        public int NumberOrdered { get; set; }
     
        public int CustomerId { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOrdered { get; set; }
    }
}