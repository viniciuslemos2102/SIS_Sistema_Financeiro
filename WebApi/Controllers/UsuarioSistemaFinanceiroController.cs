using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioSistemaFinanceiroController : ControllerBase
    {
        private readonly InterfaceUsuarioSistemaFinanceiro _interfaceUsuarioSistemaFinanceiro;
        private readonly IUsuarioSistemaFinanceiroServico _usuarioSistemaFinanceiroServico;
        public UsuarioSistemaFinanceiroController(InterfaceUsuarioSistemaFinanceiro interfaceUsuarioSistemaFinanceiro,
            IUsuarioSistemaFinanceiroServico usuarioSistemaFinanceiroServico)
        {
            _interfaceUsuarioSistemaFinanceiro = interfaceUsuarioSistemaFinanceiro;
            _usuarioSistemaFinanceiroServico = _usuarioSistemaFinanceiroServico;
        }
        [HttpGet("/api/ListaSistemaUsuario")]
        [Produces("application/json")]
        public async Task<object> ListaSistemaUsuario(int idSistema)
        {
            return await _interfaceUsuarioSistemaFinanceiro.ListarUsuarioSistema(idSistema);
        }

        [HttpPost("/api/CadastraUsuarioNoSistema")]
        [Produces("application/json")]
        public async Task<object> CadastraUsuarioNoSistema(int idSistema, string emailUsuario)
        {
            try
            {
                await _usuarioSistemaFinanceiroServico.CadastraUsuarioNoSistema(
                new UsuarioSistemaFinanceiro
                {
                    IdSistema = idSistema,
                    EmailUsuario = emailUsuario,
                    Administrador = false,
                    SistemaAtual = true
                });
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }
             return Task.FromResult(true);
        }

        [HttpDelete("/api/DeleteUsuarioSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> DeleteUsuarioSistemaFinanceiro(int id)
        {
            try
            {
                var usuarioSistemaFinanceiro = await _interfaceUsuarioSistemaFinanceiro.GetEntityById(id);
                await _interfaceUsuarioSistemaFinanceiro.Delete(usuarioSistemaFinanceiro);
               
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}
