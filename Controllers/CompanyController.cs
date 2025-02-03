using AspDotNetMVC.Abstract;
using AspDotNetMVC.Data.Domains;
using AspDotNetMVC.Extensions;
using AspDotNetMVC.Helper;
using AspDotNetMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetMVC.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IWebHostEnvironment _appEnviroment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CompanyController(ICompanyRepository companyRepository, IWebHostEnvironment appEniveroment, IHttpContextAccessor httpContextAccessor)
        {
            _companyRepository = companyRepository;
            _appEnviroment = appEniveroment;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var currentUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var companyViewModel = new CompanyViewModel() { UserId = currentUserId };
            return View(companyViewModel);
        }

        [HttpPost]
        public IActionResult Create(CompanyViewModel companyViewModel)
        {
            if (ModelState.IsValid)
            {
                var company = new Company()
                {
                    Name = companyViewModel.Name,
                    Information = companyViewModel.Information,
                    Founded = companyViewModel.Founded,
                    Image = ImageMethods.AddFile(_appEnviroment, companyViewModel.Image),
                    Industry = companyViewModel.Industry,
                    UserId = companyViewModel.UserId,
                };
                _companyRepository.Create(company);

                return RedirectToAction("CompanyList");
            }
            ModelState.AddModelError("Error", "Company upload fail");
            return View(companyViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> CompanyList()
        {
            IEnumerable<Company> companies = await _companyRepository.GetCompanies();

            return View(companies);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var company = await _companyRepository.GetByIdAsync(id);

            if (company == null)
            {
                return View("Error");
            }

            var companyViewModel = new EditCompanyViewModel()
            {
                Name = company.Name,
                Information = company.Information,
                Founded = company.Founded,
                ImageForm = company.Image,
                Industry = company.Industry,
                UserId = company.UserId,
            };

            return View(companyViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditCompanyViewModel companyViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Failed", "Failed to edit company");
                return View("edit", companyViewModel);
            }
            var userCompany = await _companyRepository.GetByIdAsync(id);
            if (userCompany != null)
            {
                var company = new Company()
                {
                    CompanyId = id,
                    Name = companyViewModel.Name,
                    Information = companyViewModel.Information,
                    Founded = companyViewModel.Founded,
                    Image = companyViewModel.Image == null ? companyViewModel.ImageForm : ImageMethods.AddFile(_appEnviroment, companyViewModel.Image),
                    Industry = companyViewModel.Industry,
                    UserId = companyViewModel.UserId,
                };
                _companyRepository.Update(company);

                return RedirectToAction("CompanyList", "Company");
            }
            return View(companyViewModel);
        }
    }
}
