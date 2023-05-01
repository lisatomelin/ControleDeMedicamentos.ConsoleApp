using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario
{
    public class RepositorioFuncionario : RepositorioBase
    {
        public RepositorioFuncionario(ArrayList listaFuncionario)
        {
            this.listaRegistros = listaFuncionario;

        }
        public override Funcionario SelecionarPorId(int id)
        {
            return (Funcionario)base.SelecionarPorId(id);
        }
    }
}
