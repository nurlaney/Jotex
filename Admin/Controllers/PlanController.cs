using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Filters;
using Admin.Models.Plan;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repositories.PlansRepositories;

namespace Admin.Controllers
{
    [TypeFilter(typeof(Auth))]
    public class PlanController : Controller
    {
        private Repository.Models.Admin _admin => RouteData.Values["Admin"] as Repository.Models.Admin;
        private readonly IPlanRepository _planRepository;
        private readonly IMapper _mapper;

        public PlanController(IPlanRepository planRepository,
                              IMapper mapper)
        {
            _planRepository = planRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {

            var plans = _planRepository.GetAllPlans();

            var model = _mapper.Map<IEnumerable<Plan>, IEnumerable<PlanViewModel>>(plans);


            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.Labels = _planRepository.GetAllLabels();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PlanViewModel model)
        {
            ViewBag.Labels = _planRepository.GetAllLabels();

            if (ModelState.IsValid)
            {
                var plan = _mapper.Map<PlanViewModel, Plan>(model);

                plan.AddedBy = _admin.Fullname;

                _planRepository.CreatePlan(plan);

                return RedirectToAction("index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Labels = _planRepository.GetAllLabels();

            var plan = _planRepository.GetPlanById(id);

            var model = _mapper.Map<Plan, PlanViewModel>(plan);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PlanViewModel model)
        {
            ViewBag.Labels = _planRepository.GetAllLabels();

            if (ModelState.IsValid)
            {
                var plan = _mapper.Map<PlanViewModel, Plan>(model);
                var planToUpdate = _planRepository.GetPlanById(model.Id);
                if (planToUpdate == null) return NotFound();
                plan.ModifiedBy = _admin.Fullname;

                _planRepository.UpdatePlan(planToUpdate, plan);

                return RedirectToAction("index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Plan plan = _planRepository.GetPlanById(id);

            _planRepository.DeletePlan(plan);

            return RedirectToAction("index");
        }

        //======================================\\
        //            etiketler...                \\
        //==========================================\\

        //index
        public IActionResult LabelTable()
        {
            var labels = _planRepository.GetAllLabels();
            var model = _mapper.Map<IEnumerable<Label>, IEnumerable<LabelViewModel>>(labels);

            return View(model);
        }

        // create
        [HttpGet]
        public IActionResult CreateLabel()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateLabel(LabelViewModel model)
        {
            if (ModelState.IsValid)
            {
                var label = _mapper.Map<LabelViewModel, Label>(model);
                label.AddedBy = _admin.Fullname;

                _planRepository.CreateLabel(label);

                return RedirectToAction("labeltable");
            }
            return View(model);
        }

        //edit
        [HttpGet]
        public IActionResult EditLabel(int id)
        {
            var label = _planRepository.GetLabelById(id);

            if (label == null) return NotFound();

            var model = _mapper.Map<Label, LabelViewModel>(label);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditLabel(LabelViewModel model)
        {
            if (ModelState.IsValid)
            {
                var label = _mapper.Map<LabelViewModel, Label>(model);

                var labelToUpdate = _planRepository.GetLabelById(model.Id);

                if (labelToUpdate == null) return NotFound();
                label.ModifiedBy = _admin.Fullname;

                _planRepository.UpdateLabel(labelToUpdate, label);

                return RedirectToAction("labeltable");
            }
            return View(model);
        }

        //delete
        public IActionResult DeleteLabel(int id)
        {
            Label label = _planRepository.GetLabelById(id);

            if (label == null) return NotFound();

            _planRepository.DeleteLabel(label);

            return RedirectToAction("labeltable");
        }

        //======================================\\
       //            detallar...                 \\
      //==========================================\\

        //index
        public IActionResult DetailTable()
        {
            var details = _planRepository.GetAllPlanDetails();
            var model = _mapper.Map<IEnumerable<PlanDetail>, IEnumerable<PlanDetailViewModel>>(details);

            return View(model);
        }

        //create
        public IActionResult CreateDetail()
        {
            ViewBag.Plans = _planRepository.GetAllPlans();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDetail(PlanDetailViewModel model)
        {
            ViewBag.Plans = _planRepository.GetAllPlans();
            if (ModelState.IsValid)
            {
                var planDetail = _mapper.Map<PlanDetailViewModel, PlanDetail>(model);
                planDetail.AddedBy = _admin.Fullname;

                _planRepository.CreateDetail(planDetail);

                return RedirectToAction("detailtable");
            }
            return View(model);
        }

        //edit
        public IActionResult EditDetail(int id)
        {
            ViewBag.Plans = _planRepository.GetAllPlans();

            var detail = _planRepository.GetDetailById(id);

            var model = _mapper.Map<PlanDetail, PlanDetailViewModel>(detail);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditDetail(PlanDetailViewModel model)
        {
            ViewBag.Plans = _planRepository.GetAllPlans();

            if (ModelState.IsValid)
            {
                var planDetail = _mapper.Map<PlanDetailViewModel, PlanDetail>(model);
                var detailToUpdate = _planRepository.GetDetailById(model.Id);

                if (detailToUpdate == null) return NotFound();

                detailToUpdate.ModifiedBy = _admin.Fullname;

                _planRepository.UpdtadeDetail(detailToUpdate, planDetail);

                return RedirectToAction("detailtable");
            }
            return View(model);
        }

        //delete
        public IActionResult DeleteDetail(int id)
        {
            PlanDetail planDetail = _planRepository.GetDetailById(id);
            _planRepository.DeleteDetail(planDetail);

            return RedirectToAction("detailtable");
        }
    }
}
