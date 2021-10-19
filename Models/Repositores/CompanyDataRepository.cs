using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebSiteCore.Models.Repositores
{
    public class CompanyDataRepository : IRepository<CompanyData>
    {
        CompanyDbContext db;
        public CompanyDataRepository(CompanyDbContext _db)
        {
            db = _db;
        }

        public void Add(CompanyData entity)
        {
            var comp = list();
            if (comp.Count>0)
            {
                var oldComp = db.CompanyDatas.FirstOrDefault();
                oldComp.CompanyName = entity.CompanyName;
                oldComp.CompanyNameEn = entity.CompanyNameEn;
                oldComp.Address = entity.Address;
                oldComp.AddressEn = entity.AddressEn;
                oldComp.Email = entity.Email;
                oldComp.Phone = entity.Phone;
                oldComp.Mobile = entity.Mobile;
                oldComp.Fax = entity.Fax;
                oldComp.FaceBookLink = entity.FaceBookLink;
                oldComp.TwitterLink = entity.TwitterLink;
                oldComp.LinkedinLink = entity.LinkedinLink;
                oldComp.InstgramLink = entity.InstgramLink;
                oldComp.WelecomePageTitle = entity.WelecomePageTitle;
                oldComp.WelecomePageTitleEn = entity.WelecomePageTitleEn;
                oldComp.WelecomePageDescription = entity.WelecomePageDescription;
                oldComp.WelecomePageDescriptionEn = entity.WelecomePageDescriptionEn;

                oldComp.AboutPageHeader = entity.AboutPageHeader;
                oldComp.AboutPageHeaderEn = entity.AboutPageHeaderEn;
                oldComp.AboutPageDescreption = entity.AboutPageDescreption;
                oldComp.AboutPageDescreptionEn = entity.AboutPageDescreptionEn;

                oldComp.ServicesTitleDescreption = entity.ServicesTitleDescreption;
                oldComp.ServicesTitleDescreptionEn = entity.ServicesTitleDescreptionEn;
                oldComp.ProductsTitleDescreption = entity.ProductsTitleDescreption;
                oldComp.ProductsTitleDescreptionEn = entity.ProductsTitleDescreptionEn;
                oldComp.ClientsTitleDescreption = entity.ClientsTitleDescreption;
                oldComp.ClientsTitleDescreptionEn = entity.ClientsTitleDescreptionEn;
                oldComp.ContactTitleDescreption = entity.ContactTitleDescreption;
                oldComp.ContactTitleDescreptionEn = entity.ContactTitleDescreptionEn;

                oldComp.FooterAboutDescreption = entity.FooterAboutDescreption;
                oldComp.FooterAboutDescreptionEn = entity.FooterAboutDescreptionEn;

                oldComp.BackGImage = entity.BackGImage!=null? entity.BackGImage: oldComp.BackGImage;
                oldComp.LogoImage = entity.LogoImage!=null? entity.LogoImage: oldComp.LogoImage;
                oldComp.HomeBackGImage = entity.HomeBackGImage != null ? entity.HomeBackGImage : oldComp.HomeBackGImage;
                db.SaveChanges();
            }
            else
            {
               
                db.CompanyDatas.Add(entity);
                db.SaveChanges();
            }
           
        }

        public void Delete(int id)
        {
            db.CompanyDatas.Remove(Find(id));
            db.SaveChanges();
        }

        public CompanyData Find(int id)
        {
            return db.CompanyDatas.SingleOrDefault(x=>x.id==id);

        }

       

        public IList<CompanyData> list()
        {
            return db.CompanyDatas.ToList();
            
        }

        public void Update(CompanyData entity,int id)
        {
            var oldComp = Find(id);
            oldComp.CompanyName = entity.CompanyName;
            oldComp.CompanyNameEn = entity.CompanyNameEn;
            oldComp.Address = entity.Address;
            oldComp.AddressEn = entity.AddressEn;
            oldComp.Email = entity.Email;
            oldComp.Phone = entity.Phone;
            oldComp.Mobile = entity.Mobile;
            oldComp.Fax = entity.Fax;
            oldComp.FaceBookLink = entity.FaceBookLink;
            oldComp.TwitterLink = entity.TwitterLink;
            oldComp.LinkedinLink = entity.LinkedinLink;
            oldComp.InstgramLink = entity.InstgramLink;
            oldComp.WelecomePageTitle = entity.WelecomePageTitle;
            oldComp.WelecomePageTitleEn = entity.WelecomePageTitleEn;
            oldComp.WelecomePageDescription = entity.WelecomePageDescription;
            oldComp.WelecomePageDescriptionEn = entity.WelecomePageDescriptionEn;

            oldComp.ServicesTitleDescreption = entity.ServicesTitleDescreption;
            oldComp.ServicesTitleDescreptionEn = entity.ServicesTitleDescreptionEn;
            oldComp.ProductsTitleDescreption = entity.ProductsTitleDescreption;
            oldComp.ProductsTitleDescreptionEn = entity.ProductsTitleDescreptionEn;
            oldComp.ClientsTitleDescreption = entity.ClientsTitleDescreption;
            oldComp.ClientsTitleDescreptionEn = entity.ClientsTitleDescreptionEn;
            oldComp.ContactTitleDescreption = entity.ContactTitleDescreption;
            oldComp.ContactTitleDescreptionEn = entity.ContactTitleDescreptionEn;

            oldComp.AboutPageHeader = entity.AboutPageHeader;
            oldComp.AboutPageHeaderEn = entity.AboutPageHeaderEn;
            oldComp.AboutPageDescreption = entity.AboutPageDescreption;
            oldComp.AboutPageDescreptionEn = entity.AboutPageDescreptionEn;
            oldComp.FooterAboutDescreption = entity.FooterAboutDescreption;
            oldComp.FooterAboutDescreptionEn = entity.FooterAboutDescreptionEn;

            oldComp.BackGImage = entity.BackGImage;
            oldComp.LogoImage = entity.LogoImage;
            oldComp.HomeBackGImage = entity.HomeBackGImage != null ? entity.HomeBackGImage : oldComp.HomeBackGImage;

            db.SaveChanges();
        }

        public CompanyData GetCompanyData()
        {
            return db.CompanyDatas.FirstOrDefault();
        }
    }
}
