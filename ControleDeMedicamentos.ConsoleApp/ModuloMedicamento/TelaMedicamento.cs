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
    public class TelaMedicamento : TelaBase
    {
        private TelaFornecedor telaFornecedor;
        private RepositorioFornecedor repositorioFornecedor;
        private RepositorioMedicamento repositorioMedicamento;


        public TelaMedicamento(RepositorioMedicamento repositorioMedicamento, TelaFornecedor telaFornecedor, RepositorioFornecedor repositorioFornecedor)
        {
            nomeEntidade = "Medicamento";
            sufixo = "s";
            this.repositorioBase = repositorioMedicamento;
            this.repositorioMedicamento = repositorioMedicamento;
            this.telaFornecedor = telaFornecedor;
            this.repositorioFornecedor = repositorioFornecedor;
        }

        public override string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine($"Cadastro de {nomeEntidade}{sufixo} \n");

            Console.WriteLine($"Digite 1 para Inserir {nomeEntidade}");
            Console.WriteLine($"Digite 2 para Visualizar {nomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 3 para Editar {nomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 4 para Excluir {nomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 5 para Visualizar {nomeEntidade}{sufixo} mais Retirados");
            Console.WriteLine($"Digite 6 para Visualizar {nomeEntidade}{sufixo} em falta");
            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -20} | {5, - 20} | {6, - 20} | {7, - 20}", "Id", "Nome", "Descrição", "Lote", "Data de Validade",
                "Fornecedor", "Quantidade", "Quantidade Retiradas");

            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------");

            foreach (Medicamento medicamento in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -20} | {5, - 20} | {6, - 20} | {7, - 20}\"", medicamento.id, medicamento.nome, medicamento.descricao, medicamento.lote, medicamento.datavalidade, medicamento.fornecedor,
                    medicamento.fornecedor.nome, medicamento.quantidade, medicamento.quantidadeRequisicoesSaida);

            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            telaFornecedor.VisualizarRegistros(false);

            Console.WriteLine("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite a Descrição: ");
            string descricao = Console.ReadLine();

            Console.WriteLine("Digite o lote: ");
            string lote = Console.ReadLine();

            Console.WriteLine("Digite a Data de Validade: ");
            DateTime datavalidade = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite o Id do Fornecedor ");
            int idFornecedor = Convert.ToInt32(Console.ReadLine());

            Fornecedor fornecedor = repositorioFornecedor.SelecionarPorId(idFornecedor);


            return new Medicamento(nome, descricao, lote, datavalidade, fornecedor);
        }



        public void VisualizarMedicamentosMaisRetirados()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Visualizando medicamentos mais retirados...");

            ArrayList medicamentosMaisRetirados = repositorioMedicamento.SelecionarMedicamentosMaisRetirados();

            if (medicamentosMaisRetirados.Count == 0)
            {
                MostrarMensagem("Nenhum registro cadastrado", ConsoleColor.DarkYellow);
                return;
            }

            MostrarTabela(medicamentosMaisRetirados);
        }
        public void VisualizarMedicamentosEmFalta()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Visualizando medicamentos em falta...");

            ArrayList medicamentosEmFalta = repositorioMedicamento.SelecionarMedicamentosEmFalta();

            if (medicamentosEmFalta.Count == 0)
            {
                MostrarMensagem("Nenhum registro cadastrado", ConsoleColor.DarkYellow);
                return;
            }

            MostrarTabela(medicamentosEmFalta);
        }
    }
}
