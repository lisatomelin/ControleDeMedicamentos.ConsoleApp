using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class Fornecedor
    {
        public int id;
        public string razaoSocial;
        public string CNPJ;
        public string telefone;
        public string endereco;
        public Medicamento medicamento;

        public Fornecedor(string razaoSocial, string CNPJ, string telefone, Medicamento medicamento)
        {
            this.razaoSocial = razaoSocial;
            this.telefone = telefone;
            this.CNPJ = CNPJ;
            this.medicamento = medicamento;
        }
    }
}
