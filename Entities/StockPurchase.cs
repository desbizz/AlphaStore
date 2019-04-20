using System;
using System.ComponentModel.DataAnnotations;

namespace AlphaStore.Entities
{
    public class StockPurchase
    {
        public int Id { get; set; }
        public Product Products { get; set; }
        public int ProductId { get; set; }

        public int StaffId { get; set; }
        public Staff Staffs { get; set; }
        public Store Stores { get; set; }
        public int StoreId { get; set; }
        public int NumberOrdered { get; set; }
        public Customer Customers { get; set; }
        public int CustomerId { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOrdered { get; set; }
    }
}