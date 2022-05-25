using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES
{
    class Pessoa
    {
        public string cpf;
        public int posicao;
        public string nome;
        public string telefone;
        public int idade;
        public int prioridade;

        public void cadPessoa()
        {
            PacienteDAO pac = new PacienteDAO();
            pac.Paciente();
        }
    }
}
