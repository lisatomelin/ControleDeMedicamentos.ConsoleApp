using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class Requisicao
    {
        public int id;
        public Fornecedor fornecedor;
        public Funcionario funcionario;
        public Medicamento medicamento;
        public Paciente paciente;


        public Requisicao(Fornecedor fornecedor, Funcionario funcionario, Medicamento medicamento, Paciente paciente)
        {
            this.funcionario = funcionario;
            this.fornecedor = fornecedor;
            this.medicamento = medicamento;
            this.paciente = paciente;
        }
    }
}
