using CompanyWebSiteCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using CompanyWebSiteCore.Models.Repositores;
using CompanyWebSiteCore.ModelsView;
using System.Threading;
using MimeKit;
using MailKit.Net.Smtp;

namespace CompanyWebSiteCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<CompanyData> companyRep;
        private readonly IRepository<ServicesData> srvsRep;
        private readonly IRepository<ProductsData> prodsRep;
        private readonly IRepository<CustomersData> custRep;
        public HomeController(ILogger<HomeController> logger , IRepository<CompanyData> companyRep, IRepository<ServicesData> srvsRep, IRepository<ProductsData> prodsRep, IRepository<CustomersData> custRep)
        {
            _logger = logger;
            this.companyRep = companyRep;
            this.srvsRep = srvsRep;
            this.prodsRep = prodsRep;
            this.custRep = custRep;
        }

        public ActionResult Index()
        {
            try
            {
                CompanyDataModelView c = new CompanyDataModelView();
                var cm = companyRep.GetCompanyData();
                if (cm != null)
                {
                    // ViewBag.imgUrl = "background - image : url('@Url.Content("+"/ HomeBackGImage /" + cm.HomeBackGImage+")')";
                    if (Thread.CurrentThread.CurrentUICulture.CompareInfo.Name == "ar")
                    {
                        c.id = cm.id;
                        c.CompanyName = cm.CompanyName != null ? cm.CompanyName : "";
                        //c.CompanyNameEn = cm.CompanyNameEn;
                        c.Address = cm.Address != null ? cm.Address : "";
                        //c.AddressEn = cm.AddressEn;
                        c.Email = cm.Email != null ? cm.Email : "";
                        c.FaceBookLink = cm.FaceBookLink;
                        c.TwitterLink = cm.TwitterLink;
                        c.LinkedinLink = cm.LinkedinLink;
                        c.InstgramLink = cm.InstgramLink;
                        c.WelecomePageTitle = cm.WelecomePageTitle;
                        //c.WelecomePageTitleEn = cm.WelecomePageTitleEn;
                        c.WelecomePageDescription = cm.WelecomePageDescription;
                        //c.WelecomePageDescriptionEn = cm.WelecomePageDescriptionEn;
                        c.Phone = cm.Phone != null ? cm.Phone : "";
                        c.Mobile = cm.Mobile != null ? cm.Mobile : "";

                        c.AboutPageHeader = cm.AboutPageHeader;
                        //c.AboutPageHeaderEn = cm.AboutPageHeaderEn;
                        c.AboutPageDescreption = cm.AboutPageDescreption;
                        //c.AboutPageDescreptionEn = cm.AboutPageDescreptionEn;

                        c.ServicesTitleDescreption = cm.ServicesTitleDescreption;
                        //c.ServicesTitleDescreptionEn = cm.ServicesTitleDescreptionEn;
                        c.ProductsTitleDescreption = cm.ProductsTitleDescreption;
                        //c.ProductsTitleDescreptionEn = cm.ProductsTitleDescreptionEn;
                        c.ClientsTitleDescreption = cm.ClientsTitleDescreption;
                        //c.ClientsTitleDescreptionEn = cm.ClientsTitleDescreptionEn;
                        c.ContactTitleDescreption = cm.ContactTitleDescreption;
                        //c.ContactTitleDescreptionEn = cm.ContactTitleDescreptionEn;

                        c.BackGImage = cm.BackGImage != null ? cm.BackGImage : "";
                        c.LogoImage = cm.LogoImage != null ? cm.LogoImage : "";
                        c.HomeBackGImage = cm.HomeBackGImage != null ? cm.HomeBackGImage : "";
                        c.ServicesLst = srvsRep.list();
                        c.ProductsLst = prodsRep.list();
                        c.CustomersLst = custRep.list();
                        ViewData["Title"]=c.CompanyName;
                    }
                    else
                    {
                        c.id = cm.id;
                        c.CompanyName = cm.CompanyNameEn != null ? cm.CompanyNameEn : "";
                        //c.CompanyNameEn = cm.CompanyNameEn;
                        c.Address = cm.AddressEn != null ? cm.AddressEn : "";
                        //c.AddressEn = cm.AddressEn;
                        c.Email = cm.Email != null ? cm.Email : "";
                        c.FaceBookLink = cm.FaceBookLink;
                        c.TwitterLink = cm.TwitterLink;
                        c.LinkedinLink = cm.LinkedinLink;
                        c.InstgramLink = cm.InstgramLink;
                        c.WelecomePageTitle = cm.WelecomePageTitleEn;
                        //c.WelecomePageTitleEn = cm.WelecomePageTitleEn;
                        c.WelecomePageDescription = cm.WelecomePageDescriptionEn;
                        //c.WelecomePageDescriptionEn = cm.WelecomePageDescriptionEn;
                        c.Phone = cm.Phone != null ? cm.Phone : "";
                        c.Mobile = cm.Mobile != null ? cm.Mobile : "";

                        c.AboutPageHeader = cm.AboutPageHeaderEn;
                        //c.AboutPageHeaderEn = cm.AboutPageHeaderEn;
                        c.AboutPageDescreption = cm.AboutPageDescreptionEn;
                        //c.AboutPageDescreptionEn = cm.AboutPageDescreptionEn;

                        c.ServicesTitleDescreption = cm.ServicesTitleDescreptionEn;
                        //c.ServicesTitleDescreptionEn = cm.ServicesTitleDescreptionEn;
                        c.ProductsTitleDescreption = cm.ProductsTitleDescreptionEn;
                        //c.ProductsTitleDescreptionEn = cm.ProductsTitleDescreptionEn;
                        c.ClientsTitleDescreption = cm.ClientsTitleDescreptionEn;
                        //c.ClientsTitleDescreptionEn = cm.ClientsTitleDescreptionEn;
                        c.ContactTitleDescreption = cm.ContactTitleDescreptionEn;
                        //c.ContactTitleDescreptionEn = cm.ContactTitleDescreptionEn;

                        c.BackGImage = cm.BackGImage != null ? cm.BackGImage : "";
                        c.LogoImage = cm.LogoImage != null ? cm.LogoImage : "";
                        c.HomeBackGImage = cm.HomeBackGImage != null ? cm.HomeBackGImage : "";
                        c.ServicesLst = srvsRep.list();
                        c.ProductsLst = prodsRep.list();
                        c.CustomersLst = custRep.list();
                        ViewData["Title"] = c.CompanyName;
                    }

                }
                return View(c);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
