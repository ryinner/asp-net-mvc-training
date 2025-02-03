using System.ComponentModel.DataAnnotations;

namespace AspDotNetMVC.Data.Enum
{
    public enum Industry
    {
        [Display(Name = "Интернет")]
        Internet,
        [Display(Name = "Электронная Торговля")]
        Ecommerce,
        [Display(Name = "Аэрокосмическая промышленность")]
        Aerospace,
        [Display(Name = "Финансовые услуги")]
        FinancialServices,
        [Display(Name = "Программное обеспечение")]
        Software,
        [Display(Name = "Видео игры")]
        VideoGames
    }
}
