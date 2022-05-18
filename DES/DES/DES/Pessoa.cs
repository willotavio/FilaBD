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
        public string nome;
        public string telefone;
        public int idade;

        public void cadPessoa()
        {
            pacienteDAO pac = new pacienteDAO();
            pac.paciente();
        }
    }
}
