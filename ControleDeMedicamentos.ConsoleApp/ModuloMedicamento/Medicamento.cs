using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class Medicamento : EntidadeBase
    {
        public string nome;
        public string descricao;
        public string lote;
        public int quantidade;
        public DateTime datavalidade;
        public Fornecedor fornecedor;

        public int quantidadeRequisicoesSaida;

        public Medicamento(string nome, string descricao, string lote, DateTime validade, Fornecedor fornecedor)
        {
            this.nome = nome;
            this.descricao = descricao;
            this.lote = lote;
            this.datavalidade = validade;
            this.fornecedor = fornecedor;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Medicamento atualizarMedicamento = (Medicamento)registroAtualizado;

            this.nome = atualizarMedicamento.nome;
            this.descricao = atualizarMedicamento.descricao;
            this.lote = atualizarMedicamento.lote;
            this.datavalidade = atualizarMedicamento.datavalidade;
            this.fornecedor = atualizarMedicamento.fornecedor;
        }

        public void RegistrarEntrada(int qtde)
        {
            this.quantidade += qtde;
        }

        public void RemoverQuantidade(int qtde)
        {
            quantidadeRequisicoesSaida++;
            this.quantidade -= qtde;
        }
    }
}
