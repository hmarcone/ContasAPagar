using Domain.Interfaces.InterfaceConta;
using Domain.Interfraces.InterfaceServices;
using Entities.Entities;
using System;
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
            //var validaValorCorrigido = conta.ValidarPropriedadeDecimal(conta.ValorCorrigido, "ValorCorrigido");

            //var quantidadeDiasAtraso = conta.ValidarPropriedadeInt(conta.QuantidadeDiasAtraso, "QuantidadeDiasAtraso");

            var dataVencimento = conta.ValidarPropriedadeDateTime(conta.DataVencimento.ToString(), "DataVencimento");

            var dataPagamento = conta.ValidarPropriedadeDateTime(conta.DataPagamento.ToString(), "DataPagamento");

            if (validaNome && validaValor && dataVencimento && dataPagamento)
            {
                //Calcular multa e juros
                var diasAtraso = VerificarQuantidadeDiasAtraso(conta);

                conta.QuantidadeDiasAtraso = diasAtraso;
                conta.DataInclusao = DateTime.Now;
                conta.DataAtualizacao = DateTime.Now;

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
                var diasAtraso = VerificarQuantidadeDiasAtraso(conta);

                conta.QuantidadeDiasAtraso = diasAtraso;
                conta.DataAtualizacao = DateTime.Now;

                await _iConta.Update(conta);
            }
        }

        private int VerificarQuantidadeDiasAtraso(Conta conta)
        {
            var diasAtraso = 0;

            if (conta.DataPagamento > conta.DataVencimento)
            {
                diasAtraso = (conta.DataPagamento - conta.DataVencimento).Days;
            }

            return diasAtraso;
        }

    }
}
