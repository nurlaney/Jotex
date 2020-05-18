using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories.AboutCompanyRepository
{
   public interface IAboutCompanyRepository
    {
        IEnumerable<AboutCompany> GetAboutCompany();
        IEnumerable<AboutCompanyBanner> GetAboutCompanyBanners();
        IEnumerable<AboutCompanyEncourage> GetAboutCompanyEncourages();
        IEnumerable<AboutCompanyFunFact> GetAboutCompanyFunFacts();
        IEnumerable<Agent> GetAgents();
    }
}
