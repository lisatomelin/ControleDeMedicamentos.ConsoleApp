using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloReposicao
{
    public class RequisicaoEntrada : EntidadeBase
    {
        public Medicamento medicamento;
        public int quantidade;
        public DateTime data;
        public Funcionario funcionario;

        public RequisicaoEntrada(Medicamento medicamento, int quantidade, DateTime data, Funcionario funcionario)
        {
            this.medicamento = medicamento;
            this.quantidade = quantidade;
            this.data = data;
            this.funcionario = funcionario;

            this.medicamento.RegistrarEntrada(quantidade);
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            RequisicaoEntrada requisicaoEntradaAtualizada = (RequisicaoEntrada)registroAtualizado;
            this.medicamento = requisicaoEntradaAtualizada.medicamento;
            this.quantidade = requisicaoEntradaAtualizada.quantidade;
            this.data = requisicaoEntradaAtualizada.data;
            this.funcionario = requisicaoEntradaAtualizada.funcionario;
        }

        public void DesfazerRegistroEntrada()
        {
            medicamento.RemoverQuantidade(quantidade);
        }
    }

}

