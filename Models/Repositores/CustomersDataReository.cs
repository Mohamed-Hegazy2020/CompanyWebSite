using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebSiteCore.Models.Repositores
{
    public class CustomersDataReository : IRepository<CustomersData>
    {
        CompanyDbContext db;
        public CustomersDataReository(CompanyDbContext _db)
        {
            db = _db;
        }
        public void Add(CustomersData entity)
        {
            db.CustomersDatas.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.CustomersDatas.Remove(Find(id));
            db.SaveChanges();
        }

        public CustomersData Find(int id)
        {
            return db.CustomersDatas.SingleOrDefault(x => x.id == id);
        }

        public CustomersData GetCompanyData()
        {
            return db.CustomersDatas.FirstOrDefault();
        }

        public IList<CustomersData> list()
        {
            return db.CustomersDatas.ToList();
        }

        public void Update(CustomersData entity, int id)
        {
            var oldComp = Find(id);
            oldComp.CustomerName = entity.CustomerName;
            oldComp.CustomerNameEn = entity.CustomerNameEn;
            oldComp.CustomerDescreption = entity.CustomerDescreption;
            oldComp.CustomerDescreptionEn = entity.CustomerDescreptionEn;
            oldComp.CustomerImgPath = entity.CustomerImgPath;
            oldComp.Companyid = entity.Companyid;
            db.SaveChanges();
        }
    }
}
