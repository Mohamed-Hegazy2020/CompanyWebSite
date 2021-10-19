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
    public class ServicesDataModelView
    {
        public ServicesDataModelView()
        {          
            //ServicesIcons.Add(new SelectListItem { Value = "fa-desktop", Text = "&#xf108;" });
            //ServicesIcons.Add(new SelectListItem { Value = "fa-cloud-upload", Text = "&#xf0ee;" });
            //ServicesIcons.Add(new SelectListItem { Value = "fa fa-trash", Text = "trash" });
            //ServicesIcons.Add(new SelectListItem { Value = "fa fa-cloud", Text = "cloud" });

            //ServicesIcons.Add(new SelectListItem { Value = "fa fa-code", Text = "code" });
            //ServicesIcons.Add(new SelectListItem { Value = "fa fa-server", Text = "server" });
            //ServicesIcons.Add(new SelectListItem { Value = "fa fa-desktop", Text = "desktop" });
            //ServicesIcons.Add(new SelectListItem { Value = "fa fa-laptop", Text = "laptop" });
            //ServicesIcons.Add(new SelectListItem { Value = "fa fa-shopping-cart", Text = "shopping" });
            //ServicesIcons.Add(new SelectListItem { Value = "fa fa-photo", Text = "photo" });
            //ServicesIcons.Add(new SelectListItem { Value = "fa fa-android", Text = "android" });
            //ServicesIcons.Add(new SelectListItem { Value = "fa fa-apple", Text = "apple" });

            //ServicesIcons.Add(new SelectListItem { Value = "fa fa-camera", Text = "camera" });
            //ServicesIcons.Add(new SelectListItem { Value = "fa fa-coffee", Text = "coffee" });
            //ServicesIcons.Add(new SelectListItem { Value = "fa fa-cogs", Text = "cogs" });
            //ServicesIcons.Add(new SelectListItem { Value = "fa fa-cubes", Text = "cubes" });

            //ServicesIcons.Add(new SelectListItem { Value = "fa fa-envira", Text = "envira" });
            //ServicesIcons.Add(new SelectListItem { Value = "fa fa-edge", Text = "edge" });
            //ServicesIcons.Add(new SelectListItem { Value = "fa fa-gift", Text = "gift" });
            //ServicesIcons.Add(new SelectListItem { Value = "fa fa-gratipay", Text = "gratipay" });

            //ServicesIcons.Add(new SelectListItem { Value = "fa fa-handshake-o", Text = "handshake" });
            //ServicesIcons.Add(new SelectListItem { Value = "fa fa-paint-brush", Text = "paint" });
            //ServicesIcons.Add(new SelectListItem { Value = "fa fa-windows", Text = "windows" });
            //ServicesIcons.Add(new SelectListItem { Value = "glyphicon glyphicon-headphones", Text = "headphones" });

            //ServicesIcons.Add(new SelectListItem { Value = "fa fa-handshake-o", Text = "handshake" });
            //ServicesIcons.Add(new SelectListItem { Value = "glyphicon glyphicon-map-marker", Text = "map-marker" });
            //ServicesIcons.Add(new SelectListItem { Value = "glyphicon glyphicon-print", Text = "print" });
            //ServicesIcons.Add(new SelectListItem { Value = "glyphicon glyphicon-education", Text = "education" });
        }   
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "ServiceTitleDescreption")]
        [StringLength(200, MinimumLength = 30)]
        [Required(ErrorMessage = "ServiceTitleDescreptionMsg")]
        public string ServiceTitleDescreption { get; set; }

        [Display(Name = "ServiceTitleDescreptionEn")]
        public string ServiceTitleDescreptionEn { get; set; }

        [Display(Name = "ServiceName")]
        [Required(ErrorMessage = "ServiceNameMsg")]
        public string ServiceName { get; set; }

        [Display(Name = "ServiceNameEn")]
        public string ServiceNameEn { get; set; }

        [Display(Name = "ServiceDescreption")]       
        public string ServiceDescreption { get; set; }

        [Display(Name = "ServiceDescreptionEn")]
        public string ServiceDescreptionEn { get; set; }

        [Display(Name = "ServiceIcon")]
        [Required(ErrorMessage = "ServiceIconMsg")]
        public string ServiceIcon { get; set; }

        [Display(Name = "Companyid")]
        [Required(ErrorMessage = "CompanyidMsg")]
        public int Companyid { get; set; }
        public List<SelectListItem> Companys = new List<SelectListItem>();

        //public List<SelectListItem> ServicesIcons = new List<SelectListItem>();
        //public List<CompanyData> Companys = new List<CompanyData>();
    }
}
