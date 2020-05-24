using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jotex.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repositories.AboutCompanyRepository;

namespace Jotex.Controllers
{
    public class AboutusController : Controller
    {
        private readonly IAboutCompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public AboutusController(IAboutCompanyRepository companyRepository,
                                 IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var aboutItems = _companyRepository.GetAboutCompany();

            var model = _mapper.Map<AboutCompany, AboutCompanyViewModel>(aboutItems.First());

            return View(model);
        }
    }
}