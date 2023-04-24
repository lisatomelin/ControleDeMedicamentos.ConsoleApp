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
    public class TelaFornecedor : Tela
    {
        RepositorioFornecedor repositorioFornecedor;
        RepositorioMedicamento repositorioMedicamento;
        TelaMedicamento telaMedicamento = null;

        public TelaFornecedor(RepositorioFornecedor repositorioFornecedor, 
            RepositorioMedicamento repositorioMedicamento)
        {
            this.repositorioFornecedor = repositorioFornecedor;
            this.repositorioMedicamento = repositorioMedicamento;
            
        }

       
        public string ApresentarMenuFornecedor()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Fornecedor \n");
            Console.WriteLine("Digite 1 para Inserir Fornecedor");
            Console.WriteLine("Digite 2 para Editar Fornecedor");
            Console.WriteLine("Digite 3 para Visualizar Fornecedor");
            Console.WriteLine("Digite 4 para Excluir Fornecedor");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovoFornecedor()
        {
            MostrarCabecalho("Cadastro de Fornecedor", "Inserindo um novo Fornecedor...");

            Fornecedor fornecedor = ObterFornecedor();

            repositorioFornecedor.Inserir(fornecedor);

            MostrarMensagem("Fornecedor inserido com sucesso!", ConsoleColor.Green);

        }
        public void EditarFornecedor()
        {
            MostrarCabecalho("Cadastro de Fornecedor", "Inserindo um novo fornecedor...");

            VisualizarFornecedor(false);

            Console.WriteLine();

            Console.Write("Digite o id do fornecedor: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Fornecedor fornecedorAtualizado = ObterFornecedor();

            repositorioFornecedor.Editar(id,fornecedorAtualizado);

            MostrarMensagem("Fornecedor editado com sucesso!", ConsoleColor.Green);
        }
        public void VisualizarFornecedor(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                MostrarCabecalho("Cadastro de Fornecedor", "Visualizando Fornecedores já cadastrados...");

            ArrayList fornecedores = repositorioFornecedor.SelecionarTodos();

            if (fornecedores.Count == 0)
            {
                MostrarMensagem("Nenhum Fornecedor cadastrado", ConsoleColor.DarkYellow);
                return;
            }

            MostrarTabela(fornecedores);
        }

        public void ExcluirFornecedor()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Fornecedor");

            Console.WriteLine("Excluindo um fornecedor já cadastrado...");

            Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Fornecedor excluído com sucesso!");

            Console.ResetColor();

            Console.ReadLine();
        }

        private void MostrarTabela(ArrayList fornecedores)
        {
            Console.WriteLine("{0, -10} | {1, -40} | {2, -20}", "Id", "Razão Social", "CNPJ", "Telefone", "Medicamento");

            Console.WriteLine("-------------------------------------------------------------------------");

            foreach (Fornecedor fornecedor in fornecedores)
            {
                Console.WriteLine("{0, -10} | {1, -40} | {2, -20}", fornecedor.id, fornecedor.razaoSocial, fornecedor.CNPJ, fornecedor.telefone, fornecedor.medicamento.id);
            }
        }
        private Fornecedor ObterFornecedor()
        {
            Console.Write("Digite o nome: ");
            string razaoSocial = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o endereço: ");
            string CNPJ = Console.ReadLine();

            Console.Write("Digite o id do Medicamento: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());
            Medicamento medicamento = repositorioMedicamento.SelecionarPorId(idMedicamento);


            Fornecedor fornecedor = new Fornecedor(razaoSocial, telefone, CNPJ, medicamento);

            return fornecedor;
        }
    }
}