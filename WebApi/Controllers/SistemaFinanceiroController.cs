using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ISistemaFinanceiro;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SistemaFinanceiroController : ControllerBase
    {
        private readonly InterfaceSistemaFinanceiro _interfaceSistemaFinanceiro;
        private readonly ISistemaFinanceiroServico  _IsistemaFinanceiroServico;
        public SistemaFinanceiroController(InterfaceSistemaFinanceiro interfaceSistemaFinanceiro, 
            ISistemaFinanceiroServico IsistemaFinanceiroServico)
        {
            _interfaceSistemaFinanceiro = interfaceSistemaFinanceiro;
            _IsistemaFinanceiroServico = IsistemaFinanceiroServico;
        }
        [HttpGet("/api/ListaSistemaUsuario")]
        [Produces("application/json")]
        public async Task<object> ListaSistemaUsuario(string emailUsuario)
        {
            return await _interfaceSistemaFinanceiro.ListaSistemaUsuario(emailUsuario);
        }

        [HttpPost("/api/AdicionarSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
             await _IsistemaFinanceiroServico.AdicionarSistemaFinanceiro(sistemaFinanceiro);
            return Task.FromResult(sistemaFinanceiro);
        }

        [HttpPut("/api/AtualizarSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            await _IsistemaFinanceiroServico.AtualizarSistemaFinanceiro(sistemaFinanceiro);
            return Task.FromResult(sistemaFinanceiro);
        }

        [HttpGet("/api/ObterSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> ObterSistemaFinanceiro(int id)
        {
           return await _interfaceSistemaFinanceiro.GetEntityById(id);    
           
        }
        [HttpDelete("/api/DeleteSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> DeleteSistemaFinanceiro(int id)
        {
            try
            {
                var sistemafinanceiro = await _interfaceSistemaFinanceiro.GetEntityById(id);
                await _interfaceSistemaFinanceiro.Delete(sistemafinanceiro);


            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }
    }
}
