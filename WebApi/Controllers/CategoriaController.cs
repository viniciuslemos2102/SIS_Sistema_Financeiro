using Domain.Interfaces.ICategoria;
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
    public class CategoriaController : ControllerBase
    {
        private readonly InterfaceCategoria _interfaceCategoria;
        private readonly ICategoriaServico _icategoriaServico;
        public CategoriaController(InterfaceCategoria interfaceCategoria, ICategoriaServico categoriaServico)
        {
            _interfaceCategoria = interfaceCategoria;
            _icategoriaServico = categoriaServico;
        }
        [HttpGet("/api/ListaCategoriaUsuario")]
        [Produces("application/json")]
        public async Task<object> ListaCategoriaUsuario(string emailUsuario)
        {
            return await _interfaceCategoria.ListaCategoriaUsuario(emailUsuario);
        }

        [HttpPost("/api/AdicionarCategoria")]
        [Produces("application/json")]
        public async Task<object> AdicionarCategoriaUsuario(Categoria categoria)
        {
            await _icategoriaServico.AdicionarCategoria(categoria);

            return categoria;
        }

        [HttpPut("/api/AtualizarCategoria")]
        [Produces("application/json")]
        public async Task<object> AtualizarCategoria(Categoria categoria)
        {
            await _icategoriaServico.AtualizarCategoria(categoria);

            return categoria;
        }

        [HttpGet("/api/ObterCategoria")]
        [Produces("application/json")]
        public async Task<object> ObterCategoria(int id)
        {
           return await _interfaceCategoria.GetEntityById(id);
        }

        [HttpDelete("/api/DeletaCategoria")]
        [Produces("application/json")]
        public async Task<object> DeletaCategoria(int id)
        {
            try
            {
                var categoria = await _interfaceCategoria.GetEntityById(id);
                await _interfaceCategoria.Delete(categoria);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
    }
}
