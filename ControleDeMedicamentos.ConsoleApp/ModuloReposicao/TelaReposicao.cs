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
    public class TelaReposicao : Tela
    {
        public RepositorioReposicao repositorioReposicao;
        public RepositorioFornecedor repositorioFornecedor;
        public RepositorioMedicamento repositorioMedicamento;
        public RepositorioFuncionario repositorioFuncionario;
        public TelaFornecedor telaFornecedor = null;
        public TelaMedicamento telaMedicamento = null;
        public TelaFuncionario telaFuncionario = null;

        public TelaReposicao(RepositorioFornecedor repositorioFornecedor, RepositorioMedicamento repositorioMedicamento, RepositorioFuncionario repositorioFuncionario,
            RepositorioReposicao repositorioReposicao)
        { 
            this.repositorioReposicao = repositorioReposicao;
            this.repositorioFornecedor = repositorioFornecedor;
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioFuncionario = repositorioFuncionario;
            
        }
        public string ApresentarMenuReposicao()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Reposição \n");
            Console.WriteLine("Digite 1 para Inserir Reposição");
            Console.WriteLine("Digite 2 para Editar Reposição");
            Console.WriteLine("Digite 3 para Visualizar Reposição");
            Console.WriteLine("Digite 4 para Excluir Reposição");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

 
        public void InserirNovaReposicao()
        {
            MostrarCabecalho("Cadastro de Reposição", "Inserindo uma nova Reposição...");

            Reposicao reposicao = ObterReposicao();

            repositorioReposicao.Inserir(reposicao);

            MostrarMensagem("Reposicao inserido com sucesso!", ConsoleColor.Green);
        }
        private Reposicao ObterReposicao()
        {
            Console.Write("Digite o Id do Medicamento: ");
            int idMedicamento  = Convert.ToInt32(Console.ReadLine());
            Medicamento medicamento = repositorioMedicamento.SelecionarPorId(idMedicamento);

            Console.Write("Digite o Id do Fornecedor: ");
            int idFornecedor = Convert.ToInt32(Console.ReadLine());
            Fornecedor fornecedor = repositorioFornecedor.SelecionarPorId(idFornecedor);

            Console.Write("Digite o Id do funcionario: ");
            int idFuncionario = Convert.ToInt32(Console.ReadLine());
            Funcionario funcionario = repositorioFuncionario.SelecionarPorId(idFuncionario);

            
            Reposicao reposicao = new Reposicao(fornecedor, funcionario, medicamento);

            return reposicao;
        }
        public void EditarReposicao()
        {
            MostrarCabecalho("Cadastro de Reposição", "Inserindo um nova Reposição...");

            VisualizarReposicao(false);

            Console.WriteLine();

            Console.Write("Digite o id da Reposição: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Reposicao reposicaoAtualizado = ObterReposicao();

            repositorioReposicao.Editar(id, reposicaoAtualizado);

            MostrarMensagem("Reposição editada com sucesso!", ConsoleColor.Green);
        }

        public void VisualizarReposicao(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                MostrarCabecalho("Cadastro de Reposição", "Visualizando reposições já cadastradas...");

            ArrayList reposicoes = repositorioReposicao.SelecionarTodos();

            if (reposicoes.Count == 0)
            {
                MostrarMensagem("Nenhuma reposição cadastrada", ConsoleColor.DarkYellow);
                return;
            }

            MostrarTabela(reposicoes);
        }
        public void ExcluirReposicao()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Reposição");

            Console.WriteLine("Excluindo uma reposição já cadastrada...");

            Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Reposição excluída com sucesso!");

            Console.ResetColor();

            Console.ReadLine();
        }
        private void MostrarTabela(ArrayList reposicoes)
        {
            Console.WriteLine("{0, -10} | {1, -40} | {2, -20}", "Id", "Nome", "Telefone");

            Console.WriteLine("-------------------------------------------------------------------------");

            foreach (Reposicao reposicao in reposicoes)
            {
                Console.WriteLine("{0, -10} | {1, -40} | {2, -20}", reposicao.medicamento.id, reposicao.fornecedor.id, reposicao.funcionario.id);
            }
        }
    }
}
