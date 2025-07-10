using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.Reportes;
using AutoMapper;
using Application.ViewModels.Rutas;
using Application.ViewModels.Usuarios;
using Application.ViewModels.Camiones;
using Application.ViewModels.Choferes;
using Application.ViewModels.Asignaciones;
using Domain.Entities;
using System.Reflection;
using Application.ViewModels.Horarios;

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

            //-------------------------- Horarios
            CreateMap<Horario, HorarioViewModel>()
                    .ReverseMap()
                    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Horario, HorarioSaveViewModel>()
                    .ReverseMap()
                    .ForMember(x => x.HorarioId, opt => opt.Ignore());

            //-------------------------- Camiones
            CreateMap<Camione, CamionViewModel>()
                    .ReverseMap()
                    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Camione, CamionSaveViewModel>()
                    .ReverseMap()
                    .ForMember(x => x.CamionId, opt => opt.Ignore());

            //-------------------------- Choferes
            CreateMap<Chofere, ChoferViewModel>()
                    .ReverseMap()
                    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Chofere, ChoferSaveViewModel>()
                    .ReverseMap()
                    .ForMember(x => x.ChoferId, opt => opt.Ignore());

            //-------------------------- Asignaciones
            CreateMap<AsignacionesRutum, AsignacionViewModel>()
                    .ReverseMap()
                    /*.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null))*/;

            CreateMap<AsignacionesRutum, AsignacionSaveViewModel>()
                    .ReverseMap()
                    .ForMember(x => x.AsignacionId, opt => opt.Ignore());

            CreateMap<AsignacionesRutum, AsignacionesDetailsViewModel>()
                    .ForMember(dest => dest.NombreRuta, opt => opt.MapFrom(src => src.Ruta != null ? src.Ruta.NombreRuta : null))
                    .ForMember(dest => dest.HoraSalida, opt => opt.MapFrom(src => src.Horario != null ? src.Horario.HoraSalida : null))
                    .ForMember(dest => dest.HoraLlegada, opt => opt.MapFrom(src => src.Horario != null ? src.Horario.HoraLlegada : null))
                    .ForMember(dest => dest.PlacaCamion, opt => opt.MapFrom(src => src.Camion != null ? src.Camion.Placa : null))
                    .ForMember(dest => dest.NombreChofer, opt => opt.MapFrom(src => src.Chofer != null ? src.Chofer.Nombre : null))
                    .ForMember(dest => dest.CedulaChofer, opt => opt.MapFrom(src => src.Chofer != null ? src.Chofer.Cedula : null));


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
