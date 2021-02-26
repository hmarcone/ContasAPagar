using Domain.Interfaces.InterfaceConta;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryConta : RepositoryGenerics<Conta>, IConta
    {
        private readonly DbContextOptions<ContextBase> _optionsbuilder;

        public RepositoryConta()
        {
            _optionsbuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Conta>> ListarContaById(int id)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                return await banco.Conta.Where(c => c.Id == id).AsNoTracking().ToListAsync();
            }
        }

        public async Task<List<Conta>> ListarContas()
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                return await banco.Conta.AsNoTracking().ToListAsync();
            }
                
        }
    }
}
