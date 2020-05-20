using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Data
{
   public class JotexDbContext : DbContext
    {
        public JotexDbContext(DbContextOptions<JotexDbContext>options) : base(options) { }

        public DbSet<AboutCompany> AboutCompanies { get; set; }
        public DbSet<AboutCompanyBanner> AboutCompanyBanners { get; set; }
        public DbSet<AboutCompanyFunFact> AboutCompanyFunFacts { get; set; }
        public DbSet<AboutCompanyEncourage> AboutCompanyEncourages { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CaseStudy> CaseStudies { get; set; }
        public DbSet<CaseStudyProcess> CaseStudyProcesses { get; set; }
        public DbSet<CaseStudySpec> CaseStudySpecs { get; set; }
        public DbSet<CoveredContact> CoveredContacts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<LikeableArea> LikeableAreas { get; set; }
        public DbSet<NewTo> NewTos { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PlanDetail> PlanDetails { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceBanner> ServiceBanners { get; set; }
        public DbSet<ServiceDetail> ServiceDetails { get; set; }
        public DbSet<ServiceSpec> ServiceSpecs { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SliderItem> SliderItems { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Faq> Faqs { get; set; }
    }
}
