using System;
using System.ComponentModel.DataAnnotations;


namespace CompanyWebSiteCore.Models
{
    public class ProductsData
    {
        [Key]
        public int id { get; set; }       
        public string ProductName { get; set; }      
        public string ProductNameEn { get; set; }
        public string ProductDescreption { get; set; }
        public string ProductDescreptionEn { get; set; }
        //[Display(Name = "ProductImg")]
        //[Required(ErrorMessage = "ProductImgMsg")]
        //public string ProductImg { get; set; }      
        public string ProductImgPath { get; set; }      
        public int Companyid { get; set; }
    }
}
