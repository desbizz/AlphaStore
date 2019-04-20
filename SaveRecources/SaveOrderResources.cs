using System;
using System.ComponentModel.DataAnnotations;

namespace AlphaStore.SaveRecources
{
    public class SaveOrderResources
    {
        public int Id { get; set; }


      
        public int SupplierId { get; set; }
        public int NumberOrdered { get; set; }
         public int NumberShipped { get; set; }
        
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]    
         public DateTime OrderedDate { get; set; }

    }
}