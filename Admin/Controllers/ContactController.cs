using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Filters;
using Admin.Models.Pages;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repositories.SectionRepositories;

namespace Admin.Controllers
{
    [TypeFilter(typeof(Auth))]
    public class ContactController : Controller
    {
        private Repository.Models.Admin _admin => RouteData.Values["Admin"] as Repository.Models.Admin;
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper _mapper;

        public ContactController(ISectionRepository sectionRepository,
                                   IMapper mapper)
        {
            _sectionRepository = sectionRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var contacts = _sectionRepository.GetAllContact();

            var model = _mapper.Map<IEnumerable<Contact>, IEnumerable<ContactViewModel>>(contacts);


            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var contact = _sectionRepository.GetContactById(id);

            var model = _mapper.Map<Contact, ContactViewModel>(contact);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ContactViewModel model)
        {

            if (ModelState.IsValid)
            {
                var contact = _mapper.Map<ContactViewModel, Contact>(model);

                var contactToUpdate = _sectionRepository.GetContactById(model.Id);

                if (contactToUpdate == null) return NotFound();

                contact.ModifiedBy = _admin.Fullname;

                _sectionRepository.UpdateConact(contactToUpdate, contact);

                return RedirectToAction("index");
            }
            return View(model);
        }
    }
}