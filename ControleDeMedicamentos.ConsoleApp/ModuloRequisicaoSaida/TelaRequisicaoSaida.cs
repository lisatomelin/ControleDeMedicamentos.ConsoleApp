using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloReposicao;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class TelaRequisicaoSaida : TelaBase
    {
        private RepositorioRequisicaoSaida repositorioRequisicaoSaida;
        private RepositorioFuncionario repositorioFuncionario;
        private RepositorioMedicamento repositorioMedicamento;
        private RepositorioPaciente repositorioPaciente;


        private TelaFuncionario telaFuncionario;
        private TelaMedicamento telaMedicamento;
        private TelaPaciente telaPaciente;

        public TelaRequisicaoSaida(RepositorioRequisicaoSaida repositorioRequisicaoSaida, RepositorioFuncionario repositorioFuncionario, RepositorioMedicamento repositorioMedicamento,
            RepositorioPaciente repositorioPaciente, TelaFuncionario telaFuncionario,
            TelaMedicamento telaMedicamento, TelaPaciente telaPaciente)
        {
            this.repositorioBase = repositorioRequisicaoSaida;
            this.repositorioFuncionario = repositorioFuncionario;
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioPaciente = repositorioPaciente;
            this.telaFuncionario = telaFuncionario;
            this.telaMedicamento = telaMedicamento;
            this.telaPaciente = telaPaciente;

            nomeEntidade = "Requisições Saída";
        }
        public override void EditarRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Editando um registro já cadastrado...");

            VisualizarRegistros(false);

            Console.WriteLine();

            Console.Write("Digite o id do registro: ");
            int id = Convert.ToInt32(Console.ReadLine());

            RequisicaoSaida requisicaoSaida = repositorioRequisicaoSaida.SelecionarPorId(id);

            EntidadeBase registroAtualizado = ObterRegistro();

            requisicaoSaida.DesfazerRegistroSaida();

            repositorioBase.Editar(id, registroAtualizado);

            MostrarMensagem("Registro editado com sucesso!", ConsoleColor.Green);
        }

        public override void ExcluirRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Excluindo um registro já cadastrado...");

            VisualizarRegistros(false);

            Console.WriteLine();

            Console.Write("Digite o id do Registro: ");
            int id = Convert.ToInt32(Console.ReadLine());

            RequisicaoSaida requisicaoSaida = repositorioRequisicaoSaida.SelecionarPorId(id);

            requisicaoSaida.DesfazerRegistroSaida();

            repositorioBase.Excluir(id);

            MostrarMensagem("Registro excluído com sucesso!", ConsoleColor.Green);
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -20} | {5, -20} | {6, -20} ", "Id", "Data", "Medicamento", "Paciente", "Fornecedor", "Quantidade");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------");

            foreach (RequisicaoSaida requisicaoSaida in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -20} | {5, -20} | {6, -20}",
                    requisicaoSaida.id,
                    requisicaoSaida.data.ToShortDateString(),
                    requisicaoSaida.medicamento.nome,
                    requisicaoSaida.paciente,
                    requisicaoSaida.medicamento.fornecedor.nome,
                    requisicaoSaida.quantidade);

            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Medicamento medicamento = ObterMedicamento();

            Funcionario funcionario = ObterFuncionario();

            Paciente paciente = ObterPaciente();

            Console.WriteLine("Digite a quantidade de caixas:");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite a data:");
            DateTime data = Convert.ToDateTime(Console.ReadLine());

            return new RequisicaoSaida(medicamento, quantidade, data, funcionario, paciente);
        }

        private Paciente ObterPaciente()
        {
            telaPaciente.VisualizarRegistros(false);

            Console.WriteLine("Digite o id do Paciente:");
            int idPaciente = Convert.ToInt32(Console.ReadLine());

            Paciente paciente = repositorioPaciente.SelecionarPorId(idPaciente);

            return paciente;
        }

        private Funcionario ObterFuncionario()
        {
            telaFuncionario.VisualizarRegistros(false);

            Console.WriteLine("Digite o id do Funcionário:");
            int idFuncionario = Convert.ToInt32(Console.ReadLine());

            Funcionario funcionario = repositorioFuncionario.SelecionarPorId(idFuncionario);
            return funcionario;

        }

        private Medicamento ObterMedicamento()
        {
            telaMedicamento.VisualizarRegistros(false);

            Console.WriteLine("Digite o id do Medicamento:");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());

            Medicamento medicamento = repositorioMedicamento.SelecionarPorId(idMedicamento);
            return medicamento;
        }
    }
}
