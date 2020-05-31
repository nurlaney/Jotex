using Admin.Models;
using Admin.Models.AboutUs;
using Admin.Models.Blog;
using Admin.Models.CaseStudy;
using Admin.Models.Home;
using Admin.Models.Pages;
using Admin.Models.Plan;
using Admin.Models.Service;
using AutoMapper;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Service, ServiceViewModel>();
            CreateMap<ServiceViewModel, Service>();

            CreateMap<ServiceSpec, ServiceSpecViewModel>();
            CreateMap<ServiceSpecViewModel, ServiceSpec>();

            CreateMap<Plan, PlanViewModel>();
            CreateMap<PlanViewModel, Plan>();
            CreateMap<Label, LabelViewModel>();
            CreateMap<LabelViewModel, Label>();
            CreateMap<PlanDetail, PlanDetailViewModel>();
            CreateMap<PlanDetailViewModel, PlanDetail>();

            CreateMap<Agent, AgentViewModel>();
            CreateMap<AgentViewModel, Agent>();

            CreateMap<CaseStudy, CaseStudyViewModel>();
            CreateMap<CaseStudyViewModel, CaseStudy>();
            CreateMap<CaseStudySpec, CaseStudySpecViewModel>();
            CreateMap<CaseStudySpecViewModel, CaseStudySpec>();

            CreateMap<Testimonial, TestimonialViewModel>();
            CreateMap<TestimonialViewModel, Testimonial>();

            CreateMap<LikeableArea, LikeableAreaViewModel>();
            CreateMap<LikeableAreaViewModel, LikeableArea>();

            CreateMap<Faq, FaqViewModel>();
            CreateMap<FaqViewModel, Faq>();

            CreateMap<Contact, ContactViewModel>();
            CreateMap<ContactViewModel, Contact>();

            CreateMap<NewTo, NewToViewModel>();
            CreateMap<NewToViewModel, NewTo>();

            CreateMap<CoveredContact, CoveredContactViewModel>();
            CreateMap<CoveredContactViewModel, CoveredContact>();

            CreateMap<SliderItem, SliderItemViewModel>();
            CreateMap<SliderItemViewModel, SliderItem>();

            CreateMap<Brand, BrandViewModel>();
            CreateMap<BrandViewModel, Brand>();

            CreateMap<Blog, BlogViewModel>();
            CreateMap<BlogViewModel, Blog>();
            CreateMap<Tag, TagViewModel>();
            CreateMap<TagViewModel, Tag>();
            CreateMap<BlogWriter, BlogWriterViewModel>();
            CreateMap<BlogWriterViewModel, BlogWriter>();


            CreateMap<AboutCompany, AboutCompanyViewModel>();
            CreateMap<AboutCompanyViewModel, AboutCompany>();
            CreateMap<AboutCompanyEncourage, AboutCompanyEncourageViewModel>();
            CreateMap<AboutCompanyEncourageViewModel, AboutCompanyEncourage>();
            CreateMap<AboutCompanyFunFactViewModel, AboutCompanyFunFact>();
            CreateMap<AboutCompanyFunFact, AboutCompanyFunFactViewModel>();
        }
    }
}
