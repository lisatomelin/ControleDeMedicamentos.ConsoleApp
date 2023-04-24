using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario
{
    public class TelaFuncionario : Tela
    {
        RepositorioFuncionario repositorioFuncionario;

        public TelaFuncionario(RepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }
        public string ApresentarMenuFuncionario()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Funcionário \n");
            Console.WriteLine("Digite 1 para Inserir Funcionário");
            Console.WriteLine("Digite 2 para Editar Funcionário");
            Console.WriteLine("Digite 3 para Visualizar Funcionário");
            Console.WriteLine("Digite 4 para Excluir Funcionário");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovoFuncionario()
        {
            MostrarCabecalho("Cadastro de Funcionário", "Inserindo um novo Funcionário...");

            Funcionario funcionario = ObterFuncionario();

            repositorioFuncionario.Inserir(funcionario);

            MostrarMensagem("Funcionario inserido com sucesso!", ConsoleColor.Green);
        }

        private Funcionario ObterFuncionario()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o endereço: ");
            string endereco = Console.ReadLine();

            Funcionario funcionario = new Funcionario(nome, telefone, endereco);

            return funcionario;
        }

        public void EditarFuncionario()
        {
            MostrarCabecalho("Cadastro de Funcionario", "Inserindo um novo Funcionario...");

            VisualizarFuncionario(false);

            Console.WriteLine();

            Console.Write("Digite o id do Funcionario: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Funcionario funcionarioAtualizado = ObterFuncionario();

            repositorioFuncionario.Editar(id, funcionarioAtualizado);

            MostrarMensagem("Funcionario editado com sucesso!", ConsoleColor.Green);

        }

        public void VisualizarFuncionario(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                MostrarCabecalho("Cadastro de Funcionário", "Visualizando funcionários já cadastrados...");

            ArrayList funcionarios = repositorioFuncionario.SelecionarTodos();

            if (funcionarios.Count == 0)
            {
                MostrarMensagem("Nenhum funcionário cadastrado", ConsoleColor.DarkYellow);
                return;
            }

            MostrarTabela(funcionarios);
        }

        public void ExcluirFuncionario()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Funcionário");

            Console.WriteLine("Excluindo um funcionário já cadastrado...");

            Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Funcionário excluído com sucesso!");

            Console.ResetColor();

            Console.ReadLine();
        }
        private void MostrarTabela(ArrayList funcionarios)
        {
            Console.WriteLine("{0, -10} | {1, -40} | {2, -20}", "Id", "Nome", "Telefone");

            Console.WriteLine("-------------------------------------------------------------------------");

            foreach (Funcionario funcionario in funcionarios)
            {
                Console.WriteLine("{0, -10} | {1, -40} | {2, -20}", funcionario.id, funcionario.nome, funcionario.telefone);
            }
        }
    }
}
