using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.Compartilhado;

namespace ClubeDaLeitura.ModuloRevistas
{
    internal class Revista : EntidadeBase
    {
        public string Titulo { get; set; }
        public int NumEdicaoDoAnoDePublicacao { get; set; }
        public string StatusDeEmprestimoECaixa { get; set; }
        public override string Validar()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(Titulo))
                erros += "O nome é obrigatório!\n";

            else if (Titulo.Length < 2)
                erros += "O nome deve conter mais que 1 caractere!\n";

            if (string.IsNullOrWhiteSpace(StatusDeEmprestimoECaixa))
                erros += "O telefone é obrigatório!\n";

            else if (NumEdicaoDoAnoDePublicacao.Length < 9)
                erros += "O telefone deve conter no mínimo 9 caracteres!\n";

            return erros;
        }
        public void Emprestar() { }
        public void Devolver() { }
        public void Reservar() { }

        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            throw new NotImplementedException();
        }
    }
}
