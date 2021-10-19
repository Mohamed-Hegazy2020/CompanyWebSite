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

    public class ProductsDataController : Controller
    {
        private readonly IRepository<ProductsData> srvsRep;
        private readonly IRepository<CompanyData> companyRep;
        private readonly IHostingEnvironment hosting;
        public ProductsDataController(IRepository<ProductsData> srvsRep, IRepository<CompanyData> companyRep, IHostingEnvironment hosting)
        {
            this.srvsRep = srvsRep;
            this.companyRep = companyRep;
            this.hosting = hosting;
        }
        // GET: ProductsDataController
        public ActionResult Index()
        {
            return View(convertToModelView(srvsRep.list()));
        }

        // GET: ProductsDataController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsDataController/Create
        public ActionResult Create()
        {
            var Service = new ProductsDataModelView();
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

        // POST: ProductsDataController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductsDataModelView c)
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

        // GET: ProductsDataController/Edit/5
        public ActionResult Edit(int id)
        {
            var comp = srvsRep.Find(id);
            return View(convertToModelView(comp));
        }

        // POST: ProductsDataController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductsDataModelView c)
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

        // GET: ProductsDataController/Delete/5
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

        // POST: ProductsDataController/Delete/5
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

        public IList<ProductsDataModelView> convertToModelView(IList<ProductsData> cm)
        {
            IList<ProductsDataModelView> data = cm.Select(x =>
            {
                ProductsDataModelView c = new ProductsDataModelView();
                c.id = x.id;
                c.ProductName = x.ProductName != null ? x.ProductName : "";
                c.ProductNameEn = x.ProductNameEn != null ? x.ProductNameEn : "";
                c.ProductDescreption = x.ProductDescreption != null ? x.ProductDescreption : "";
                c.ProductDescreptionEn = x.ProductDescreptionEn != null ? x.ProductDescreptionEn : "";
                //c.ProductImg = x.ServiceDescreption != null ? x.ServiceDescreption : "";               
                c.Companyid = x.Companyid;
                return c;
            }).ToList();

            return data;
        }

        public ProductsData convertToEntity(ProductsDataModelView cm)
        {
            string ProductImgName = "";
            if (cm.ProductImg != null)
            {
                string uploads = Path.Combine(hosting.WebRootPath, "ProductImages");
                ProductImgName = cm.ProductImg.FileName;
                string fullPath = Path.Combine(uploads, ProductImgName);
                string oldPath = Path.Combine(uploads, cm.ProductImgName != null ? cm.ProductImgName : "");
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                    cm.ProductImg.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                else
                {
                    cm.ProductImg.CopyTo(new FileStream(fullPath, FileMode.Create));
                }

            }
            ProductsData c = new ProductsData();
            c.id = cm.id;
            c.ProductName = cm.ProductName != null ? cm.ProductName : "";
            c.ProductNameEn = cm.ProductNameEn != null ? cm.ProductNameEn : "";
            c.ProductDescreption = cm.ProductDescreption != null ? cm.ProductDescreption : "";
            c.ProductDescreptionEn = cm.ProductDescreptionEn != null ? cm.ProductDescreptionEn : "";           
            c.Companyid = cm.Companyid;
            c.ProductImgPath = ProductImgName != "" ? ProductImgName : cm.ProductImgName;
            return c;

        }

        public ProductsDataModelView convertToModelView(ProductsData cm)
        {
            ProductsDataModelView c = new ProductsDataModelView();
            c.id = cm.id;
            c.ProductName = cm.ProductName != null ? cm.ProductName : "";
            c.ProductNameEn = cm.ProductNameEn != null ? cm.ProductNameEn : "";
            c.ProductDescreption = cm.ProductDescreption != null ? cm.ProductDescreption : "";
            c.ProductDescreptionEn = cm.ProductDescreptionEn != null ? cm.ProductDescreptionEn : "";           
            c.Companyid = cm.Companyid;            
            c.ProductImgName = cm.ProductImgPath != null ? cm.ProductImgPath : "";
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
