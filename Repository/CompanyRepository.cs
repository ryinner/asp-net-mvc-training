using AspDotNetMVC.Abstract;
using AspDotNetMVC.Data;
using AspDotNetMVC.Data.Domains;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetMVC.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return await _context.Companies.ToListAsync();
        }

        public void Create(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        public async Task<Company?> GetByIdAsync(int id)
        {
            return await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == id);
        }

        public bool Update(Company company)
        {
            _context.Update(company);
            return Save();
        }

        public bool Save() 
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
