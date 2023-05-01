using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public partial class RepositorioMedicamento : RepositorioBase
    {
        public RepositorioMedicamento(ArrayList listaMedicamentos)
        {
            this.listaRegistros = listaMedicamentos;
        }

        public override Medicamento SelecionarPorId(int id)
        {
            return (Medicamento)base.SelecionarPorId(id);
        }
        public ArrayList SelecionarMedicamentosMaisRetirados()
        {
            Medicamento[] medicamentos = new Medicamento[listaRegistros.Count];

            int posicao = 0;
            foreach (Medicamento m in listaRegistros)
            {
                medicamentos[posicao++] = m;

            }

            Array.Sort(medicamentos, new ComparadorMedicamentosRetirados());

            return new ArrayList(medicamentos);
        }
        public ArrayList SelecionarMedicamentosEmFalta()
        {
            ArrayList listaMedicamentosEmFalta = new ArrayList();

            foreach (Medicamento m in listaRegistros)
            {
                if (m.quantidade == 0)
                    listaMedicamentosEmFalta.Add(m);


            }

            return listaMedicamentosEmFalta;
        }
    }
}

