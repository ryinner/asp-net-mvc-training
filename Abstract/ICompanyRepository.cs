using AspDotNetMVC.Data.Domains;

namespace AspDotNetMVC.Abstract
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompanies();

        void Create(Company company);

        Task<Company?> GetByIdAsync(int id);

        bool Update(Company company);

        bool Save();
    }
}
