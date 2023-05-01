using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente
{
    public class RepositorioPaciente : RepositorioBase
    {

        public RepositorioPaciente(ArrayList listaPacientes)
        {
            this.listaRegistros = listaPacientes;
        }
        public override Paciente SelecionarPorId(int id)
        {
            return (Paciente)base.SelecionarPorId(id);
        }
    }
}
