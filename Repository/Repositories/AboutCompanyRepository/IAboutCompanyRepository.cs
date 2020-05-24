using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories.AboutCompanyRepository
{
   public interface IAboutCompanyRepository
    {
        IEnumerable<AboutCompany> GetAboutCompany();
        IEnumerable<Agent> GetAgents();
    }
}
