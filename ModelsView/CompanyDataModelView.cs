using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using CompanyWebSiteCore.Models;

namespace CompanyWebSiteCore.ModelsView
{
    public class CompanyDataModelView
    {
      
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Display(Name = "CompanyName")]
        [Required(ErrorMessage = "CompanyNameMsg")]
        public string CompanyName { get; set; }

        [Display(Name = "CompanyNameEn")]
        public string CompanyNameEn { get; set; }           

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "AddressEn")]
        public string AddressEn { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        
        [Display(Name = "LogoImage")]
        public string LogoImage { get; set; }

       
        [Display(Name = "BackGImage")]
        public string BackGImage { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Display(Name = "Fax")]
        public string Fax { get; set; }

        //[Required(ErrorMessage = "CompanyNameMsg")]
        [Display(Name = "LogoImage")]
        public IFormFile LogoImageFile { get; set; }

        //[Required(ErrorMessage = "CompanyNameMsg")]
        [Display(Name = "BackGImage")]
        public IFormFile BackGImageFile { get; set; }

        [Display(Name = "WelecomePageTitle")]
        [Required(ErrorMessage = "WelecomePageTitleMsg")]
        public string WelecomePageTitle { get; set; }

        [Display(Name = "WelecomePageTitleEn")]      
        public string WelecomePageTitleEn { get; set; }

        [Display(Name = "WelecomePageDescription")]
        [Required(ErrorMessage = "WelecomePageDescriptionMsg")]
        public string WelecomePageDescription { get; set; }

        [Display(Name = "WelecomePageDescriptionEn")]
        public string WelecomePageDescriptionEn { get; set; }
        [Display(Name = "FooterAboutDescreption")]
        public string FooterAboutDescreption { get; set; }
        [Display(Name = "FooterAboutDescreptionEn")]
        public string FooterAboutDescreptionEn { get; set; }
        [Display(Name = "HomeBackGImage")]
        public string HomeBackGImage { get; set; }
        [Display(Name = "HomeBackGImageFile")]
        public IFormFile HomeBackGImageFile { get; set; }

        [Display(Name = "FaceBookLink")]
        public string FaceBookLink { get; set; }

        [Display(Name = "TwitterLink")]
        public string TwitterLink { get; set; }

        [Display(Name = "InstgramLink")]
        public string InstgramLink { get; set; }

        [Display(Name = "LinkedinLink")]
        public string LinkedinLink { get; set; }

        [Display(Name = "AboutPageHeader")]
        [Required(ErrorMessage = "AboutPageHeaderMsg")]
        public string AboutPageHeader { get; set; }
        [Display(Name = "AboutPageHeaderEn")]
        public string AboutPageHeaderEn { get; set; }

        [Display(Name = "AboutPageDescreption")]
        [Required(ErrorMessage = "AboutPageDescreptionMsg")]
        public string AboutPageDescreption { get; set; }


        [Display(Name = "AboutPageDescreptionEn")]
        public string AboutPageDescreptionEn { get; set; }
        [Display(Name = "ServicesTitleDescreption")]
        public string ServicesTitleDescreption { get; set; }
        [Display(Name = "ServicesTitleDescreptionEn")]
        public string ServicesTitleDescreptionEn { get; set; }
        [Display(Name = "ProductsTitleDescreption")]
        public string ProductsTitleDescreption { get; set; }
        [Display(Name = "ProductsTitleDescreptionEn")]
        public string ProductsTitleDescreptionEn { get; set; }
        [Display(Name = "ClientsTitleDescreption")]
        public string ClientsTitleDescreption { get; set; }
        [Display(Name = "ClientsTitleDescreptionEn")]
        public string ClientsTitleDescreptionEn { get; set; }
        [Display(Name = "ContactTitleDescreption")]
        public string ContactTitleDescreption { get; set; }
        [Display(Name = "ContactTitleDescreptionEn")]
        public string ContactTitleDescreptionEn { get; set; }





        public IList<ServicesData> ServicesLst = new List<ServicesData>();
        public IList<ProductsData> ProductsLst = new List<ProductsData>();
        public IList<CustomersData> CustomersLst = new List<CustomersData>();
    }
}
