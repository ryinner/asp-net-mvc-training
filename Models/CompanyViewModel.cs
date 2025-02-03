using AspDotNetMVC.Data.Domains;
using AspDotNetMVC.Data.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AspDotNetMVC.Models
{
    public class CompanyViewModel
    {
        public long CompanyId { get; set; }

        public string Name { get; set; }

        public string Information { get; set; }

        public DateTime Founded { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        public Industry Industry { get; set; }

        public string UserId { get; set; }
    }
}
