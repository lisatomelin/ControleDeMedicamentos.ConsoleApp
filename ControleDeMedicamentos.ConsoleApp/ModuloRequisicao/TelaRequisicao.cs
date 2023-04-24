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
    public class TelaRequisicao : Tela
    {
        public RepositorioRequisicao repositorioRequisicao;
        public RepositorioFornecedor repositorioFornecedor;
        public RepositorioMedicamento repositorioMedicamento;
        public RepositorioFuncionario repositorioFuncionario;
        public RepositorioPaciente repositorioPaciente;
        public TelaFornecedor telaFornecedor = null;
        public TelaMedicamento telaMedicamento = null;
        public TelaFuncionario telaFuncionario = null;
        public TelaPaciente telaPaciente = null;


        public TelaRequisicao(RepositorioFornecedor repositorioFornecedor, RepositorioMedicamento repositorioMedicamento, RepositorioFuncionario repositorioFuncionario, 
            RepositorioPaciente repositorioPaciente,RepositorioRequisicao repositorioRequisicao)
        {
            this.repositorioRequisicao = repositorioRequisicao;
            this.repositorioFornecedor = repositorioFornecedor;
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioFuncionario = repositorioFuncionario;
            this.repositorioPaciente = repositorioPaciente;
        }
        public string ApresentarMenuRequisicao()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Requisição \n");
            Console.WriteLine("Digite 1 para Inserir Requisição");
            Console.WriteLine("Digite 2 para Editar Requisição");
            Console.WriteLine("Digite 3 para Visualizar Requisição");
            Console.WriteLine("Digite 4 para Excluir Requisição");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
        public void InserirNovaRequisicao()
        {
            MostrarCabecalho("Cadastro de Requisição", "Inserindo uma nova Requisição...");

            Requisicao requisicao = ObterRequisicao();

            repositorioRequisicao.Inserir(requisicao);

            MostrarMensagem("Requisição inserido com sucesso!", ConsoleColor.Green);
        }
        private Requisicao ObterRequisicao()
        {
            
            Console.Write("Digite o Id do Medicamento: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());
            Medicamento medicamento = repositorioMedicamento.SelecionarPorId(idMedicamento);

            Console.Write("Digite o Id do Fornecedor: ");
            int idFornecedor = Convert.ToInt32(Console.ReadLine());
            Fornecedor fornecedor = repositorioFornecedor.SelecionarPorId(idFornecedor);

            Console.Write("Digite o Id do funcionario: ");
            int idFuncionario = Convert.ToInt32(Console.ReadLine());
            Funcionario funcionario = repositorioFuncionario.SelecionarPorId(idFuncionario);
            
            Console.Write("Digite o Id do paciente: ");
            int idPaciente = Convert.ToInt32(Console.ReadLine());
            Paciente paciente = repositorioPaciente.SelecionarPorId(idPaciente);



            Requisicao requisicao = new Requisicao(fornecedor, funcionario, medicamento, paciente);

            return requisicao;
        }

        public void EditarRequisicao()
        {
            MostrarCabecalho("Cadastro de Requisição", "Inserindo um nova Requisição...");

            VisualizarRequisicao(false);

            Console.WriteLine();

            Console.Write("Digite o id da Requisição: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Requisicao requisicaoAtualizado = ObterRequisicao();

            repositorioRequisicao.Editar(id, requisicaoAtualizado);

            MostrarMensagem("Requisição editada com sucesso!", ConsoleColor.Green);

        }

        public void VisualizarRequisicao(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                MostrarCabecalho("Cadastro de Requisição", "Visualizando requisições já cadastradas...");

            ArrayList requisicoes = repositorioRequisicao.SelecionarTodos();

            if (requisicoes.Count == 0)
            {
                MostrarMensagem("Nenhuma requisição cadastrada", ConsoleColor.DarkYellow);
                return;
            }

            MostrarTabela(requisicoes);
        }
        public void ExcluirRequisicao()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Requisição");

            Console.WriteLine("Excluindo uma requisição já cadastrada...");

            Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Requisição excluída com sucesso!");

            Console.ResetColor();

            Console.ReadLine();
        }
        private void MostrarTabela(ArrayList requisicoes)
        {
            Console.WriteLine("{0, -10} | {1, -40} | {2, -20}", "Id do Medicamento", "Id do Fornecedor", "Id do Funcionário", "Id do Paciente");

            Console.WriteLine("-------------------------------------------------------------------------");

            foreach (Requisicao requisicao in requisicoes)
            {
                Console.WriteLine("{0, -10} | {1, -40} | {2, -20}", requisicao.medicamento.id, requisicao.fornecedor.id, requisicao.funcionario.id, requisicao.paciente.id);
            }
        }
    }
}
