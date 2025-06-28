using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.Reportes;
using Domain.Entities;
using AutoMapper;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region Reportes
            CreateMap<Reporte, ReportesViewModel>()
                    .ReverseMap()
                    .ForMember(x => x.Usuario, opt => opt.Ignore())
                    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Reporte, ReportesHandlerViewModel>()
                    .ReverseMap()
                    .ForMember(x => x.Usuario, opt => opt.Ignore());
            #endregion
        }
    }
}
