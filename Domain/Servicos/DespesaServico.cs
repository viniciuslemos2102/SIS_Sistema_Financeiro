using Domain.Interfaces.IDespesas;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;

namespace Domain.Servicos
{
    public class DespesaServico : IDespesaServico
    {
        private readonly InterfaceDespesa _interfaceDespesa;
        public DespesaServico(InterfaceDespesa interfaceDespesa)
        {
            _interfaceDespesa = interfaceDespesa;
        }
        public async Task AdicionarDespesa(Despesa despesa)
        {
            var data = DateTime.UtcNow;
            despesa.DataCadastro = data;
            despesa.Ano = data.Year;
            despesa.Mes = data.Month;

            var valido = despesa.ValidarPropriedadeString(despesa.Nome, "Nome");
            if (valido)
                await _interfaceDespesa.Add(despesa);
        }

        public async Task AtualizarDespesa(Despesa despesa)
        {
            var data = DateTime.UtcNow;
            despesa.DataAlteracao = data;

            if (despesa.Pago)
            {
                despesa.DataPagamento = data;
            }

            var valido = despesa.ValidarPropriedadeString(despesa.Nome, "Nome");
            if (valido)
                await _interfaceDespesa.Update(despesa);
        }

        public async Task<object> CarregaGraficos(string EmailUsuario)
        {
            var despesasUsuario = await _interfaceDespesa.ListarDespesasUsuario(EmailUsuario);
            var despesasAnteriores = await _interfaceDespesa.ListarDespesasUsuarioNaoPagasMesesAnterior(EmailUsuario);
            
            var despesasNaoPagasMesesAnterior = despesasAnteriores.Any() ?
                despesasAnteriores.ToList().Sum(x => x.Valor) : 0;
            
            var despesas_pagas = despesasUsuario.Where(d => d.Pago && d.TipoDespesa == Entities.Enums.EnumTipoDespesa.contas)
                .Sum(x => x.Valor);

            var despesaPendentes = despesasUsuario.Where(p => !p.Pago && p.TipoDespesa == Entities.Enums.EnumTipoDespesa.contas)
                .Sum(x => x.Valor);

            var investimentos = despesasUsuario.Where(p => p.TipoDespesa == Entities.Enums.EnumTipoDespesa.investimento)
                .Sum(x => x.Valor);

            return new
            {
                sucesso = "Ok",
                despesas_pagas = despesas_pagas,
                despesaPendentes = despesaPendentes,
                despesasNaoPagasMesesAnterior = despesasNaoPagasMesesAnterior,
                investimentos = investimentos
            };
        }
    }
}
