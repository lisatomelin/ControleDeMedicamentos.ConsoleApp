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

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class RequisicaoSaida : EntidadeBase
    {
        public Medicamento medicamento;
        public int quantidade;
        public DateTime data;
        public Funcionario funcionario;

        public Paciente paciente;

        public RequisicaoSaida(Medicamento medicamento, int quantidade, DateTime data, Funcionario funcionario, Paciente paciente)
        {
            this.medicamento = medicamento;
            this.data = data;
            this.funcionario = funcionario;
            this.paciente = paciente;
            this.quantidade = quantidade;
            this.medicamento.RemoverQuantidade(quantidade);
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            RequisicaoSaida requisicaoSaidaAtualizada = (RequisicaoSaida)registroAtualizado;

            this.medicamento = requisicaoSaidaAtualizada.medicamento;
            this.quantidade = requisicaoSaidaAtualizada.quantidade;
            this.data = requisicaoSaidaAtualizada.data;
            this.funcionario = requisicaoSaidaAtualizada.funcionario;
            this.paciente = requisicaoSaidaAtualizada.paciente;
        }

        public void DesfazerRegistroSaida()
        {
            medicamento.RegistrarEntrada(quantidade);
        }
    }
}
