using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class Medicamento
    {
        public int id;
        public string nome;
        public string descricao;
        public int quantidade;
        public Fornecedor fornecedor;

        public Medicamento(string nome, string descricao, int quantidade, Fornecedor fornecedor)
        {
            this.nome = nome;
            this.descricao = descricao;
            this.quantidade = quantidade;
            this.fornecedor = fornecedor;
            
        }
    }
}
