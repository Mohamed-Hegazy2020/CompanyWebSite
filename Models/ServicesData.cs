using System.ComponentModel.DataAnnotations;

namespace CompanyWebSiteCore.Models
{
    public class ServicesData
    {
        [Key]
        public int id { get; set; }
        //public string ServiceTitleDescreption { get; set; }
        //public string ServiceTitleDescreptionEn { get; set; }
        public string ServiceName { get; set; }
        public string ServiceNameEn { get; set; }
        public string ServiceTitleDescreption { get; set; }      
        public string ServiceTitleDescreptionEn { get; set; }
        public string ServiceDescreption { get; set; }
        public string ServiceDescreptionEn { get; set; }
        public string ServiceIcon { get; set; }
        public int Companyid { get; set; }
    }
}
