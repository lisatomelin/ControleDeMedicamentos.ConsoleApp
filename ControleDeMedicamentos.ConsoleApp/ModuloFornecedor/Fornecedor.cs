﻿using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class Fornecedor : EntidadeBase
    {
        public string nome;
        public string telefone;
        public string email;
        public string cidade;
        public string estado;

        public Fornecedor(string nome, string telefone, string email, string cidade, string estado)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.email = email;
            this.cidade = cidade;
            this.estado = estado;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Fornecedor fornecedorAtualizado = (Fornecedor)registroAtualizado;

            this.nome = fornecedorAtualizado.nome;
            this.telefone = fornecedorAtualizado.telefone;
            this.email = fornecedorAtualizado.email;
            this.cidade = fornecedorAtualizado.cidade;
            this.estado = fornecedorAtualizado.estado;

        }
    }
}
