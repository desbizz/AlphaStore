using System;
using System.ComponentModel.DataAnnotations;
using AlphaStore.Entities;

namespace AlphaStore.Recources
{
    public class StockPurchaseResources
    {
          public int Id { get; set; }
        public Product Products { get; set; }
      
        public Staff Staffs { get; set; }
        public Store Stores { get; set; }
        public int NumberOrdered { get; set; }
        public Customer Customers { get; set; }
    
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOrdered { get; set; }
    }
}