using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloReposicao;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicao;
using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor(new ArrayList());
            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario(new ArrayList());
            RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento(new ArrayList());
            RepositorioPaciente repositorioPaciente = new RepositorioPaciente(new ArrayList());
            RepositorioRequisicao repositorioRequisicao = new RepositorioRequisicao(new ArrayList());
            RepositorioReposicao repositorioReposicao = new RepositorioReposicao(new ArrayList());

            TelaFornecedor telaFornecedor = new TelaFornecedor(repositorioFornecedor,repositorioMedicamento);
            TelaPaciente telaPaciente = new TelaPaciente(repositorioPaciente);
            TelaMedicamento telaMedicamento = new TelaMedicamento(repositorioMedicamento, repositorioFornecedor);
            TelaFuncionario telaFuncionario = new TelaFuncionario(repositorioFuncionario);
            TelaRequisicao telaRequisicao = new TelaRequisicao( repositorioFornecedor, repositorioMedicamento, repositorioFuncionario,repositorioPaciente, repositorioRequisicao);
            TelaReposicao telaReposicao = new TelaReposicao(repositorioFornecedor, repositorioMedicamento, repositorioFuncionario, repositorioReposicao);

           

            while (true)
            {
                TelaPrincipal telaPrincipal = new TelaPrincipal();

                string opcao = telaPrincipal.ApresentarMenuPrincipal();

                if (opcao == "s")
                    break;

                if (opcao == "1")
                {
                    string opcaoPaciente = telaPaciente.ApresentarMenuPaciente();

                    if (opcaoPaciente == "1")
                    {
                        telaPaciente.InserirNovoPaciente();
                    }
                    else if (opcaoPaciente == "2")
                    {
                        telaPaciente.VisualizarPaciente(true);
                        Console.ReadLine();
                    }
                    else if (opcaoPaciente == "3")
                    {
                        telaPaciente.EditarPaciente();
                    }
                    else if (opcaoPaciente == "4")
                    {
                        telaPaciente.ExcluirPaciente();
                    }

                    continue;
                }
                else if (opcao == "2")
                {
                    string opcaoMedicamento = telaMedicamento.ApresentarMenuMedicamento();

                    if (opcaoMedicamento == "1")
                    {
                        telaMedicamento.InserirNovoMedicamento();
                    }

                    else if (opcaoMedicamento == "2")
                    {
                        telaMedicamento.EditarMedicamento();
                    }
                    else if (opcaoMedicamento == "3")
                    {
                        telaMedicamento.VisualizarMedicamento(true);
                        Console.ReadLine();
                    }
                    else if (opcaoMedicamento == "4")
                    {
                        telaMedicamento.VisualizarMedicamentosComPoucasQuantidades();
                        Console.ReadLine();
                    }
                    else if (opcaoMedicamento == "5")
                    {
                        telaMedicamento.VisualizarMedicamentosEmFalta();
                        Console.ReadLine();
                    }
                    else if (opcaoMedicamento == "6")
                    {
                        telaMedicamento.ExcluirMedicamento();
                    }

                    continue;

                }
                else if (opcao == "3")
                {
                    string opcaoFornecedor = telaFornecedor.ApresentarMenuFornecedor();

                    if (opcaoFornecedor == "1")
                    {
                        telaFornecedor.InserirNovoFornecedor();
                    }

                    else if (opcaoFornecedor == "2")
                    {
                        telaFornecedor.EditarFornecedor();
                    }
                    else if (opcaoFornecedor == "3")
                    {
                        telaFornecedor.VisualizarFornecedor(true);
                        Console.ReadLine();
                    }
                    else if (opcaoFornecedor == "4")
                    {
                        telaFornecedor.ExcluirFornecedor();
                    }

                    continue;
                }
                else if (opcao == "4")
                {
                    string opcaoFuncionario = telaFuncionario.ApresentarMenuFuncionario();

                    if (opcaoFuncionario == "1")
                    {
                        telaFuncionario.InserirNovoFuncionario();
                    }

                    else if (opcaoFuncionario == "2")
                    {
                        telaFuncionario.EditarFuncionario();
                    }
                    else if (opcaoFuncionario == "3")
                    {
                        telaFuncionario.VisualizarFuncionario(true);
                        Console.ReadLine();
                    }
                    else if (opcaoFuncionario == "4")
                    {
                        telaFuncionario.ExcluirFuncionario();
                    }

                    continue;

                }
                else if (opcao == "5")
                {
                    string opcaoRequisicao = telaRequisicao.ApresentarMenuRequisicao();

                    if (opcaoRequisicao == "1")
                    {
                        telaRequisicao.InserirNovaRequisicao();
                    }

                    else if (opcaoRequisicao == "2")
                    {
                        telaRequisicao.EditarRequisicao();
                    }
                    else if (opcaoRequisicao == "3")
                    {
                        telaRequisicao.VisualizarRequisicao(true);
                        Console.ReadLine();
                    }
                    else if (opcaoRequisicao == "4")
                    {
                        telaRequisicao.ExcluirRequisicao();
                    }

                    continue;
                }
                else if (opcao == "6")
                {
                    string opcaoReposicao = telaReposicao.ApresentarMenuReposicao();

                    if (opcaoReposicao == "1")
                    {
                        telaReposicao.InserirNovaReposicao();
                    }

                    else if (opcaoReposicao == "2")
                    {
                        telaReposicao.EditarReposicao();
                    }
                    else if (opcaoReposicao == "3")
                    {
                        telaReposicao.VisualizarReposicao(true);
                        Console.ReadLine();
                    }
                    else if (opcaoReposicao == "4")
                    {
                        telaReposicao.ExcluirReposicao();
                    }

                    continue;
                }
            }
        }
    }
}