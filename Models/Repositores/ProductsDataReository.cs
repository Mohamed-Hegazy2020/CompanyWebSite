using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CompanyWebSiteCore.Models.Repositores
{
    public class ProductsDataReository : IRepository<ProductsData>
    {
        CompanyDbContext db;
        public ProductsDataReository(CompanyDbContext _db)
        {
            db = _db;
        }
        public void Add(ProductsData entity)
        {
            db.ProductsDatas.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.ProductsDatas.Remove(Find(id));
            db.SaveChanges();
        }

        public ProductsData Find(int id)
        {
            return db.ProductsDatas.SingleOrDefault(x => x.id == id);
        }

        public ProductsData GetCompanyData()
        {
            return db.ProductsDatas.FirstOrDefault();
        }

        public IList<ProductsData> list()
        {
            if (Thread.CurrentThread.CurrentUICulture.CompareInfo.Name == "ar")
            {
                return db.ProductsDatas.Select(x => new ProductsData() {id=x.id, ProductName = x.ProductName, ProductDescreption = x.ProductDescreption, ProductImgPath = x.ProductImgPath }).ToList();

            }
            else
            {
                return db.ProductsDatas.Select(x => new ProductsData() { id = x.id, ProductName = x.ProductNameEn, ProductDescreption = x.ProductDescreptionEn, ProductImgPath = x.ProductImgPath }).ToList();

            }

        }

        public void Update(ProductsData entity, int id)
        {
            var oldComp = Find(id);
            oldComp.ProductName = entity.ProductName;
            oldComp.ProductNameEn = entity.ProductNameEn;
            oldComp.ProductDescreption = entity.ProductDescreption;
            oldComp.ProductDescreptionEn = entity.ProductDescreptionEn;           
            oldComp.ProductImgPath = entity.ProductImgPath;
            oldComp.Companyid = entity.Companyid;
            db.SaveChanges();
        }
    }
}
