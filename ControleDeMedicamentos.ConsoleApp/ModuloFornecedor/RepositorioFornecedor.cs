using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class RepositorioFornecedor : RepositorioBase
    {
        public RepositorioFornecedor(ArrayList listaFornecedor)
        {
            this.listaRegistros = listaFornecedor;
        }

        public override Fornecedor SelecionarPorId(int id)
        {
            return (Fornecedor)base.SelecionarPorId(id);
        }
    }
}
