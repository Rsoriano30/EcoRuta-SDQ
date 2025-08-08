using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.Choferes;
using Domain.Entities;

namespace Application.Intefaces.Services
{
    public interface IChoferesService : IGenericService<ChoferSaveViewModel, ChoferViewModel, Chofere>
    {
    }
}
