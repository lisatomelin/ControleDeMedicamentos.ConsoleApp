using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente
{
    public class Paciente : EntidadeBase
    {
        public string nome;
        public string cartaoSUS;

        public Paciente(string nome, string cartaoSUS)
        {
            this.nome = nome;
            this.cartaoSUS = cartaoSUS;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Paciente pacienteAtualizado = (Paciente)registroAtualizado;

            this.nome = pacienteAtualizado.nome;
            this.cartaoSUS = pacienteAtualizado.cartaoSUS;
        }
    }
}
