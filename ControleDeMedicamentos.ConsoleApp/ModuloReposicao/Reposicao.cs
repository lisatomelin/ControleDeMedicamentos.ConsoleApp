using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloReposicao
{
    public class Reposicao
    {
        public int id;
        public Fornecedor fornecedor;
        public Funcionario funcionario;
        public Medicamento medicamento;

       
        public Reposicao(Fornecedor fornecedor,Funcionario funcionario, Medicamento medicamento)
        {            
            this.funcionario = funcionario;
            this.fornecedor = fornecedor;
            this.medicamento = medicamento;
        }
    }


}

