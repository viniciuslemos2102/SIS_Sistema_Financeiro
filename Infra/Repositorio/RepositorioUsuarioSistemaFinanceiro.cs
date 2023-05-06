using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioUsuarioSistemaFinanceiro : RepositoryGenerics<UsuarioSistemaFinanceiro>, InterfaceUsuarioSistemaFinanceiro
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public RepositorioUsuarioSistemaFinanceiro()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<IList<UsuarioSistemaFinanceiro>> ListarUsuarioSistema(int IdSistema)
        {
            using (var Banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    Banco.UsuarioSistemaFinanceiro
                    .Where(s => s.IdSistema == IdSistema).AsNoTracking()
                    .ToListAsync();
            }
        }

        public async Task<UsuarioSistemaFinanceiro> ObterUsuarioSistemaPorEmail(string emailUsuario)
        {
            using (var Banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    Banco.UsuarioSistemaFinanceiro.AsNoTracking().
                    FirstOrDefaultAsync(x => x.EmailUsuario.Equals(emailUsuario));
            }
        }

        public async Task RemoveUsuarios(List<UsuarioSistemaFinanceiro> usuarios)
        {
            using (var Banco = new ContextBase(_OptionsBuilder))
            {
                    Banco.UsuarioSistemaFinanceiro
                    .RemoveRange(usuarios);
                await Banco.SaveChangesAsync();
            }
        }
    }
}
