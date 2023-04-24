using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class RepositorioFornecedor
    {
        private ArrayList listaFornecedores;
        private int contadorFornecedores = 0;

        public RepositorioFornecedor(ArrayList lista)
        {
            listaFornecedores = lista;
        }


        public void Inserir(Fornecedor fornecedor)
        {
            contadorFornecedores++;
            fornecedor.id = contadorFornecedores;
            listaFornecedores.Add(fornecedor);
        }
        public void Editar(int id, Fornecedor fornecedorAtualizado)
        {
            Fornecedor fornecedor = SelecionarPorId(id);

            fornecedor.razaoSocial = fornecedorAtualizado.razaoSocial;
            fornecedor.telefone = fornecedorAtualizado.telefone;
            fornecedor.CNPJ = fornecedorAtualizado.CNPJ;
            fornecedor.medicamento = fornecedorAtualizado.medicamento;
        }
        public void Excluir(int id)
        {
            Fornecedor fornecedor = SelecionarPorId(id);

            listaFornecedores.Remove(fornecedor);
        }
        public Fornecedor SelecionarPorId(int id)
        {
            Fornecedor fornecedorSelecionado = null;

            foreach (Fornecedor fr in listaFornecedores)
            {
                if (fr.id == id)
                {
                    fornecedorSelecionado = fr;
                    break;
                }
            }

            return fornecedorSelecionado;
        }
        public ArrayList SelecionarTodos()
        {
            return listaFornecedores;
        }

       
    }
}
