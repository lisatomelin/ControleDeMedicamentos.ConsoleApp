using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public partial class RepositorioMedicamento
    {
        public class ComparadorMedicamentosRetirados : IComparer
        {
            public int Compare(object x, object y)
            {
                Medicamento mX = (Medicamento)x;
                Medicamento mY = (Medicamento)y;

                if (mX.quantidadeRequisicoesSaida < mY.quantidadeRequisicoesSaida)
                    return 1;

                else if (mX.quantidadeRequisicoesSaida > mY.quantidadeRequisicoesSaida)
                    return -1;

                else
                    return 0;
            }
        }
    }
}

