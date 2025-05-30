using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloRevistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloAmigos
{
    class Amigo : EntidadeBase
    {
        public string Nome { get; set; }
        public string Responsavel { get; set; }
        public string Telefone { get; set; }
        public Revista revista { get; set; }
        public void ObterEmprestimos() 
        {
            
        }

        public Amigo(string nome, string responsavel, string telefone)
        {
            Nome = nome;
            Responsavel = responsavel;
            Telefone = telefone;
        }

        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            Amigo amigo = (Amigo)registroAtualizado;
            this.Nome = amigo. Nome;
            this.Telefone = amigo.Telefone;
            this.Responsavel = amigo.Responsavel;
        }

        public override string Validar()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(Nome))
                erros += "O nome é obrigatório!\n";

            else if (Nome.Length <= 3)
                erros += "O nome deve conter no mínimo 3 caractere!\n";

            if (string.IsNullOrWhiteSpace(Responsavel))
                erros += "O responsável é obrigatório!\n";
            else if (Responsavel.Length <= 3)
                erros += "O responsável deve conter no mínimo 3 caracteres!\n";
            if (string.IsNullOrWhiteSpace(Telefone))
                erros += "O telefone é obrigatório!\n";

            else if (Telefone.Length < 9)
                erros += "O telefone deve conter no mínimo 9 caracteres!\n";

            return erros;

        }
    }
}
