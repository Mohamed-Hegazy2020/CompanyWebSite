using CompanyWebSiteCore.Models;
using CompanyWebSiteCore.Models.Repositores;
using CompanyWebSiteCore.ModelsView;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace CompanyWebSiteCore.Controllers
{
    public class CompanyDataController : Controller
    {
        private readonly IRepository<CompanyData> companyRep;
        private readonly IHostingEnvironment hosting;
        public CompanyDataController(IRepository<CompanyData> companyRep,IHostingEnvironment hosting)
        {
            this.companyRep = companyRep;
            this.hosting = hosting;
        }
     
        public ActionResult Index()
        {
            return View(convertToModelView(companyRep.list()));
        }
  
        public ActionResult Details(int id)
        {
            return View();
        }
       
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyDataModelView c)
        {
            try
            {
                companyRep.Add(convertToEntity(c));
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View(c);
            }
        }
      
        public ActionResult Edit(int id)
        {
            var comp = companyRep.Find(id);
            return View(convertToModelView(comp));
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CompanyDataModelView c)
        {
            try
            {
                companyRep.Update(convertToEntity(c),id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }
      
        public ActionResult Delete(int id)
        {
            try
            {
                companyRep.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public IActionResult GetConpanyLogo()
        {
            try
            {
                CompanyData comp = new CompanyData() ;
               var c = companyRep.list();
                if (c.Count>0)
                {
                    comp = c.FirstOrDefault();
                   
                }
                var serialized = JsonConvert.SerializeObject(comp);
                
                return Content(serialized, "application/json");
                //return Json(comp);

            }
            catch (Exception ex)
            {

                throw;
            }         

        }

       
        public CompanyData convertToEntity(CompanyDataModelView cm)
        {
            string LogoImageName = "";
            if (cm.LogoImageFile!=null)
            {
                string uploads = Path.Combine(hosting.WebRootPath, "CompanyImages");
                LogoImageName = cm.LogoImageFile.FileName;
                string fullPath = Path.Combine(uploads, LogoImageName);
                string oldPath= Path.Combine(uploads, cm.LogoImage!=null? cm.LogoImage:"");
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                    cm.LogoImageFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                else
                {
                    cm.LogoImageFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
               
            }

            string BackGImageName = "";
            if (cm.BackGImageFile != null)
            {
                string uploads = Path.Combine(hosting.WebRootPath, "CompanyImages");
                BackGImageName = cm.BackGImageFile.FileName;
                string fullPath = Path.Combine(uploads, BackGImageName);
                string oldPath = Path.Combine(uploads, cm.BackGImage != null ? cm.BackGImage : "");
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                    cm.BackGImageFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                else
                {
                    cm.BackGImageFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                }


            }

            string HomeBackGImage = "";
            //string newImagName="";;
            if (cm.HomeBackGImageFile != null)
            {
                string uploads = Path.Combine(hosting.WebRootPath, "HomeBackGImage");
                HomeBackGImage = cm.HomeBackGImageFile.FileName;
                //newImagName = "HomeBackGImageFile" + Path.GetExtension(cm.HomeBackGImageFile.FileName);
                string fullPath = Path.Combine(uploads, HomeBackGImage);

                //string oldPath = Path.Combine(uploads, cm.HomeBackGImage != null ? cm.HomeBackGImage : "");
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                    cm.HomeBackGImageFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                else
                {
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);

                    }
                    cm.HomeBackGImageFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                }


            }

            CompanyData c = new CompanyData();
            c.CompanyName = cm.CompanyName;
            c.CompanyNameEn = cm.CompanyNameEn;
            c.Address = cm.Address;
            c.AddressEn = cm.AddressEn;
            c.Email = cm.Email;
            c.Phone = cm.Phone;
            c.Mobile = cm.Mobile != null ? cm.Mobile : "";
            c.Fax = cm.Fax != null ? cm.Fax : "";
            c.FaceBookLink = cm.FaceBookLink;
            c.TwitterLink = cm.TwitterLink;
            c.LinkedinLink = cm.LinkedinLink;
            c.InstgramLink = cm.InstgramLink;
            c.WelecomePageTitle = cm.WelecomePageTitle;
            c.WelecomePageTitleEn = cm.WelecomePageTitleEn;
            c.WelecomePageDescription = cm.WelecomePageDescription;
            c.WelecomePageDescriptionEn = cm.WelecomePageDescriptionEn;

            c.ServicesTitleDescreption = cm.ServicesTitleDescreption;
            c.ServicesTitleDescreptionEn = cm.ServicesTitleDescreptionEn;
            c.ProductsTitleDescreption = cm.ProductsTitleDescreption;
            c.ProductsTitleDescreptionEn = cm.ProductsTitleDescreptionEn;
            c.ClientsTitleDescreption = cm.ClientsTitleDescreption;
            c.ClientsTitleDescreptionEn = cm.ClientsTitleDescreptionEn;
            c.ContactTitleDescreption = cm.ContactTitleDescreption;
            c.ContactTitleDescreptionEn = cm.ContactTitleDescreptionEn;

            c.AboutPageHeader = cm.AboutPageHeader;
            c.AboutPageHeaderEn = cm.AboutPageHeaderEn;
            c.AboutPageDescreption = cm.AboutPageDescreption;
            c.AboutPageDescreptionEn = cm.AboutPageDescreptionEn;
            c.FooterAboutDescreption = cm.FooterAboutDescreption;
            c.FooterAboutDescreptionEn = cm.FooterAboutDescreptionEn;


            c.BackGImage = BackGImageName!=""? BackGImageName:cm.BackGImage;
            c.LogoImage = LogoImageName != "" ? LogoImageName : cm.LogoImage;
            c.HomeBackGImage = HomeBackGImage != "" ? HomeBackGImage : cm.HomeBackGImage;
            return c;

        }

        public IList<CompanyDataModelView> convertToModelView(IList<CompanyData> cm)
        {
            IList<CompanyDataModelView> data = cm.Select(x =>
            {
                CompanyDataModelView c = new CompanyDataModelView();
                c.id = x.id;
                c.CompanyName = x.CompanyName != null ? x.CompanyName : "";
                c.Address = x.Address!=null? x.Address:"";
                c.Email = x.Email!=null? x.Email:"";
                c.Phone = x.Phone != null ? x.Phone : "";
                c.BackGImage = x.BackGImage != null ? x.BackGImage : "";
                c.LogoImage = x.LogoImage != null ? x.LogoImage : "";
                return c; 
            }).ToList();

            return data;
        }

        public CompanyDataModelView convertToModelView(CompanyData cm)
        {
            CompanyDataModelView c = new CompanyDataModelView();
            c.id = cm.id;
            c.CompanyName = cm.CompanyName != null ? cm.CompanyName : "";
            c.CompanyNameEn = cm.CompanyNameEn;
            c.Address = cm.Address != null ? cm.Address : "";
            c.AddressEn = cm.AddressEn;
            c.Email = cm.Email != null ? cm.Email : "";
            c.FaceBookLink = cm.FaceBookLink;
            c.TwitterLink = cm.TwitterLink;
            c.LinkedinLink = cm.LinkedinLink;
            c.InstgramLink = cm.InstgramLink;
            c.WelecomePageTitle = cm.WelecomePageTitle;
            c.WelecomePageTitleEn = cm.WelecomePageTitleEn;
            c.WelecomePageDescription = cm.WelecomePageDescription;
            c.WelecomePageDescriptionEn = cm.WelecomePageDescriptionEn;
            c.Phone = cm.Phone != null ? cm.Phone : "";
            c.Mobile = cm.Mobile != null ? cm.Mobile : "";
            c.Fax = cm.Fax != null ? cm.Fax : "";

            c.AboutPageHeader = cm.AboutPageHeader;
            c.AboutPageHeaderEn = cm.AboutPageHeaderEn;
            c.AboutPageDescreption = cm.AboutPageDescreption;
            c.AboutPageDescreptionEn = cm.AboutPageDescreptionEn;

            c.ServicesTitleDescreption = cm.ServicesTitleDescreption;
            c.ServicesTitleDescreptionEn = cm.ServicesTitleDescreptionEn;
            c.ProductsTitleDescreption = cm.ProductsTitleDescreption;
            c.ProductsTitleDescreptionEn = cm.ProductsTitleDescreptionEn;
            c.ClientsTitleDescreption = cm.ClientsTitleDescreption;
            c.ClientsTitleDescreptionEn = cm.ClientsTitleDescreptionEn;
            c.ContactTitleDescreption = cm.ContactTitleDescreption;
            c.ContactTitleDescreptionEn = cm.ContactTitleDescreptionEn;
            c.FooterAboutDescreption = cm.FooterAboutDescreption;
            c.FooterAboutDescreptionEn = cm.FooterAboutDescreptionEn;

            c.BackGImage = cm.BackGImage != null ? cm.BackGImage : "";
            c.LogoImage = cm.LogoImage != null ? cm.LogoImage : "";
            c.HomeBackGImage = cm.HomeBackGImage != null ? cm.HomeBackGImage :"";
            return c;          
        }
    }
}
