﻿using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
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
            RepositorioRequisicaoSaida repositorioRequisicaoSaida = new RepositorioRequisicaoSaida(new ArrayList());
            RepositorioRequisicaoEntrada repositorioRequisicaoEntrada = new RepositorioRequisicaoEntrada(new ArrayList());
            RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor(new ArrayList());
            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario(new ArrayList());
            RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento(new ArrayList());
            RepositorioPaciente repositorioPaciente = new RepositorioPaciente(new ArrayList());

            TelaFornecedor telaFornecedor = new TelaFornecedor(repositorioFornecedor);
            TelaFuncionario telaFuncionario = new TelaFuncionario(repositorioFuncionario);
            TelaPaciente telaPaciente = new TelaPaciente(repositorioPaciente);
            TelaMedicamento telaMedicamento = new TelaMedicamento(repositorioMedicamento, telaFornecedor, repositorioFornecedor);
            TelaRequisicaoEntrada telaRequisicaoEntrada = new TelaRequisicaoEntrada(repositorioRequisicaoEntrada, repositorioFuncionario, repositorioMedicamento, telaFuncionario, telaMedicamento);
            TelaRequisicaoSaida telaRequisicaoSaida = new TelaRequisicaoSaida(repositorioRequisicaoSaida, repositorioFuncionario, repositorioMedicamento,
            repositorioPaciente, telaFuncionario, telaMedicamento, telaPaciente);


            TelaPrincipal principal = new TelaPrincipal();


            while (true)
            {
                string opcao = principal.ApresentarMenuPrincipal();

                if (opcao == "s")
                    break;

                if (opcao == "1")
                {
                    string subMenu = telaFornecedor.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaFornecedor.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaFornecedor.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaFornecedor.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaFornecedor.ExcluirRegistro();
                    }
                }
                else if (opcao == "2")
                {
                    string subMenu = telaFuncionario.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaFuncionario.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaFuncionario.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaFuncionario.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaFuncionario.ExcluirRegistro();
                    }
                }
                else if (opcao == "3")
                {
                    string subMenu = telaPaciente.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaPaciente.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaPaciente.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaPaciente.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaPaciente.ExcluirRegistro();
                    }
                }
                else if (opcao == "4")
                {
                    string subMenu = telaMedicamento.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaMedicamento.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaMedicamento.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaMedicamento.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaMedicamento.ExcluirRegistro();
                    }
                    else if (subMenu == "5")
                    {
                        telaMedicamento.VisualizarMedicamentosMaisRetirados();
                        Console.ReadLine();
                    }
                    else if (subMenu == "6")
                    {
                        telaMedicamento.VisualizarMedicamentosEmFalta();
                        Console.ReadLine();
                    }

                }
                else if (opcao == "5")
                {
                    string subMenu = telaRequisicaoEntrada.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaRequisicaoEntrada.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaRequisicaoEntrada.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaRequisicaoEntrada.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaRequisicaoEntrada.ExcluirRegistro();
                    }
                }
                else if (opcao == "6")
                {
                    string subMenu = telaRequisicaoSaida.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaRequisicaoSaida.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaRequisicaoSaida.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaRequisicaoSaida.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaRequisicaoSaida.ExcluirRegistro();
                    }
                }
            }
        }
    }
}