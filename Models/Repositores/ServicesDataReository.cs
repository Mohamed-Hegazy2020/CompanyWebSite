using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebSiteCore.Models.Repositores
{
    public class ServicesDataReository : IRepository<ServicesData>
    {
        CompanyDbContext db;
        public ServicesDataReository(CompanyDbContext _db)
        {
            db = _db;
        }        
        public void Add(ServicesData entity)
        {
            db.ServicesDatas.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.ServicesDatas.Remove(Find(id));
            db.SaveChanges();
        }

        public ServicesData Find(int id)
        {
            return db.ServicesDatas.SingleOrDefault(x => x.id == id);
        }

        public ServicesData GetCompanyData()
        {
            return db.ServicesDatas.FirstOrDefault();
        }

        public IList<ServicesData> list()
        {
            return db.ServicesDatas.ToList();
        }

        public void Update(ServicesData entity, int id)
        {
            var oldComp = Find(id);
            oldComp.ServiceName = entity.ServiceName;
            oldComp.ServiceNameEn = entity.ServiceNameEn;
            oldComp.ServiceTitleDescreption = entity.ServiceTitleDescreption ;
            oldComp.ServiceTitleDescreptionEn = entity.ServiceTitleDescreptionEn ;
            oldComp.ServiceDescreption = entity.ServiceDescreption;
            oldComp.ServiceDescreptionEn = entity.ServiceDescreptionEn;
            oldComp.ServiceIcon = entity.ServiceIcon;
            oldComp.Companyid = entity.Companyid; 
            db.SaveChanges();
        }
    }
}
