using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfraces.InterfaceServices
{
    public interface IServiceConta
    {
        Task AddConta(Conta conta);
        Task UpdateConta(Conta conta);

        Task<List<Conta>> ListarContas();

        Task<List<Conta>> ListarContaById(int id);

    }
}
