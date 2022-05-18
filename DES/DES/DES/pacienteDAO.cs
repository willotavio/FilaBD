using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;

namespace DES
{
    class pacienteDAO : Pessoa
    {

        public void paciente()
        {


            //conexao
            MySqlConnection conexao;
            conexao = new MySqlConnection("server=localhost;database=fila;uid=root;password=");
            try
            {
                conexao.Open();
                Console.WriteLine("Conexão estabelecida com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Erro");
                Console.ReadKey();
                Environment.Exit(0);
            }

            string m = "1";
            while (m == "1")
            {
                string escolha;
                Console.WriteLine("MENU\n 1 = Listar\n 2 = Adicionar\n q = Sair");
                escolha = Console.ReadLine();
            

            //inicio do read
            if (escolha == "1")
            {
                    conexao.Close();
                    conexao.Open();

                String sql = "select * from paciente";
                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine("CPF:{0} Nome:{1} Idade:{2} Telefone:{3}", rdr["cpf"], rdr["nome"], rdr["idade"], rdr["telefone"]);
                    Console.ReadKey();
                }
                conexao.Close();
                Console.ReadKey();

                
            }//fim do read

            else if (escolha == "2")
            {
                //insert no bd
                if (conexao.State == ConnectionState.Open)
                   {

                   }
                   else
                   {
                   conexao.Open();
                   }
                Console.WriteLine("Digite o CPF");
                cpf = Console.ReadLine();
                Console.WriteLine("Digite o nome");
                nome = Console.ReadLine();
                Console.WriteLine("Digite o telefone");
                telefone = Console.ReadLine();
                Console.WriteLine("Digite a idade");
                idade = int.Parse(Console.ReadLine());

                string insertQuery = "insert into paciente values ('" + cpf + "','" + nome + "', '" + telefone + "'," + idade + ")";

                MySqlCommand insertCommand = new MySqlCommand(insertQuery, conexao);
                insertCommand.ExecuteNonQuery();
                Console.WriteLine("Dados inseridos com sucesso!");

                conexao.Close();
            }
                //fim do insert

                //update
                else if (escolha == "3") {
                    conexao.Close();
                    conexao.Open();
                Console.WriteLine("Qual o CPF de quem deve ser alterado?");
                cpf = Console.ReadLine();
                    Console.WriteLine("Insira as novas informações:");
                    Console.WriteLine("Nome:");
                    nome = Console.ReadLine();
                    Console.WriteLine("Telefone:");
                    telefone = Console.ReadLine();
                    Console.WriteLine("Idade:");
                    idade = int.Parse(Console.ReadLine());
                    
                    string sql = "UPDATE paciente SET nome = @nome, telefone = @telefone, idade = @idade Where cpf = @cpf ";
                    MySqlCommand cmd = new MySqlCommand(sql, conexao);
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@telefone", telefone);
                    cmd.Parameters.AddWithValue("@idade", idade);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Dados alterados com sucesso!");

                    conexao.Close();
}
                //delete

                //sair
                else if (escolha == "q")
                {
                    Environment.Exit(0);
                }
            }
            }
        }
}
