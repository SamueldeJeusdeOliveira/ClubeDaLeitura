using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.Compartilhado;

namespace ClubeDaLeitura.ModuloEmprestimos
{
    internal class RepositorioEmprestimo : RepositorioBase
    {
        public Emprestimo[] VetorEmprestimo { get; set; }
        public void Inserir() { }
        public void Editar() { }
        public void Excluir() { }
        public void SelecionarTodos() { }
        public void SelecionarPorId() { }
    }
}
