using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jotex.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repositories.SectionRepositories;

namespace Jotex.Controllers
{
    public class ContactController : Controller
    {
        public readonly ISectionRepository _sectionRepository;
        public readonly IMapper _mapper;

        public ContactController(ISectionRepository sectionRepository,
                                 IMapper mapper)
        {
            _sectionRepository = sectionRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var contactItems = _sectionRepository.GetContacts();
            var model = _mapper.Map<Contact, ContactViewModel>(contactItems.First());
            return View(model);
        }
    }
}