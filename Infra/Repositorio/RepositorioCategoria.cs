using Domain.Interfaces.ICategoria;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioCategoria : RepositoryGenerics<Categoria>, InterfaceCategoria
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioCategoria()
        {
                _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<IList<Categoria>> ListaCategoriaUsuario(string emailUsuario)
        {
            using (var Banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    (from s in Banco.SistemaFinanceiro
                     join c in Banco.Categoria on s.Id equals c.IdSistema
                     join us in Banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                     where us.EmailUsuario.Equals(emailUsuario) && us.SistemaAtual
                     select c).AsNoTracking().ToListAsync();
            }
        }
    }
}
