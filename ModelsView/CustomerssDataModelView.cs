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
    public class CustomerssDataModelView
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "CustomerName")]
        [Required(ErrorMessage = "CustomerNameMsg")]
        public string CustomerName { get; set; }

        [Display(Name = "CustomerNameEn")]
        public string CustomerNameEn { get; set; }

        [Display(Name = "CustomerDescreption")]
        public string CustomerDescreption { get; set; }

        [Display(Name = "CustomerDescreptionEn")]
        public string CustomerDescreptionEn { get; set; }

        public string CustomerImgName { get; set; }

        [Display(Name = "CustomerImg")]
        public IFormFile CustomerImg { get; set; }

      

        [Display(Name = "Companyid")]
        [Required(ErrorMessage = "CompanyidMsg")]
        public int Companyid { get; set; }


        public List<SelectListItem> Companys = new List<SelectListItem>();
    }
}
