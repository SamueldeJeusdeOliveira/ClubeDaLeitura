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

        public Amigo(string nome, string responsavel, string telefone)
        {
            Nome = nome;
            Responsavel = responsavel;
            Telefone = telefone;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(Nome))
                resultadoValidacao += "O nome do amigo é obrigatório.\n";

            if (string.IsNullOrEmpty(Responsavel))
                resultadoValidacao += "O nome do responsável é obrigatório.\n";

            if (string.IsNullOrEmpty(Telefone))
                resultadoValidacao += "O telefone é obrigatório.\n";

            return resultadoValidacao;
        }

        public override string ToString()
        {
            return $"ID {id} - Nome: {Nome}, Responsável: {Responsavel}, Telefone: {Telefone}";
        }
    }
}
