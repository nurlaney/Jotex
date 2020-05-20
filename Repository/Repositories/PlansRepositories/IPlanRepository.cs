using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories.PlansRepositories
{
  public interface IPlanRepository
    {
        public IEnumerable<Plan> GetPlans();
        public Plan GetPlanById(int? id);
    }
}
