using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceConta;
using Domain.Interfraces.InterfaceServices;
using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppConta : InterfaceContaApp
    {
        IConta _iConta;
        IServiceConta _iServiceConta;

        public AppConta(IConta iConta, IServiceConta iServiceConta)
        {
            _iConta = iConta;
            _iServiceConta = iServiceConta;
        }

        public async Task AddConta(Conta conta)
        {
            await _iServiceConta.AddConta(conta);
        }

        public async Task UpdateConta(Conta conta)
        {
            await _iServiceConta.UpdateConta(conta);
        }

        public async Task<List<Conta>> ListarContaById(int id)
        {
            var listConta = await _iConta.ListarContaById(id);
            return listConta;
        }

        public async Task<List<Conta>> ListarContas()
        {
            return await _iConta.ListarContas();
        }

        public Task Add(Conta Objeto)
        {
            throw new System.NotImplementedException();
        }


        public Task Delete(Conta Objeto)
        {
            throw new System.NotImplementedException();
        }

        public Task<Conta> GetEntityById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Conta>> List()
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Conta Objeto)
        {
            throw new System.NotImplementedException();
        }

    }
}
