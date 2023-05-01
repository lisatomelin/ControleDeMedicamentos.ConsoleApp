using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloReposicao
{
    public class RepositorioRequisicaoEntrada : RepositorioBase
    {
        public RepositorioRequisicaoEntrada(ArrayList listaRequisicaoEntrada)
        {
            this.listaRegistros = listaRequisicaoEntrada;
        }

        public override RequisicaoEntrada SelecionarPorId(int id)
        {
            return (RequisicaoEntrada)base.SelecionarPorId(id);
        }
    }
}    
