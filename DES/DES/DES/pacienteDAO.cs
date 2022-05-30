using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using System.Threading;

namespace DES
{
    class PacienteDAO : Pessoa
    {
        private MySqlConnection conexao; 
        
        //conexao
        public void Conexao()
        {
            
            conexao = new MySqlConnection("server=localhost;port=3306;database=fila;uid=root;password=;sslmode=none");
            try
            {
                conexao.Open();
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" Conexão estabelecida com sucesso!");
                Thread.Sleep(3000);
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(ex.Message);
                Console.Write("\nErro\n\nAperte qualquer tecla para fechar o programa");
                Console.ReadKey();
                Environment.Exit(0);
            }

        }

        //iniciar con
        public void IniciarCon()
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
                    Console.Write("\nErro\n\nAperte qualquer tecla para fechar o programa");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
        }

        //read
        public void Cons()
        {
            String sql = "select * from paciente order by posicao";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                    for (int i = 1; i < 9; i++) {
                while (rdr.Read())
                {
                    Console.WriteLine("POSIÇÃO." + i++);
                    
                        Console.WriteLine("Nome:{0}\n\n", rdr["nome"]);          
                }
                }
                Console.Write("\nAperte qualquer tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("A fila está vazia!");
                Console.Write("\nAperte qualquer tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
            conexao.Close();
        }

        //insert
        public void Add() {
           
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
            Console.WriteLine("\nAperte qualquer tecla para continuar");

            Console.ReadKey();
            Console.Clear();
            conexao.Close();
        }

        //update
        public void Alt()
        {
            string sql = "select * from paciente order by posicao";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            MySqlDataReader rdr = cmd.ExecuteReader();
            for (int i = 1; i < 9; i++)
            {
                while (rdr.Read())
                {
                    Console.WriteLine("POSIÇÃO." + i++);
                    Console.WriteLine("\nPOSIÇÃO:{0} \nCPF:{1} \nNome:{2} \nTelefone:{4} \nIdade:{3} \nPrioridade:{5}\n", rdr["posicao"], rdr["cpf"], rdr["nome"], rdr["idade"], rdr["telefone"], rdr["prioridade"]);
                    
                }
            }
            Console.Write("\nAperte qualquer tecla para continuar");
            Console.ReadKey();
            if (rdr.HasRows)
            {

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
                Console.Write("\nAperte qualquer tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("A fila está vazia!");
                Console.Write("\nAperte qualquer tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
            conexao.Close();

        }

        //delete
        public void Del()
        {
            string sql = "select * from paciente order by posicao";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            MySqlDataReader rdr = cmd.ExecuteReader();
            for (int i = 1; i < 9; i++)
            {
                while (rdr.Read())
                {
                    Console.WriteLine("POSIÇÃO." + i++);
                    Console.WriteLine("Nome:{0}\n\n", rdr["nome"]);
                }
            }
                Console.Write("\nAperte qualquer tecla para continuar");
                Console.ReadKey();
            if (rdr.HasRows)
            {
                Console.WriteLine("\nQual a posição de quem foi atendido?");
                posicao = int.Parse(Console.ReadLine());


                conexao.Close();
                conexao.Open();
                sql = "delete from paciente where posicao = @posicao ";
                cmd = new MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@posicao", posicao);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Paciente retirado da fila com sucesso!");
                Console.Write("\nAperte qualquer tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("A fila está vazia!");
                Console.Write("\nAperte qualquer tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
            conexao.Close();

        }

    }
}
