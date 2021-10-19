using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using CompanyWebSiteCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyWebSiteCore.ModelsView
{
    public class ProductsDataModelView
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }       

        [Display(Name = "ProductName")]
        [Required(ErrorMessage = "ProductNameMsg")]
        public string ProductName { get; set; }

        [Display(Name = "ProductNameEn")]
        public string ProductNameEn { get; set; }

        [Display(Name = "ProductDescreption")]
        public string ProductDescreption { get; set; }

        [Display(Name = "ProductDescreptionEn")]
        public string ProductDescreptionEn { get; set; }

        //[Display(Name = "ProductImg")]
        //[Required(ErrorMessage = "ProductImgMsg")]
        public string ProductImgName { get; set; }

        [Display(Name = "ProductImg")]
        public IFormFile ProductImg { get; set; }

        [Display(Name = "Companyid")]
        [Required(ErrorMessage = "CompanyidMsg")]
        public int Companyid { get; set; }

        
        public List<SelectListItem> Companys = new List<SelectListItem>();
    }
}
