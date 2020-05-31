using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories.AboutCompanyRepository
{
    public class AboutCompanyRepository : IAboutCompanyRepository
    {
       private readonly JotexDbContext _context;
       public AboutCompanyRepository(JotexDbContext context)
        {
            _context = context;
        }

        public AboutCompanyFunFact CreateAboutCompanyFunFact(AboutCompanyFunFact aboutCompanyFunFact)
        {
            aboutCompanyFunFact.AddedDate = DateTime.Now;
            _context.Add(aboutCompanyFunFact);
            _context.SaveChanges();

            return aboutCompanyFunFact;
        }

        public AboutCompanyEncourage CreateEnc(AboutCompanyEncourage aboutCompanyEncourage)
        {
            aboutCompanyEncourage.AddedDate = DateTime.Now;
            _context.Add(aboutCompanyEncourage);
            _context.SaveChanges();

            return aboutCompanyEncourage;
        }

        public void DeleteEnc(AboutCompanyEncourage enc)
        {
            _context.Remove(enc);
            _context.SaveChanges();
        }

        public void DeleteFun(AboutCompanyFunFact fun)
        {
            _context.Remove(fun);
            _context.SaveChanges();
        }

        public void EditFunFact(AboutCompanyFunFact funToUpdate, AboutCompanyFunFact fun)
        {
            funToUpdate.ModifiedDate = DateTime.Now;
            funToUpdate.Status = fun.Status;
            funToUpdate.Numbs = fun.Numbs;
            funToUpdate.Icon = fun.Icon;
            funToUpdate.FFDescription = fun.FFDescription;

            _context.SaveChanges();
        }

        //about sehifesi post
        public IEnumerable<AboutCompany> GetAboutCompany()
        {
            return _context.AboutCompanies
                                          .Include(a=>a.FunFacts)
                                          .Include(a=>a.Encourages)
                                          .Where(a => a.Status).ToList();
        }

        public AboutCompany GetAboutCompanyById(int? id)
        {
            return _context.AboutCompanies
                                          .OrderByDescending(a => a.AddedDate)
                                          .FirstOrDefault(a => a.Id == id);
        }

        public AboutCompanyEncourage GetAboutCompanyEncourageById(int id)
        {
            return _context.AboutCompanyEncourages.OrderByDescending(e => e.AddedDate).FirstOrDefault(e => e.Id == id);
        }

        public AboutCompanyFunFact GetAboutCompanyFunFactById(int id)
        {
            return _context.AboutCompanyFunFacts
                                                 .Include(a=>a.AboutCompany)
                                                 .OrderByDescending(a => a.AddedDate)
                                                 .FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<AboutCompanyFunFact> GetAboutCompanyFunFacts()
        {
            return _context.AboutCompanyFunFacts.Include(a => a.AboutCompany).ToList();
        }

        // about sehifesi agentler siyahisi
        public IEnumerable<Agent> GetAgents()
        {
          return  _context.Agents.Where(a => a.Status).ToList();
        }

        public IEnumerable<AboutCompany> GetAllAboutCompany()
        {
            return _context.AboutCompanies.OrderByDescending(a => a.AddedDate).ToList();
        }

        public IEnumerable<AboutCompanyEncourage> GetAllAboutCompanyEncourages()
        {
            return _context.AboutCompanyEncourages.OrderByDescending(e => e.AddedDate).ToList();
        }

        public AboutCompany RemovePhoto(int? id)
        {
            var about = _context.AboutCompanies.FirstOrDefault(s => s.Id == id);

            about.Image = null;

            _context.SaveChanges();

            return about;
        }

        public void UpateAboutCompany(AboutCompany aboutToUpdate, AboutCompany aboutCompany)
        {
            aboutToUpdate.ModifiedDate = DateTime.Now;
            aboutToUpdate.Status = aboutCompany.Status;
            aboutToUpdate.Title = aboutCompany.Title;
            aboutToUpdate.Text = aboutCompany.Text;
            aboutToUpdate.LeftTitle = aboutCompany.LeftTitle;
            aboutToUpdate.LeftText = aboutCompany.LeftText;
            aboutToUpdate.ActionText = aboutCompany.ActionText;

            _context.SaveChanges();
        }

        public void UpdateApboutEnc(AboutCompanyEncourage encToUpdate, AboutCompanyEncourage enc)
        {
            encToUpdate.ModifiedDate = DateTime.Now;
            encToUpdate.Status = enc.Status;
            encToUpdate.SubTitle = enc.SubTitle;
            encToUpdate.Count = enc.Count;
            encToUpdate.Description = enc.Description;
            encToUpdate.EncActionText = enc.EncActionText;

            _context.SaveChanges();
        }
    }
}
