using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp
{
    public class TelaPrincipal
    {
        public string ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("Controle de Medicamentos 1.0\n");

            Console.WriteLine("Digite 1 para Menu de Fornecedores");
            Console.WriteLine("Digite 2 para Menu de Funcionários");
            Console.WriteLine("Digite 3 para Menu de Pacientes");
            Console.WriteLine("Digite 4 para Menu de Medicamentos");
            Console.WriteLine("Digite 5 para Menu de Requisições de Entrada");
            Console.WriteLine("Digite 6 para Menu de Requisições de Saída\n");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}

