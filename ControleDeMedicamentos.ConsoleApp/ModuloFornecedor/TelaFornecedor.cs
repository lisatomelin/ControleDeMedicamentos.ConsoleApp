using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class TelaFornecedor : TelaBase
    {
        public TelaFornecedor(RepositorioFornecedor repositorioFornecedor)
        {
            this.repositorioBase = repositorioFornecedor;
            nomeEntidade = "Fornecedor";
            sufixo = "es";
        }
        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", "Id", "Nome", "Telefone");

            Console.WriteLine("-------------------------------------------------------------------");

            foreach (Fornecedor fornecedor in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", fornecedor.id, fornecedor.nome, fornecedor.telefone);

            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.WriteLine("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o Telefone: ");
            string telefone = Console.ReadLine();

            Console.WriteLine("Digite o email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Digite a Cidade: ");
            string cidade = Console.ReadLine();

            Console.WriteLine("Digite o Estado: ");
            string estado = Console.ReadLine();

            return new Fornecedor(nome, telefone, email, cidade, estado);
        }
    }



}