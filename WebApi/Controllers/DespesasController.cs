using Domain.Interfaces.ICategoria;
using Domain.Interfaces.IDespesas;
using Domain.Interfaces.InterfaceServicos;
using Domain.Servicos;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DespesasController : ControllerBase
    {
        private readonly InterfaceDespesa _interfaceDespesa;
        private readonly IDespesaServico _IdespesaServico;

        public DespesasController(InterfaceDespesa interfaceDespesa, 
            IDespesaServico IdespesaServico )
        {
            _interfaceDespesa = interfaceDespesa;
            _IdespesaServico = IdespesaServico;
        }
        [HttpGet("/api/ListaDespesasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListaDespesasUsuario(string emailUsuario)
        {
            return await _interfaceDespesa.ListarDespesasUsuario(emailUsuario);
        }
        [HttpPost("/api/AdicionarDespesa")]
        [Produces("application/json")]
        public async Task<object> AdicionarDespesa(Despesa despesa)
        {
            await _IdespesaServico.AdicionarDespesa(despesa);

            return despesa;
        }

        [HttpPut("/api/AtualizarDespesa")]
        [Produces("application/json")]
        public async Task<object> AtualizarDespesa(Despesa despesa)
        {
            await _IdespesaServico.AtualizarDespesa(despesa);

            return despesa;
        }


        [HttpGet("/api/ObterDespesa")]
        [Produces("application/json")]
        public async Task<object> ObterDespesa(int id)
        {
            return await _interfaceDespesa.GetEntityById(id);
        }

        [HttpDelete("/api/DeletaDespesa")]
        [Produces("application/json")]
        public async Task<object> DeletaDespesa(int id)
        {
            try
            {
                var categoria = await _interfaceDespesa.GetEntityById(id);
                await _interfaceDespesa.Delete(categoria);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        [HttpGet("/api/CarregaGraficos")]
        [Produces("application/json")]
        public async Task<object> CarregaGraficos(string emailUsuario)
        {
            return await _IdespesaServico.CarregaGraficos(emailUsuario);
        }
    }
}
