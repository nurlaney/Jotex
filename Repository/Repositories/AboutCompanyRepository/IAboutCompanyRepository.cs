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
        public AboutCompany RemovePhoto(int? id);
        public IEnumerable<AboutCompany> GetAllAboutCompany();
        public AboutCompany GetAboutCompanyById(int? id);
        public void UpateAboutCompany(AboutCompany aboutToUpdate, AboutCompany aboutCompany);
        public IEnumerable<AboutCompanyFunFact> GetAboutCompanyFunFacts();
        public AboutCompanyFunFact GetAboutCompanyFunFactById(int id);
        public AboutCompanyFunFact CreateAboutCompanyFunFact(AboutCompanyFunFact aboutCompanyFunFact);
        public void EditFunFact(AboutCompanyFunFact funToUpdate, AboutCompanyFunFact fun);
        public void DeleteFun(AboutCompanyFunFact fun);
        public IEnumerable<AboutCompanyEncourage> GetAllAboutCompanyEncourages();
        public AboutCompanyEncourage GetAboutCompanyEncourageById(int id);
        public AboutCompanyEncourage CreateEnc(AboutCompanyEncourage aboutCompanyEncourage);
        public void UpdateApboutEnc(AboutCompanyEncourage encToUpdate, AboutCompanyEncourage enc);
        public void DeleteEnc(AboutCompanyEncourage enc);
    }
}
