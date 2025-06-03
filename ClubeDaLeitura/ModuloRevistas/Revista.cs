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

        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            Revista revista = (Revista)registroAtualizado;
            this.Titulo = Titulo;
            this.NumEdicaoDoAnoDePublicacao = NumEdicaoDoAnoDePublicacao;
            this.StatusDeEmprestimoECaixa = StatusDeEmprestimoECaixa;
        }
        public Revista(string titulo, int numEdicaoDoAnoDePublicacao, string statusDeEmprestimoECaixa)
        {
            Titulo = titulo;
            NumEdicaoDoAnoDePublicacao = numEdicaoDoAnoDePublicacao;
            StatusDeEmprestimoECaixa = statusDeEmprestimoECaixa;
        }

        public override string Validar()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(Titulo))
                erros += "O Titulo é obrigatório!\n";

            else if (Titulo.Length < 2 && Titulo.Length > 100)
                erros += "O nome deve conter mais que 1 caractere e no máximo 100!\n";

            if (string.IsNullOrWhiteSpace(StatusDeEmprestimoECaixa))
                erros += "O Número da edição é obrigatório!\n";

            return erros;
        }
        public void Emprestar() { }
        public void Devolver() { }
        public void Reservar() { }

        
    }
}
