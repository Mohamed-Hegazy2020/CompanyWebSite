using System;
using System.ComponentModel.DataAnnotations;

namespace CompanyWebSiteCore.Models
{
    public class CustomersData
    {
        [Key]
        public int id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNameEn { get; set; }
        public string CustomerDescreption { get; set; }
        public string CustomerDescreptionEn { get; set; }      
        public string CustomerImgPath { get; set; }
        public int Companyid { get; set; }
    }
}
