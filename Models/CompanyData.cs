using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebSiteCore.Models
{
    public class CompanyData
    {
        [Key]        
        public int id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyNameEn { get; set; }
        public string Address { get; set; }
        public string AddressEn { get; set; }
        public string Email { get; set; }
        public string LogoImage { get; set; }       
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }

        public string WelecomePageTitle { get; set; }
        public string WelecomePageTitleEn { get; set; }
        public string WelecomePageDescription { get; set; }
        public string WelecomePageDescriptionEn { get; set; }

        public string FaceBookLink { get; set; }
        public string TwitterLink { get; set; }
        public string InstgramLink { get; set; }
        public string LinkedinLink { get; set; }

        public string AboutPageHeader { get; set; }
        public string AboutPageHeaderEn { get; set; }
        public string AboutPageDescreption { get; set; }
        public string AboutPageDescreptionEn { get; set; }
        public string FooterAboutDescreption { get; set; }
        public string FooterAboutDescreptionEn { get; set; }
        public string HomeBackGImage { get; set; }
        public string BackGImage { get; set; }

        public string ServicesTitleDescreption { get; set; }
        public string ServicesTitleDescreptionEn { get; set; }

        public string ProductsTitleDescreption { get; set; }
        public string ProductsTitleDescreptionEn { get; set; }

        public string ClientsTitleDescreption { get; set; }
        public string ClientsTitleDescreptionEn { get; set; }

        public string ContactTitleDescreption { get; set; }
        public string ContactTitleDescreptionEn { get; set; }



    }
}
