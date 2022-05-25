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
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            //conexao
            MySqlConnection conexao;
            conexao = new MySqlConnection("server=localhost;database=fila;uid=root;password=");
            try
            {
                conexao.Open();
                Console.WriteLine("Conexão estabelecida com sucesso!");
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Erro");
                Console.ReadKey();
                Environment.Exit(0);
            }

            string m = "1";
            do
            {
                int escolha;
                Console.WriteLine("ATENDIMENTO\n\n MENU\n 1.Listar\n 2.Adicionar\n 3.Atualizar\n 4.Deletar\n 5.Sair");
                escolha = int.Parse(Console.ReadLine());

                Console.Clear();
                switch(escolha)
                {
                    //read
                    case 1:

                        conexao.Close();
                        conexao.Open();

                        String sql = "select * from paciente order by posicao";
                        MySqlCommand cmd = new MySqlCommand(sql, conexao);
                        MySqlDataReader rdr = cmd.ExecuteReader();

                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                Console.WriteLine("\nPOSIÇÃO:{0} \nCPF:{1} \nNome:{2} \nIdade:{3} \nTelefone:{4} \nPrioridade:{5}\n",rdr["posicao"], rdr["cpf"],  rdr["nome"], rdr["idade"], rdr["telefone"], rdr["prioridade"]);
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
                        break;
                    //fim read
                    
                    //insert
                    case 2:
                        if (conexao.State == ConnectionState.Open)
                        {

                        }
                        else
                        {
                            conexao.Open();
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

                            //string insertQuery = "insert into paciente (posicao, cpf, nome, telefone, idade, preferencial) values ('" + posicao + "','" + cpf + "','" + nome + "', '" + telefone + "'," + idade + ")";
                            
                            //MySqlCommand insertCommand = new MySqlCommand(insertQuery, conexao);
                            //insertCommand.ExecuteNonQuery();
                            //Console.WriteLine("Dados inseridos com sucesso!");

                            sql = "insert into paciente (posicao, cpf, nome, telefone, idade, prioridade) values (@posicao, @cpf, @nome, @telefone, @idade, @prioridade)";
                            cmd = new MySqlCommand(sql, conexao);
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
                            break;
                    //fim insert

                    //update
                    case 3:
                        if (conexao.State == ConnectionState.Open)
                            {

                            }
                            else
                            {
                                conexao.Open();
                            }

                            sql = "select * from paciente order by posicao";
                            cmd = new MySqlCommand(sql, conexao);
                            rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                            Console.WriteLine("\nPOSIÇÃO:{0} \nCPF:{1} \nNome:{2} \nIdade:{3} \nTelefone:{4} \nPrioridade:{5}\n", rdr["posicao"], rdr["cpf"], rdr["nome"], rdr["idade"], rdr["telefone"], rdr["prioridade"]);
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
                        break; //fim update

                    //delete
                    case 4:
                        if (conexao.State == ConnectionState.Open)
                        {

                        }
                        else
                        {
                            conexao.Open();
                        }

                        sql = "select * from paciente order by posicao";
                        cmd = new MySqlCommand(sql, conexao);
                        rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            Console.WriteLine("\nPOSIÇÃO:{0} \nCPF:{1} \nNome:{2} \nIdade:{3} \nTelefone:{4} \nPrioridade:{5}\n", rdr["posicao"], rdr["cpf"], rdr["nome"], rdr["idade"], rdr["telefone"], rdr["prioridade"]);
                            Console.ReadKey();
                        }

                        Console.WriteLine("\nQual a posição de quem deve ser deletado?");
                        posicao = int.Parse(Console.ReadLine());

                        //conexao.Close();
                        //conexao.Open();
                        //sql = "SELECT EXISTS(SELECT cpf from paciente WHERE cpf= @cpf)";
                        ////sql = "SELECT COUNT(1) FROM paciente where posicao = '@posicao'";
                        //cmd = new MySqlCommand(sql, conexao);
                        //cmd.Parameters.AddWithValue("@posicao", posicao);
                        //rdr = cmd.ExecuteReader();
                        
                        //if (rdr.Read())
                        //{
                            conexao.Close();
                            conexao.Open();
                             sql = "delete from paciente where posicao = @posicao ";
                             cmd = new MySqlCommand(sql, conexao);
                             cmd.Parameters.AddWithValue("@posicao", posicao);
                             cmd.ExecuteNonQuery();
                            Console.WriteLine("Dados deletados com sucesso");
                        //    }
                        //    else
                        //{
                            //    conexao.Close();
                            //    conexao.Open();
                            //    Console.WriteLine("CPF não encontrado!");
                            //    Console.ReadKey();
                            //conexao.Close();
                            
                        //}
                            Console.ReadKey();
                            Console.Clear();
                            conexao.Close();
                        break; //fim delete
                               
                        //sair
                    case 5:
                            Environment.Exit(0);
                        break;
                    //fim sair

                    //invalida
                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;
                }//fim invalida

                } while (m != "q") ;
                //fim while
            
            }
        }
}
