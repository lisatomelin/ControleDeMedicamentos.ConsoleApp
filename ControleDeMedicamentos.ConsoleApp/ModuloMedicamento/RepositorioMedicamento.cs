using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class RepositorioMedicamento
    {
        private ArrayList listaMedicamentos;
        private int contadorMedicamentos = 0;

        public RepositorioMedicamento(ArrayList lista)
        {
            listaMedicamentos = lista;
        }


        public void Inserir(Medicamento medicamento)
        {
            contadorMedicamentos++;
            medicamento.id = contadorMedicamentos;
            listaMedicamentos.Add(medicamento);
        }
        public void Editar(int id, Medicamento medicamentoAtualizado)
        {
            Medicamento medicamento = SelecionarPorId(id);

            medicamento.nome = medicamentoAtualizado.nome;
            medicamento.descricao = medicamentoAtualizado.descricao;
            medicamento.fornecedor = medicamentoAtualizado.fornecedor;
             
        }
        public void Excluir(int id)
        {
            Medicamento medicamento = SelecionarPorId(id);

            listaMedicamentos.Remove(medicamento);
        }
        public Medicamento SelecionarPorId(int id)
        {
            Medicamento medicamentoSelecionado = null;

            foreach (Medicamento m in listaMedicamentos)
            {
                if (m.id == id)
                {
                    medicamentoSelecionado = m;
                    break;
                }
            }

            return medicamentoSelecionado;
        }
        public ArrayList SelecionarTodos()
        {
            return listaMedicamentos;
        }
    }
}

