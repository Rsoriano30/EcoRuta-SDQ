using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.Reportes;
using Domain.Entities;
using AutoMapper;
using Application.ViewModels.Rutas;
using Application.ViewModels.Usuarios;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            //-------------------------- Reportes
            CreateMap<Reporte, ReporteViewModel>()
                    .ReverseMap()
                    .ForMember(x => x.Usuario, opt => opt.Ignore())
                    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Reporte, ReporteSaveViewModel>()
                    .ReverseMap()
                    .ForMember(x => x.ReporteId, opt => opt.Ignore())
                    // temporal, ya que el usuario si va.
                    .ForMember(x => x.Usuario, opt => opt.Ignore());

            //-------------------------- Rutas
            CreateMap<Ruta, RutaViewModel>()
                    .ReverseMap()
                    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Ruta, RutaSaveViewModel>()
                    .ReverseMap()
                    .ForMember(x => x.RutaId, opt => opt.Ignore());

            //-------------------------- Usuarios
            CreateMap<Usuario, LoginViewModel>()
                    .ReverseMap()
                    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Usuario, RegisterViewModel>()
                    .ReverseMap()
                    .ForMember(x => x.UsuarioId, opt => opt.Ignore());
        }
    }
}
