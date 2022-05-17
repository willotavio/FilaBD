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
    class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection conexao;
            conexao = new MySqlConnection("server=localhost;database=fila;uid=root;password=");
            try
            {
                conexao.Open();
                Console.WriteLine("Conexão estabelecida com sucesso!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Erro");
                Console.ReadKey();
                Environment.Exit(0);
            }

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

            if(conexao.State == ConnectionState.Open)
            {

            }
            else
            {
                conexao.Open();
            }


            //insert no bd

            Console.WriteLine("Digite o CPF");
            string cpf = Console.ReadLine();
            Console.WriteLine("Digite o nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o telefone");
            string telefone = Console.ReadLine();
            Console.WriteLine("Digite a idade");
            int idade = int.Parse(Console.ReadLine());
            
            string insertQuery = "insert into paciente values ('" + cpf + "','" + nome + "', '" + telefone + "'," + idade + ")";

            MySqlCommand insertCommand = new MySqlCommand(insertQuery, conexao);
            insertCommand.ExecuteNonQuery();
            Console.WriteLine("Dados inseridos com sucesso!");

            conexao.Close();










            /*insert no bd*/
            /* sql = "insert into paciente values (@cpf,@nome,@idade,@telefone)";
             cmd = new MySqlCommand(sql, conexao);
             Console.WriteLine("Digite o CPF:");
             cmd.Parameters.AddWithValue("@cpf", "456");
             cmd.Parameters.AddWithValue("@nome", "asd");
             cmd.Parameters.AddWithValue("@idade", "56");
             cmd.Parameters.AddWithValue("@telefone", "923");

             if (cmd.ExecuteNonQuery() > 0)
             {
                 Console.WriteLine("Cadastrado com sucesso");

                 conexao.Close();
                 Console.ReadKey();
             }
             */


            /*insert no bd*/
            /* sql = "insert into paciente values (@cpf,@nome,@idade,@telefone)";
             cmd = new MySqlCommand(sql, conexao);
             cmd.Parameters.AddWithValue("@cpf", "456");
             cmd.Parameters.AddWithValue("@nome", "asd");
             cmd.Parameters.AddWithValue("@idade", "56");
             cmd.Parameters.AddWithValue("@telefone", "923");

             if (cmd.ExecuteNonQuery() > 0)
             {
                 Console.WriteLine("Cadastrado com sucesso");

                 conexao.Close();
                 Console.ReadKey();
             }
             */
            /*delete*/
           /* sql = "delete from paciente where cpf='1'";
            if (cmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Deletado com sucesso");

                conexao.Close();
                Console.ReadKey();
            }
            */

        }
    }
}
