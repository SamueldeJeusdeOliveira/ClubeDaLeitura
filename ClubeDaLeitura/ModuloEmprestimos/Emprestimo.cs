using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloRevistas;

namespace ClubeDaLeitura.ModuloEmprestimos
{
    internal class Emprestimo : EntidadeBase
    {
        public Amigo AmigoE { get; set; }
        public Revista RevistaE { get; set; }
        public DateTime Data {  get; set; }
        public string Situacao {  get; set; }

        public void ObterDataDevolucao() { }
        public void RegistrarDevolucao() { }

        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            throw new NotImplementedException();
        }

        public override string Validar()
        {
            throw new NotImplementedException();
        }
    }
}
