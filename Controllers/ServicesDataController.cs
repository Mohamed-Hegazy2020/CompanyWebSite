using CompanyWebSiteCore.Models;
using CompanyWebSiteCore.Models.Repositores;
using CompanyWebSiteCore.ModelsView;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CompanyWebSiteCore.Controllers
{
    public class ServicesDataController : Controller
    {

        private readonly IRepository<ServicesData> srvsRep;
        private readonly IRepository<CompanyData> companyRep;
      
        public ServicesDataController(IRepository<ServicesData> srvsRep, IRepository<CompanyData> companyRep)
        {
            this.srvsRep = srvsRep;
            this.companyRep = companyRep;
        }
        // GET: ServicesDataController
        public ActionResult Index()
        {
            return View(convertToModelView(srvsRep.list()));
        }

        // GET: ServicesDataController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServicesDataController/Create
        public ActionResult Create()
        {
            var Service = new ServicesDataModelView();
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

        // POST: ServicesDataController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServicesDataModelView c)
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

        // GET: ServicesDataController/Edit/5
        public ActionResult Edit(int id)
        {
            var comp = srvsRep.Find(id);
            return View(convertToModelView(comp));
        }

        // POST: ServicesDataController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ServicesDataModelView c)
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

       
        // POST: ServicesDataController/Delete/5      
      
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

        public IList<ServicesDataModelView> convertToModelView(IList<ServicesData> cm)
        {
            IList<ServicesDataModelView> data = cm.Select(x =>
            {
                ServicesDataModelView c = new ServicesDataModelView();
                c.id = x.id;
                c.ServiceName = x.ServiceName != null ? x.ServiceName : "";
                c.ServiceNameEn = x.ServiceNameEn != null ? x.ServiceNameEn : "";
                c.ServiceTitleDescreption = x.ServiceTitleDescreption != null ? x.ServiceTitleDescreption : "";
                c.ServiceTitleDescreptionEn = x.ServiceTitleDescreptionEn != null ? x.ServiceTitleDescreptionEn : "";
                c.ServiceDescreption = x.ServiceDescreption != null ? x.ServiceDescreption : "";
                c.ServiceDescreptionEn = x.ServiceDescreptionEn != null ? x.ServiceDescreptionEn : "";
                c.ServiceIcon = x.ServiceIcon != null ? x.ServiceIcon : "";
                c.Companyid = x.Companyid;
                return c;
            }).ToList();

            return data;
        }

        public ServicesDataModelView convertToModelView(ServicesData cm)
        {
            ServicesDataModelView c = new ServicesDataModelView();
            c.id = cm.id;
            c.ServiceName = cm.ServiceName != null ? cm.ServiceName : "";
            c.ServiceNameEn = cm.ServiceNameEn != null ? cm.ServiceNameEn : "";
            c.ServiceTitleDescreption = cm.ServiceTitleDescreption != null ? cm.ServiceTitleDescreption : "";
            c.ServiceTitleDescreptionEn = cm.ServiceTitleDescreptionEn != null ? cm.ServiceTitleDescreptionEn : "";
            c.ServiceDescreption = cm.ServiceDescreption != null ? cm.ServiceDescreption : "";
            c.ServiceDescreptionEn = cm.ServiceDescreptionEn != null ? cm.ServiceDescreptionEn : "";
            c.ServiceIcon = cm.ServiceIcon != null ? cm.ServiceIcon : "";
            c.Companyid = cm.Companyid;

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

        public ServicesData convertToEntity(ServicesDataModelView cm)
        {

            ServicesData c = new ServicesData();
            c.id = cm.id;
            c.ServiceName = cm.ServiceName != null ? cm.ServiceName : "";
            c.ServiceNameEn = cm.ServiceNameEn != null ? cm.ServiceNameEn : "";
            c.ServiceTitleDescreption = cm.ServiceTitleDescreption != null ? cm.ServiceTitleDescreption : "";
            c.ServiceTitleDescreptionEn = cm.ServiceTitleDescreptionEn != null ? cm.ServiceTitleDescreptionEn : "";
            c.ServiceDescreption = cm.ServiceDescreption != null ? cm.ServiceDescreption : "";
            c.ServiceDescreptionEn = cm.ServiceDescreptionEn != null ? cm.ServiceDescreptionEn : "";
            c.ServiceIcon = cm.ServiceIcon != null ? cm.ServiceIcon : "";
            c.Companyid = cm.Companyid;

            return c;

        }
    }
}
