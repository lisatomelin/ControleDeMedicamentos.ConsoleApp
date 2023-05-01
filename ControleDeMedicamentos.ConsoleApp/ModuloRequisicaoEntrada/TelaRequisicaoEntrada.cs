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
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicao;

namespace ControleDeMedicamentos.ConsoleApp.ModuloReposicao
{
    public class TelaRequisicaoEntrada : TelaBase
    {
        private RepositorioRequisicaoEntrada repositorioRequisicaoEntrada;
        private RepositorioFuncionario repositorioFuncionario;
        private RepositorioMedicamento repositorioMedicamento;


        private TelaFuncionario telaFuncionario;
        private TelaMedicamento telaMedicamento;

        public TelaRequisicaoEntrada(RepositorioRequisicaoEntrada repositorioRequisicaoEntrada,
            RepositorioFuncionario repositorioFuncionario, RepositorioMedicamento repositorioMedicamento,
            TelaFuncionario telaFuncionario, TelaMedicamento telaMedicamento)
        {
            this.repositorioBase = repositorioRequisicaoEntrada;
            this.repositorioRequisicaoEntrada = repositorioRequisicaoEntrada;
            this.repositorioFuncionario = repositorioFuncionario;
            this.repositorioMedicamento = repositorioMedicamento;
            this.telaFuncionario = telaFuncionario;
            this.telaMedicamento = telaMedicamento;

            nomeEntidade = "Requisições de Entrada";

        }

        public override void EditarRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Editando um registro já cadastrado...");

            VisualizarRegistros(false);

            Console.WriteLine();

            Console.Write("Digite o id do registro: ");
            int id = Convert.ToInt32(Console.ReadLine());

            RequisicaoEntrada requisicaoEntrada = repositorioRequisicaoEntrada.SelecionarPorId(id);

            EntidadeBase registroAtualizado = ObterRegistro();

            requisicaoEntrada.DesfazerRegistroEntrada();

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

            RequisicaoEntrada requisicaoEntrada = repositorioRequisicaoEntrada.SelecionarPorId(id);

            requisicaoEntrada.DesfazerRegistroEntrada();

            repositorioBase.Excluir(id);

            MostrarMensagem("Registro excluído com sucesso!", ConsoleColor.Green);
        }

        protected override void MostrarTabela(ArrayList registros)
        {

            Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -20} ", "Id", "Data", "Medicamento", "Fornecedor", "Quantidade");

            Console.WriteLine("----------------------------------------------------------------------------------------------------------");

            foreach (RequisicaoEntrada requisicaoEntrada in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}",
                    requisicaoEntrada.id,
                    requisicaoEntrada.data.ToShortDateString(),
                    requisicaoEntrada.medicamento.nome,
                    requisicaoEntrada.medicamento.fornecedor.nome,
                    requisicaoEntrada.quantidade);

            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            telaMedicamento.VisualizarRegistros(false);

            Medicamento medicamento = ObterMedicamento();

            Funcionario funcionario = ObterFuncionario();

            Console.WriteLine("Digite a quantidade de caixas:");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite a data:");
            DateTime data = Convert.ToDateTime(Console.ReadLine());

            return new RequisicaoEntrada(medicamento, quantidade, data, funcionario);
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
            Console.WriteLine("Digite o id do Medicamento:");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());

            Medicamento medicamento = repositorioMedicamento.SelecionarPorId(idMedicamento);
            return medicamento;
        }
    }
}
