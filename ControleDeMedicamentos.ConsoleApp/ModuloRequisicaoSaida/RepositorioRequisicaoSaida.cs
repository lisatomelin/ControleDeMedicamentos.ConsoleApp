using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloReposicao;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class RepositorioRequisicaoSaida : RepositorioBase
    {
        public RepositorioRequisicaoSaida(ArrayList listaRequisicaoSaida)
        {
            this.listaRegistros = listaRequisicaoSaida;
        }

        public override RequisicaoSaida SelecionarPorId(int id)
        {
            return (RequisicaoSaida)base.SelecionarPorId(id);
        }

    }
}

