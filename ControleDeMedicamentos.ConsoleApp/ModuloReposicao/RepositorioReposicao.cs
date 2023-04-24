using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloReposicao
{
    public class RepositorioReposicao
    {
        private ArrayList listaReposicao;
        private int contadorReposicao = 0;

        public RepositorioReposicao(ArrayList lista)
        {
            listaReposicao = lista;
        }


        public void Inserir(Reposicao reposicao)
        {
            contadorReposicao++;
            reposicao.id = contadorReposicao;
            listaReposicao.Add(reposicao);
        }
        public void Editar(int id, Reposicao reposicaoAtualizada)
        {
            Reposicao reposicao = SelecionarPorId(id);

            reposicao.medicamento = reposicaoAtualizada.medicamento;
            reposicao.fornecedor = reposicaoAtualizada.fornecedor;
            reposicao.funcionario = reposicaoAtualizada.funcionario;
        }
        public void Excluir(int id)
        {
            Reposicao reposicao = SelecionarPorId(id);

            listaReposicao.Remove(reposicao);
        }
        public Reposicao SelecionarPorId(int id)
        {
            Reposicao reposicaoSelecionada = null;

            foreach (Reposicao r in listaReposicao)
            {
                if (r.id == id)
                {
                    reposicaoSelecionada = r;
                    break;
                }
            }

            return reposicaoSelecionada;
        }
        public ArrayList SelecionarTodos()
        {
            return listaReposicao;
        }
    }
}
