﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.Compartilhado
{
    public abstract class RepositorioBase
    {
        protected ArrayList listaRegistros;
        protected int contadorRegistros = 0;

        public virtual void Inserir(EntidadeBase registro)
        {
            contadorRegistros++;

            registro.id = contadorRegistros;

            listaRegistros.Add(registro);
        }

        public virtual void Editar(int id, EntidadeBase/*Entidade Mãe*/ registroAtualizado)
        {
            EntidadeBase registroSelecionado = SelecionarPorId(id);

            registroSelecionado.AtualizarInformacoes(registroAtualizado);
        }

        public virtual void Excluir(int id)
        {
            EntidadeBase registroSelecionado = SelecionarPorId(id);

            listaRegistros.Remove(registroSelecionado);
        }

        public virtual EntidadeBase SelecionarPorId(int id)
        {
            EntidadeBase registroSelecionado = null;

            foreach (EntidadeBase registro in listaRegistros)
            {
                if (registro.id == id)
                {
                    registroSelecionado = registro;
                    break;
                }
            }

            return registroSelecionado;
        }

        public virtual ArrayList SelecionarTodos()
        {
            return listaRegistros;
        }


    }
}
