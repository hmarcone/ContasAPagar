using Domain.Interfaces.InterfaceConta;
using Domain.Interfraces.InterfaceServices;
using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceConta : IServiceConta
    {
        private readonly IConta _iConta;

        public ServiceConta(IConta conta)
        {
            _iConta = conta;
        }

        public async Task AddConta(Conta conta)
        {
            var validaNome = conta.ValidarPropriedadeString(conta.Nome, "Nome");
            var validaValor = conta.ValidarPropriedadeDecimal(conta.ValorOriginal, "ValorOriginal");
            var validaValorCorrigido = conta.ValidarPropriedadeDecimal(conta.ValorCorrigido, "ValorCorrigido");

            var QuantidadeDiasAtraso = conta.ValidarPropriedadeInt(conta.QuantidadeDiasAtraso, "QuantidadeDiasAtraso");

            if (validaNome && validaValor && validaValorCorrigido && QuantidadeDiasAtraso)
            {
                //Calcular multa e juros

                await _iConta.Add(conta);
            }
        }

        public async Task<List<Conta>> ListarContaById(int id)
        {
            return await _iConta.ListarContaById(id);
        }

        public async Task<List<Conta>> ListarContas()
        {
            return await _iConta.ListarContas();
        }

        public async Task UpdateConta(Conta conta)
        {
            var validaNome = conta.ValidarPropriedadeString(conta.Nome, "Nome");
            var validaValor = conta.ValidarPropriedadeDecimal(conta.ValorOriginal, "ValorOriginal");
            var validaValorCorrigido = conta.ValidarPropriedadeDecimal(conta.ValorCorrigido, "ValorCorrigido");

            var QuantidadeDiasAtraso = conta.ValidarPropriedadeInt(conta.QuantidadeDiasAtraso, "QuantidadeDiasAtraso");

            if (validaNome && validaValor && validaValorCorrigido && QuantidadeDiasAtraso)
            {
                //Calcular multa e juros

                await _iConta.Update(conta);
            }
        }
    }
}
