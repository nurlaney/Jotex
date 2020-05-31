using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Filters;
using Admin.Libs;
using Admin.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Repository.Models;
using Repository.Repositories.CaseStudyRepositories;
using Repository.Services;

namespace Admin.Controllers
{
    [TypeFilter(typeof(Auth))]
    public class AgentController : Controller
    {
        private Repository.Models.Admin _admin => RouteData.Values["Admin"] as Repository.Models.Admin;
        private readonly ICaseStudyRepository _caseStudyRepository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IFileManager _fileManager;
        public readonly JotexDbContext _context;

        public AgentController(ICaseStudyRepository caseStudyRepository,
                                   IMapper mapper,
                                   ICloudinaryService cloudinaryService,
                                   IFileManager fileManager,
                                   JotexDbContext context)
        {
            _caseStudyRepository = caseStudyRepository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
            _fileManager = fileManager;
            _context = context;
        }
        public IActionResult Index()
        {
            var agents = _caseStudyRepository.GetAllAgents();
            var model = _mapper.Map<IEnumerable<Agent>, IEnumerable<AgentViewModel>>(agents);

            return View(model);
        } 

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AgentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var agent = _mapper.Map<AgentViewModel, Agent>(model);
                agent.AddedBy = _admin.Fullname;

                _caseStudyRepository.CreateAgent(agent);

                return RedirectToAction("index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var agent = _caseStudyRepository.GetAgentById(id);
            if (agent == null) return NotFound();

            var model = _mapper.Map<Agent, AgentViewModel>(agent);

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AgentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var agent = _mapper.Map<AgentViewModel, Agent>(model);
                var agentToUpdate = _caseStudyRepository.GetAgentById(model.Id);
                if (agentToUpdate == null) return NotFound();
                agent.ModifiedBy = _admin.Fullname;

                _caseStudyRepository.UpdateAgent(agentToUpdate, agent);

                return RedirectToAction("index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {

            Agent agent = _caseStudyRepository.GetAgentById(id);

            if (agent == null) return NotFound();

            _caseStudyRepository.DeleteAgent(agent);

            return RedirectToAction("index");
        }



        [HttpPost]
        public IActionResult Upload(IFormFile file, int? id)
        {
            var filename = _fileManager.Upload(file);
            var publicId = _cloudinaryService.Store(filename);
            _fileManager.Delete(filename);


            if (id != null)
            {
                var agent = _caseStudyRepository.GetAgentById(id);
                agent.Image = publicId;
                _context.SaveChanges();
            }


            return Ok(new
            {
                filename = publicId,
                src = _cloudinaryService.BuildUrl(publicId)
            });
        }

        [HttpPost]
        public IActionResult Remove(string name, int? id)
        {

            _caseStudyRepository.RemovePhoto(id);


            _cloudinaryService.Delete(name);

            return Ok(new { status = 200 });
        }
    }
}