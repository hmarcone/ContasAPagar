using Domain.Interfaces.InterfaceConta;
using Domain.Interfraces.InterfaceServices;
using Domain.Services;
using Entities.Entities;
using Infrastructure.Repository.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestContasAPagar
{

    public class ContasAPagar
    {
        [Fact]
        public async Task AddContaComSucesso_Test()
        {
            try
            {
                IConta _iConta = new RepositoryConta();
                IServiceConta _iServiceConta = new ServiceConta(_iConta);
                var conta = new Conta
                {
                    Nome = string.Concat("Descrição Test TDD - ", DateTime.Now.ToString()),
                    ValorOriginal = 100m,
                    DataPagamento = new DateTime(2021,02,26),
                    DataVencimento = new DateTime(2021,02,23)
                };
                await _iServiceConta.AddConta(conta);

                Assert.False(conta.Notitycoes.Any());
            }
            catch (Exception ex)
            {

                Assert.True(false, $@"Erro: {ex.Message}");
            }
        }

        [Fact]
        public async Task AddContaComValidacaoCampoObrigatorio_Test()
        {
            try
            {
                IConta _iConta = new RepositoryConta();
                IServiceConta _iServiceConta = new ServiceConta(_iConta);
                var conta = new Conta
                {

                };
                await _iServiceConta.AddConta(conta);

                Assert.True(conta.Notitycoes.Any());
            }
            catch (Exception ex)
            {

                Assert.True(false, $@"Erro: {ex.Message}");
            }
        }

        [Fact]
        public async Task ListarContas_Test()
        {

            try
            {
                IConta _iConta = new RepositoryConta();

                var listaProdutos = await _iConta.ListarContas();

                Assert.True(listaProdutos.Any());
            }
            catch (Exception ex)
            {

                Assert.True(false, $@"Erro: {ex.Message}");
            }
        }

        [Fact]
        public async Task ListarContaById_Test()
        {
            try
            {
                IConta _iConta = new RepositoryConta();

                var listaConta = await _iConta.ListarContas();
                var ultimaConta = listaConta.LastOrDefault();

                var conta = await _iConta.GetEntityById(ultimaConta.Id);

                Assert.True(conta != null);
            }
            catch (Exception ex)
            {

                Assert.True(false, $@"Erro: {ex.Message}");
            }
        }

        [Fact]
        public async Task DeleteConta_Test()
        {
            try
            {
                IConta _iConta = new RepositoryConta();

                var listaConta = await _iConta.ListarContas();
                var ultimaConta = listaConta.LastOrDefault();

                await _iConta.Delete(ultimaConta);

                Assert.True(true);
            }
            catch (Exception ex)
            {

                Assert.True(false, $@"Erro: {ex.Message}");
            }
        }

    }
}
