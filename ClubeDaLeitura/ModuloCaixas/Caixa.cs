using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloRevistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloCaixas
{
    internal class Caixa : EntidadeBase
    {
        public string Etiqueta { get; set; }
        public string Cor { get; set; }
        public int DiasEmprestimo { get; set; }
        public List<Revista> Revistas { get; set; } = new List<Revista>();

        public Caixa(string etiqueta, string cor, int diasEmprestimo)
        {
            Etiqueta = etiqueta;
            Cor = cor;
            DiasEmprestimo = diasEmprestimo;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(Etiqueta))
                resultadoValidacao += "A etiqueta da caixa é obrigatória.\n";

            if (string.IsNullOrEmpty(Cor))
                resultadoValidacao += "A cor da caixa é obrigatória.\n";

            if (DiasEmprestimo <= 0)
                resultadoValidacao += "Os dias de empréstimo devem ser maiores que zero.\n";

            return resultadoValidacao;
        }

        public void AdicionarRevista(Revista revista)
        {
            Revistas.Add(revista);
        }

        public void RemoverRevista(Revista revista)
        {
            Revistas.Remove(revista);
        }

        public override string ToString()
        {
            return $"ID {id} - Etiqueta: {Etiqueta}, Cor: {Cor}, Dias empréstimo: {DiasEmprestimo}, Revistas: {Revistas.Count}";
        }
    }
}
