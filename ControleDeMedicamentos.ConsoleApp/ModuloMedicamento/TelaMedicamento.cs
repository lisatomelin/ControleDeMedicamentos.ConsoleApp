using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class TelaMedicamento : Tela
    {
        RepositorioFornecedor repositorioFornecedor;
        RepositorioMedicamento repositorioMedicamento;
        TelaFornecedor telaFornecedor = null;

        public TelaMedicamento(RepositorioMedicamento repositorioMedicamento, RepositorioFornecedor repositorioFornecedor)
        {
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioFornecedor = repositorioFornecedor;
            
            
        }
       

        public string ApresentarMenuMedicamento()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Medicamento \n");
            Console.WriteLine("Digite 1 para Inserir Medicamento");
            Console.WriteLine("Digite 2 para Editar Medicamento");
            Console.WriteLine("Digite 3 para Visualizar Medicamento");
            Console.WriteLine("Digite 4 para Visualizar Medicamentos com pouca quantidade: ");
            Console.WriteLine("Digite 5 para Visualizar Medicamentos em falta: ");
            Console.WriteLine("Digite 6 para Excluir Medicamento");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovoMedicamento()
        {
            MostrarCabecalho("Cadastro de Medicamento", "Inserindo um novo medicamento...");

            Medicamento medicamento = ObterMedicamento();

            repositorioMedicamento.Inserir(medicamento);

            MostrarMensagem("Medicamento inserido com sucesso!", ConsoleColor.Green);
        }

        public void EditarMedicamento()
        {
            MostrarCabecalho("Cadastro de Medicamento", "Inserindo um novo medicamento...");

            VisualizarMedicamento(false);

            Console.WriteLine();

            Console.Write("Digite o id do Medicamento: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Medicamento medicamentoAtualizado = ObterMedicamento();

            repositorioMedicamento.Editar(id, medicamentoAtualizado);

            MostrarMensagem("Medicamento editado com sucesso!", ConsoleColor.Green);
        }

        public void VisualizarMedicamento(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                MostrarCabecalho("Cadastro de Medicamento", "Visualizando Medicamentos já cadastrados...");

            ArrayList medicamentos = repositorioMedicamento.SelecionarTodos();

            if (medicamentos.Count == 0)
            {
                MostrarMensagem("Nenhum medicamento cadastrado", ConsoleColor.DarkYellow);
                return;
            }

            MostrarTabela(medicamentos);
        }
        public void VisualizarMedicamentosComPoucasQuantidades()
        {
            MostrarCabecalho("Cadastro de Medicamento", "Visualizando Medicamentos com pouca quantidade...");

            ArrayList medicamentos = repositorioMedicamento.SelecionarTodos();

            Console.Write("Quantidade mínima: ");
            int quantidadeMinima = int.Parse(Console.ReadLine());

            foreach (Medicamento medicamento in medicamentos)
            {
                if (medicamento.quantidade < quantidadeMinima)
                {
                    Console.WriteLine(medicamento.nome + " - " + medicamento.quantidade);
                }
            }
        }
        public void VisualizarMedicamentosEmFalta()
        {
            MostrarCabecalho("Cadastro de Medicamento", "Visualizando Medicamentos em falta...");

            ArrayList medicamentos = repositorioMedicamento.SelecionarTodos();
            int quantidade = 0;
            
            foreach (Medicamento medicamento in medicamentos)
            {
                if (medicamento.quantidade == 0)
                {
                    Console.WriteLine("O medicamento: " + medicamento.nome + " esta em falta " );
                }
            }
        }
        private void MostrarTabela(ArrayList medicamentos)
        {
            Console.WriteLine("{0, -10} | {1, -40} | {2, -20}", "Id", "Nome", "Quantidade", "Descrição", "Id do Fornecedor");

            Console.WriteLine("-------------------------------------------------------------------------");

            foreach (Medicamento medicamento in medicamentos)
            {
                Console.WriteLine("{0, -10} | {1, -40} | {2, -20}", medicamento.id,  medicamento.nome, medicamento.quantidade, medicamento.descricao, medicamento.fornecedor.id); 
                    
            }
        }

        public void ExcluirMedicamento()
        {

            Console.Clear();

            Console.WriteLine("Cadastro de Medicamento");

            Console.WriteLine("Excluindo um Medicamento já cadastrado...");

            Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Medicamento excluído com sucesso!");

            Console.ResetColor();

            Console.ReadLine();
        }
        private Medicamento ObterMedicamento()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a descrição do medicamento: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite quantidade do medicamento: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o id do Fornecedor: ");
            int idFornecedor = Convert.ToInt32(Console.ReadLine());
            Fornecedor fornecedor = repositorioFornecedor.SelecionarPorId(idFornecedor);

            Medicamento medicamento = new Medicamento(nome, descricao, quantidade, fornecedor);

            return medicamento;
        }




    }
}
