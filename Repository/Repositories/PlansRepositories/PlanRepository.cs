using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories.PlansRepositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly JotexDbContext _context;
        public PlanRepository(JotexDbContext context)
        {
            _context = context;
        }

        public PlanDetail CreateDetail(PlanDetail planDetail)
        {
            planDetail.AddedDate = DateTime.Now;
            _context.Add(planDetail);
            _context.SaveChanges();


            return planDetail;
        }

        public Label CreateLabel(Label label)
        {
            label.AddedDate = DateTime.Now;
            _context.Add(label);
            _context.SaveChanges();


            return label;
        }

        public Plan CreatePlan(Plan model)
        {
            model.AddedDate = DateTime.Now;

            _context.Add(model);
            _context.SaveChanges();

            return model;
        }

        public void DeleteDetail(PlanDetail planDetail)
        {
            _context.Remove(planDetail);
            _context.SaveChanges();
        }

        public void DeleteLabel(Label label)
        {
            _context.Remove(label);
            _context.SaveChanges();
        }

        public void DeletePlan(Plan plan)
        {
            _context.Plans.Remove(plan);
            _context.SaveChanges();
        }

        public IEnumerable<Label> GetAllLabels()
        {
            return _context.Labels.Include(l => l.Plans).OrderByDescending(l=>l.AddedDate).ToList();
        }

        public IEnumerable<PlanDetail> GetAllPlanDetails()
        {
            return _context.PlanDetails.Include(d=>d.Plan)
                                        .OrderByDescending(d => d.AddedDate).ToList();
        }

        public IEnumerable<Plan> GetAllPlans()
        {
            return _context.Plans
                           .Include(p => p.Label)
                           .ToList();
        }

        public PlanDetail GetDetailById(int id)
        {
            return _context.PlanDetails.Include(p => p.Plan).OrderByDescending(p => p.AddedDate).FirstOrDefault(p => p.Id == id);
        }

        public Label GetLabelById(int id)
        {
            return _context.Labels.FirstOrDefault(l => l.Id == id);
        }

        public Plan GetPlanById(int id)
        {
            return _context.Plans.Include(p => p.Details).Include(p => p.Label).FirstOrDefault(p=>p.Id == id);
        }

        public IEnumerable<Plan> GetPlans()
        {
            return _context.Plans
                           .Include(p => p.Label)
                           .Include("Details")
                           .Where(p => p.Status)
                           .ToList();
        }

        public void UpdateLabel(Label labelToUpdate, Label label)
        {
            labelToUpdate.ModifiedDate = DateTime.Now;
            labelToUpdate.Status = label.Status;
            labelToUpdate.Text = label.Text;
            labelToUpdate.Color = label.Color;

            _context.SaveChanges();
        }

        public void UpdatePlan(Plan planToUpdate, Plan plan)
        {
            planToUpdate.ModifiedDate = DateTime.Now;
            planToUpdate.ActionText = plan.ActionText;
            planToUpdate.Icon = plan.Icon;
            planToUpdate.Status = plan.Status;
            planToUpdate.Title = plan.Title;
            planToUpdate.LabelId = plan.LabelId;

            _context.SaveChanges();
        }

        public void UpdtadeDetail(PlanDetail detailToUpdate, PlanDetail planDetail)
        {
            detailToUpdate.ModifiedDate = DateTime.Now;
            detailToUpdate.Condition = planDetail.Condition;
            detailToUpdate.Status = planDetail.Status;
            detailToUpdate.PlanId = planDetail.PlanId;

            _context.SaveChanges();
        }
    }
}
