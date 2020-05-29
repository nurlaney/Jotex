using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories.PlansRepositories
{
  public interface IPlanRepository
    {
        public IEnumerable<Plan> GetPlans();
        public void UpdatePlan(Plan planToUpdate, Plan plan);
        public void DeletePlan(Plan plan);
        public Plan GetPlanById(int id);
        public IEnumerable<Plan> GetAllPlans();
        public IEnumerable<Label> GetAllLabels();
        public Plan CreatePlan(Plan model);
        public Label GetLabelById(int id);
        Label CreateLabel(Label label);
        public void UpdateLabel(Label labelToUpdate, Label label);
        public void DeleteLabel(Label label);
        public IEnumerable<PlanDetail> GetAllPlanDetails();
        PlanDetail CreateDetail(PlanDetail planDetail);
        public PlanDetail GetDetailById(int id);
        public void UpdtadeDetail(PlanDetail detailToUpdate, PlanDetail planDetail);
        public void DeleteDetail(PlanDetail planDetail);
    }
}
