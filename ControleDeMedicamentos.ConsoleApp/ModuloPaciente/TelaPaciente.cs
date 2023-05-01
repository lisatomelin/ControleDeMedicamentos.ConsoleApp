using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente
{
    public class TelaPaciente : TelaBase
    {
        public TelaPaciente(RepositorioPaciente repositorioPaciente)
        {
            this.repositorioBase = repositorioPaciente;
            nomeEntidade = "Paciente";
            sufixo = "s";
        }
        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", "Id", "Nome", "Cartão SUS");

            Console.WriteLine("-------------------------------------------------------------------");

            foreach (Paciente paciente in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", paciente.id, paciente.nome, paciente.cartaoSUS);

            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.WriteLine("Digite o Nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o Cartão SUS: ");
            string cartaoSUS = Console.ReadLine();

            return new Paciente(nome, cartaoSUS);
        }
    }
}

