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
    class PacienteDAO : Pessoa
    {
        private MySqlConnection conexao; 

        public void Conexao()
        {
            //conexao
            conexao = new MySqlConnection("server=localhost;port=3308;database=fila;uid=root;password=;sslmode=none");
        }

        public void IniciarCon()
        {
            try
            {
                conexao.Open();
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" Conexão estabelecida com sucesso!");
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(ex.Message);
                Console.WriteLine("\nErro\n\nAperte qualquer tecla para fechar o programa");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public void Cons()
        {
            if (conexao.State == ConnectionState.Open)
            {

            }
            else
            {
                try
                {
                    conexao.Open();
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Erro");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }

            String sql = "select * from paciente order by posicao";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    Console.WriteLine("\nPOSIÇÃO:{0} \nCPF:{1} \nNome:{2} \nTelefone:{4} \nIdade:{3} \nPrioridade:{5}\n", rdr["posicao"], rdr["cpf"], rdr["nome"], rdr["idade"], rdr["telefone"], rdr["prioridade"]);
                    Console.ReadKey();
                }
                Console.Clear();
            }
            else
            {
                Console.WriteLine("A fila está vazia!");
                Console.ReadKey();
                Console.Clear();
            }
            conexao.Close();
        }
        public void Add() {
            if (conexao.State == ConnectionState.Open)
            {

            }
            else
            {
                try
                {
                    conexao.Open();
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Erro");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }

            Console.WriteLine("Digite a posição");
            posicao = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o CPF");
            cpf = Console.ReadLine();
            Console.WriteLine("Digite o nome");
            nome = Console.ReadLine();
            Console.WriteLine("Digite o telefone");
            telefone = Console.ReadLine();
            Console.WriteLine("Digite a idade");
            idade = int.Parse(Console.ReadLine());
            Console.WriteLine("O paciente é preferencial?");
            prioridade = int.Parse(Console.ReadLine());

            string sql = "insert into paciente (posicao, cpf, nome, telefone, idade, prioridade) values (@posicao, @cpf, @nome, @telefone, @idade, @prioridade)";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@posicao", posicao);
            cmd.Parameters.AddWithValue("@cpf", cpf);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@telefone", telefone);
            cmd.Parameters.AddWithValue("@idade", idade);
            cmd.Parameters.AddWithValue("@prioridade", prioridade);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Dados inseridos com sucesso!");

            Console.ReadKey();
            Console.Clear();
            conexao.Close();
        }

        public void Alt()
        {

            if (conexao.State == ConnectionState.Open)
            {

            }
            else
            {
                try
                {
                    conexao.Open();
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Erro");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }

            string sql = "select * from paciente order by posicao";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine("\nPOSIÇÃO:{0} \nCPF:{1} \nNome:{2} \nTelefone:{4} \nIdade:{3} \nPrioridade:{5}\n", rdr["posicao"], rdr["cpf"], rdr["nome"], rdr["idade"], rdr["telefone"], rdr["prioridade"]);
                Console.ReadKey();
            }

            Console.WriteLine("Qual a posição de quem deve ser alterado?");
            posicao = int.Parse(Console.ReadLine());
            Console.WriteLine("Insira as novas informações:");
            Console.WriteLine("CPF");
            cpf = Console.ReadLine();
            Console.WriteLine("Nome:");
            nome = Console.ReadLine();
            Console.WriteLine("Telefone:");
            telefone = Console.ReadLine();
            Console.WriteLine("Idade:");
            idade = int.Parse(Console.ReadLine());
            Console.WriteLine("O paciente é preferencial?");
            prioridade = int.Parse(Console.ReadLine());

            conexao.Close();
            conexao.Open();

            sql = "UPDATE paciente SET cpf= @cpf, nome = @nome, telefone = @telefone, idade = @idade, prioridade = @prioridade where posicao = @posicao";
            cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@posicao", posicao);
            cmd.Parameters.AddWithValue("@cpf", cpf);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@telefone", telefone);
            cmd.Parameters.AddWithValue("@idade", idade);
            cmd.Parameters.AddWithValue("@prioridade", prioridade);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Dados alterados com sucesso!");

            Console.ReadKey();
            Console.Clear();
            conexao.Close();

        }

        public void Del()
        {

            if (conexao.State == ConnectionState.Open)
            {

            }
            else
            {
                try
                {
                    conexao.Open();
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Erro");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }

            string sql = "select * from paciente order by posicao";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine("\nPOSIÇÃO:{0} \nCPF:{1} \nNome:{2} \nTelefone:{4} \nIdade:{3} \nPrioridade:{5}\n", rdr["posicao"], rdr["cpf"], rdr["nome"], rdr["idade"], rdr["telefone"], rdr["prioridade"]);
                Console.ReadKey();
            }

            Console.WriteLine("\nQual a posição de quem deve ser deletado?");
            posicao = int.Parse(Console.ReadLine());


            conexao.Close();
            conexao.Open();
            sql = "delete from paciente where posicao = @posicao ";
            cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@posicao", posicao);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Dados deletados com sucesso");

            Console.ReadKey();
            Console.Clear();
            conexao.Close();

        }

    }
}
