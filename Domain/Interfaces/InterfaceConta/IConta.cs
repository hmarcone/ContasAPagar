using Domain.Interfaces.Generics;
using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceConta
{
    public interface IConta : IGeneric<Conta>
    {
        Task<List<Conta>> ListarContaById(int id);
        Task<List<Conta>> ListarContas();
    }
}
