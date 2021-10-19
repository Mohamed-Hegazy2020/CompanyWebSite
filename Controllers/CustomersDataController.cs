using CompanyWebSiteCore.Models;
using CompanyWebSiteCore.Models.Repositores;
using CompanyWebSiteCore.ModelsView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
namespace CompanyWebSiteCore.Controllers
{

    public class CustomersDataController : Controller
    {
        private readonly IRepository<CustomersData> srvsRep;
        private readonly IRepository<CompanyData> companyRep;
        private readonly IHostingEnvironment hosting;
        public CustomersDataController(IRepository<CustomersData> srvsRep, IRepository<CompanyData> companyRep, IHostingEnvironment hosting)
        {
            this.srvsRep = srvsRep;
            this.companyRep = companyRep;
            this.hosting = hosting;
        }
        // GET: CustomersDataController
        public ActionResult Index()
        {
            return View(convertToModelView(srvsRep.list()));
        }

        // GET: CustomersDataController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomersDataController/Create
        public ActionResult Create()
        {
            var Service = new CustomerssDataModelView();
            var comps = companyRep.list().Select(x => new CompanyData
            {
                CompanyName = Thread.CurrentThread.CurrentUICulture.CompareInfo.Name == "ar" ? x.CompanyName : x.CompanyNameEn,
                id = x.id
            }).ToList();
            foreach (var item in comps)
            {
                Service.Companys.Add(new SelectListItem { Value = item.id.ToString(), Text = item.CompanyName });
            }

            return View(Service);
        }

        // POST: CustomersDataController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerssDataModelView c)
        {
            try
            {
                srvsRep.Add(convertToEntity(c));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(c);
            }
        }

        // GET: CustomersDataController/Edit/5
        public ActionResult Edit(int id)
        {
            var comp = srvsRep.Find(id);
            return View(convertToModelView(comp));
        }

        // POST: CustomersDataController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerssDataModelView c)
        {
            try
            {
                srvsRep.Update(convertToEntity(c), id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(c);
            }
        }

        // GET: CustomersDataController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                srvsRep.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: CustomersDataController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        public IList<CustomerssDataModelView> convertToModelView(IList<CustomersData> cm)
        {
            IList<CustomerssDataModelView> data = cm.Select(x =>
            {
                CustomerssDataModelView c = new CustomerssDataModelView();
                c.id = x.id;
                c.CustomerName = x.CustomerName != null ? x.CustomerName : "";
                c.CustomerNameEn = x.CustomerNameEn != null ? x.CustomerNameEn : "";
                c.CustomerDescreption = x.CustomerDescreption != null ? x.CustomerDescreption : "";
                c.CustomerDescreptionEn = x.CustomerDescreptionEn != null ? x.CustomerDescreptionEn : "";
                //c.CustomerImg = x.ServiceDescreption != null ? x.ServiceDescreption : "";               
                c.Companyid = x.Companyid;
                return c;
            }).ToList();

            return data;
        }

        public CustomersData convertToEntity(CustomerssDataModelView cm)
        {
            string CustomerImgName = "";
            if (cm.CustomerImg != null)
            {
                string uploads = Path.Combine(hosting.WebRootPath, "CustomersImages");
                CustomerImgName = cm.CustomerImg.FileName;
                string fullPath = Path.Combine(uploads, CustomerImgName);
                string oldPath = Path.Combine(uploads, cm.CustomerImgName != null ? cm.CustomerImgName : "");
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                    cm.CustomerImg.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                else
                {
                    cm.CustomerImg.CopyTo(new FileStream(fullPath, FileMode.Create));
                }

            }
            CustomersData c = new CustomersData();
            c.id = cm.id;
            c.CustomerName = cm.CustomerName != null ? cm.CustomerName : "";
            c.CustomerNameEn = cm.CustomerNameEn != null ? cm.CustomerNameEn : "";
            c.CustomerDescreption = cm.CustomerDescreption != null ? cm.CustomerDescreption : "";
            c.CustomerDescreptionEn = cm.CustomerDescreptionEn != null ? cm.CustomerDescreptionEn : "";           
            c.Companyid = cm.Companyid;
            c.CustomerImgPath = CustomerImgName != "" ? CustomerImgName : cm.CustomerImgName;
            return c;

        }

        public CustomerssDataModelView convertToModelView(CustomersData cm)
        {
            CustomerssDataModelView c = new CustomerssDataModelView();
            c.id = cm.id;
            c.CustomerName = cm.CustomerName != null ? cm.CustomerName : "";
            c.CustomerNameEn = cm.CustomerNameEn != null ? cm.CustomerNameEn : "";
            c.CustomerDescreption = cm.CustomerDescreption != null ? cm.CustomerDescreption : "";
            c.CustomerDescreptionEn = cm.CustomerDescreptionEn != null ? cm.CustomerDescreptionEn : "";           
            c.Companyid = cm.Companyid;            
            c.CustomerImgName = cm.CustomerImgPath != null ? cm.CustomerImgPath : "";
            var comps = companyRep.list().Select(x => new CompanyData
            {
                CompanyName = Thread.CurrentThread.CurrentUICulture.CompareInfo.Name == "ar" ? x.CompanyName : x.CompanyNameEn,
                id = x.id
            }).ToList();
            foreach (var item in comps)
            {
                c.Companys.Add(new SelectListItem { Value = item.id.ToString(), Text = item.CompanyName });
            }
            return c;

        }
    }
}
