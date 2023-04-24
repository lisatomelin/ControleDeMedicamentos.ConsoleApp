using ControleDeMedicamentos.ConsoleApp.ModuloReposicao;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class RepositorioRequisicao
    {
        private ArrayList listaRequisicoes;
        private int contadorRequisicao = 0;

        public RepositorioRequisicao(ArrayList lista)
        {
            listaRequisicoes = lista;
        }


        public void Inserir(Requisicao requisicao)
        {
            contadorRequisicao++;
            requisicao.id = contadorRequisicao;
            listaRequisicoes.Add(requisicao);
        }
        public void Editar(int id, Requisicao requisicaoAtualizada)
        {
            Requisicao requisicao = SelecionarPorId(id);

            requisicao.medicamento = requisicaoAtualizada.medicamento;
            requisicao.fornecedor = requisicaoAtualizada.fornecedor;
            requisicao.funcionario = requisicaoAtualizada.funcionario;
        }
        public void Excluir(int id)
        {
            Requisicao requisicao = SelecionarPorId(id);

            listaRequisicoes.Remove(requisicao);
        }
        public Requisicao SelecionarPorId(int id)
        {
            Requisicao requisicaoSelecionada = null;

            foreach (Requisicao re in listaRequisicoes)
            {
                if (re.id == id)
                {
                    requisicaoSelecionada = re;
                    break;
                }
            }

            return requisicaoSelecionada;
        }
        public ArrayList SelecionarTodos()
        {
            return listaRequisicoes;
        }
    }
}

