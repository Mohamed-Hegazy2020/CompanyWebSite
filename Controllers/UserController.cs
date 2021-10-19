using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CompanyWebSiteCore.Models;
using CompanyWebSiteCore.Models.Repositores;
using CompanyWebSiteCore.ModelsView;
using System;
using System.Threading;
using MimeKit;
using MailKit.Net.Smtp;

namespace CompanyWebSiteCore.Controllers
{
    
    public class UserController : Controller
    {
        private readonly IRepository<CompanyData> companyRep;
        private readonly IRepository<ServicesData> srvsRep;
        private readonly IRepository<ProductsData> prodsRep;
        private readonly IRepository<CustomersData> custRep;
        public UserController(IRepository<CompanyData> companyRep, IRepository<ServicesData> srvsRep, IRepository<ProductsData> prodsRep, IRepository<CustomersData> custRep)
        {
            this.companyRep = companyRep;
            this.srvsRep = srvsRep;
            this.prodsRep = prodsRep;
            this.custRep = custRep;
        }
        // GET: UserController
        public ActionResult Index()
        {
            try
            {
                CompanyDataModelView c = new CompanyDataModelView();
                var cm = companyRep.GetCompanyData();
                if (cm!=null)
                {
                   // ViewBag.imgUrl = "background - image : url('@Url.Content("+"/ HomeBackGImage /" + cm.HomeBackGImage+")')";
                    if (Thread.CurrentThread.CurrentUICulture.CompareInfo.Name=="ar")
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
                    }
                    
                }
                return View(c);

            }
            catch (Exception)
            {

                throw;
            }
           
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult SendEmail(string from, string Subject,string bodyid)
        {
            try
            {
                var mailMessage = new MimeMessage();
                mailMessage.From.Add(new MailboxAddress("from name", from));
                mailMessage.To.Add(new MailboxAddress("to name", "mohamed.asd.2010@gmail.com"));
                mailMessage.Subject = Subject;
                mailMessage.Body = new TextPart("plain")
                {
                    Text = bodyid
                };

                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.Connect("smtp.gmail.com", 465, true);
                    smtpClient.Authenticate("mohamed.asd.2010@gmail.com", "mohamed@2020");
                    smtpClient.Send(mailMessage);
                    smtpClient.Disconnect(true);

                }

                return Json("تم");
            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }
            
        }
    }
}
