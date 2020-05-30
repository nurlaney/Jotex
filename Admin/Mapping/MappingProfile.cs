using Admin.Models;
using Admin.Models.CaseStudy;
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

            CreateMap<CaseStudy, CaseStudyViewModel>();
            CreateMap<CaseStudyViewModel, CaseStudy>();
            CreateMap<CaseStudySpec, CaseStudySpecViewModel>();
            CreateMap<CaseStudySpecViewModel, CaseStudySpec>();

        }
    }
}
