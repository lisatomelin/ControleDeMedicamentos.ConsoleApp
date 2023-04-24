using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente
{
    public class RepositorioPaciente
    {
        private ArrayList listaPacientes;
        private int contadorPacientes = 0;

        public RepositorioPaciente(ArrayList lista)
        {
            listaPacientes = lista;
        }

       
        public void Inserir(Paciente paciente)
        {
            contadorPacientes++;
            paciente.id = contadorPacientes;
            listaPacientes.Add(paciente);
        }
        public void Editar(int id, Paciente pacienteAtualizado)
        {
            Paciente paciente = SelecionarPorId(id);

            paciente.nome = pacienteAtualizado.nome;
            paciente.telefone = pacienteAtualizado.telefone;
            paciente.endereco = pacienteAtualizado.endereco;
        }
        public void Excluir(int id)
        {
            Paciente paciente = SelecionarPorId(id);

            listaPacientes.Remove(paciente);
        }
        public Paciente SelecionarPorId(int id)
        {
            Paciente pacienteSelecionado = null;

            foreach (Paciente p in listaPacientes)
            {
                if (p.id == id)
                {
                    pacienteSelecionado = p;
                    break;
                }
            }

            return pacienteSelecionado;
        }
        public ArrayList SelecionarTodos()
        {
            return listaPacientes;
        }
    }
}
