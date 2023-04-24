using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente
{
    public class TelaPaciente : Tela
    {
        RepositorioPaciente repositorioPaciente;

        public TelaPaciente(RepositorioPaciente repositorioPaciente)
        {
            this.repositorioPaciente = repositorioPaciente;
        }


        public string ApresentarMenuPaciente()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Paciente \n");
            Console.WriteLine("Digite 1 para Inserir Paciente");
            Console.WriteLine("Digite 2 para Visualizar Paciente");
            Console.WriteLine("Digite 3 para Editar Paciente");
            Console.WriteLine("Digite 4 para Excluir Paciente");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;

        }
        public void InserirNovoPaciente()
        {
            MostrarCabecalho("Cadastro de Paciente", "Inserindo um novo Paciente...");

            Paciente paciente = ObterPaciente();

            repositorioPaciente.Inserir(paciente);

            MostrarMensagem("Paciente inserido com sucesso!", ConsoleColor.Green);
        }

        private Paciente ObterPaciente()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o endereço: ");
            string endereco = Console.ReadLine();

            Paciente paciente = new Paciente(nome, telefone, endereco);

            return paciente;
        }

        public void EditarPaciente()
        {
            MostrarCabecalho("Cadastro de Paciente", "Inserindo um novo paciente...");

            VisualizarPaciente(false);

            Console.WriteLine();

            Console.Write("Digite o id do Paciente: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Paciente pacienteAtualizado = ObterPaciente();

            repositorioPaciente.Editar(id, pacienteAtualizado);

            MostrarMensagem("Paciente editado com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirPaciente()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Paciente");

            Console.WriteLine("Excluindo um paciente já cadastrado...");

            Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Paciente excluído com sucesso!");

            Console.ResetColor();

            Console.ReadLine();
        }

        public void VisualizarPaciente(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                MostrarCabecalho("Cadastro de Paciente", "Visualizando pacientes já cadastrados...");

            ArrayList pacientes = repositorioPaciente.SelecionarTodos();

            if (pacientes.Count == 0)
            {
                MostrarMensagem("Nenhum paciente cadastrado", ConsoleColor.DarkYellow);
                return;
            }

            MostrarTabela(pacientes);

        }
        private void MostrarTabela(ArrayList pacientes)
        {
            Console.WriteLine("{0, -10} | {1, -40} | {2, -20}", "Id", "Nome", "Telefone");

            Console.WriteLine("-------------------------------------------------------------------------");

            foreach (Paciente paciente in pacientes)
            {
                Console.WriteLine("{0, -10} | {1, -40} | {2, -20}", paciente.id, paciente.nome, paciente.telefone);
            }
        }
    }
}
