using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario
{
    public class RepositorioFuncionario
    {
        private ArrayList listaFuncionarios;
        private int contadorFuncionarios = 0;

        public RepositorioFuncionario(ArrayList lista)
        {
            listaFuncionarios = lista;
        }

        public void Inserir(Funcionario funcionario)
        {
            contadorFuncionarios++;
            funcionario.id = contadorFuncionarios;
            listaFuncionarios.Add(funcionario);
        }
        public void Editar(int id, Funcionario funcionarioAtualizado)
        {
            Funcionario funcionario = SelecionarPorId(id);

            funcionario.nome = funcionarioAtualizado.nome;
            funcionario.telefone = funcionarioAtualizado.telefone;
            funcionario.endereco = funcionarioAtualizado.endereco;
        }

        public void Excluir(int id)
        {
            Funcionario funcionario = SelecionarPorId(id);

            listaFuncionarios.Remove(funcionario);
        }

        public Funcionario SelecionarPorId(int id)
        {
            Funcionario funcionarioSelecionado = null;

            foreach (Funcionario f in listaFuncionarios)
            {
                if (f.id == id)
                {
                    funcionarioSelecionado = f;
                    break;
                }
            }
            return funcionarioSelecionado;
        }

        public ArrayList SelecionarTodos()
        {
            return listaFuncionarios;
        }
    }
}
