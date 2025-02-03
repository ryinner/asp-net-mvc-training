using AspDotNetMVC.Data.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspDotNetMVC.Models
{
    public class EditCompanyViewModel
    {
        public long CompanyId { get; set; }

        public string Name { get; set; }

        public string Information { get; set; }

        public DateTime? Founded { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }

        public string ImageForm { get; set; }

        public Industry Industry { get; set; }

        public string UserId { get; set; }
    }
}
