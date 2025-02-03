using AspDotNetMVC.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspDotNetMVC.Data.Domains
{
    public class Company
    {
        [Key]
        public long CompanyId { get; set; }

        [Required, Display(Name = "Имя компании")]
        public string? Name { get; set; }

        [Required, Display(Name = "Информация")]
        public string? Information { get; set; }

        [Required, Display(Name = "Дата основания")]
        public DateTime? Founded { get; set; }

        [Required, Display(Name = "Логотип")]
        public string? Image { get; set; }

        [Required, Display(Name = "Индустрия")]
        public Industry Industry { get; set; }

        [Required, ForeignKey(nameof(User))]
        public string? UserId { get; set; }

        public User? User { get; set; }
    }
}
