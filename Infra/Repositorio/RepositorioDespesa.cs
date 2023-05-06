using Domain.Interfaces.IDespesas;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioDespesa : RepositoryGenerics<Despesa>, InterfaceDespesa
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public RepositorioDespesa()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<IList<Despesa>> ListarDespesasUsuario(string emailUsuario)
        {
            using (var Banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    (from s in Banco.SistemaFinanceiro
                     join c in Banco.Categoria on s.Id equals c.IdSistema
                     join us in Banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                     join d in Banco.Despesa on c.Id equals d.IdCategoria
                     where us.EmailUsuario.Equals(emailUsuario) && s.Mes == d.Mes && s.Ano == d.Ano
                     select d).AsNoTracking().ToListAsync();
            }
        }

        public async Task<IList<Despesa>> ListarDespesasUsuarioNaoPagasMesesAnterior(string emailUsuario)
        {
            using (var Banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    (from s in Banco.SistemaFinanceiro
                     join c in Banco.Categoria on s.Id equals c.IdSistema
                     join us in Banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                     join d in Banco.Despesa on c.Id equals d.IdCategoria
                     where us.EmailUsuario.Equals(emailUsuario) && d.Mes < DateTime.Now.Month &&  !d.Pago
                     select d).AsNoTracking().ToListAsync();
            }
        }
    }
}
