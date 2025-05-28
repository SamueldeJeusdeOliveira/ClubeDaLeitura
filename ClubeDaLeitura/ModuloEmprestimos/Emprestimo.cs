using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloRevistas;

namespace ClubeDaLeitura.ModuloEmprestimos
{
    internal class Emprestimo
    {
        public Amigo AmigoE { get; set; }
        public Revista RevistaE { get; set; }
        public DateTime Data {  get; set; }
        public string Situacao {  get; set; }

        public void Validar() { }
        public void ObterDataDevolucao() { }
        public void RegistrarDevolucao() { }
    }
}
