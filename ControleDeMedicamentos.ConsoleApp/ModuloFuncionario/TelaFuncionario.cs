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
    public class TelaFuncionario : TelaBase
    {
        public TelaFuncionario(RepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioBase = repositorioFuncionario;
            nomeEntidade = "Funcionário";
            sufixo = "s";
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", "Id", "Login", "Senha");

            Console.WriteLine("-------------------------------------------------------------------");

            foreach (Funcionario funcionario in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", funcionario.id, funcionario.login, funcionario.senha);

            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.WriteLine("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o Login: ");
            string login = Console.ReadLine();

            Console.WriteLine("Digite a Senha: ");
            string senha = Console.ReadLine();

            return new Funcionario(nome, login, senha);
        }
    }
}
