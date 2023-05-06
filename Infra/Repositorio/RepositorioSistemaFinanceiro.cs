using Domain.Interfaces.ISistemaFinanceiro;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioSistemaFinanceiro : RepositoryGenerics<SistemaFinanceiro>, InterfaceSistemaFinanceiro
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public RepositorioSistemaFinanceiro()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<IList<SistemaFinanceiro>> ListaSistemaUsuario(string emailUsuario)
        {
            using (var Banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    (from s in Banco.SistemaFinanceiro
                     join us in Banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                     where us.EmailUsuario.Equals(emailUsuario)
                     select s).AsNoTracking().ToListAsync();

            }
            
        }
    }
}
