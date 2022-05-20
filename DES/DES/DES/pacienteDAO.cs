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
                Console.WriteLine("MENU\n 1.Listar\n 2.Adicionar\n 3.Atualizar\n 4.Deletar\n 5.Sair");
                escolha = int.Parse(Console.ReadLine());

                Console.Clear();
                switch(escolha)
                {
                    //read
                    case 1:

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
                        Console.ReadKey();
                        Console.Clear();
                        conexao.Close();
                        break;
                    //fim read

                    case 2:
                            //insert
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

                            Console.ReadKey();
                            Console.Clear();
                            conexao.Close();
                            break;
                    //fim insert

                    //update
                    case 3:
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

                            sql = "UPDATE paciente SET nome = @nome, telefone = @telefone, idade = @idade Where cpf = @cpf ";
                            cmd = new MySqlCommand(sql, conexao);
                            cmd.Parameters.AddWithValue("@cpf", cpf);
                            cmd.Parameters.AddWithValue("@nome", nome);
                            cmd.Parameters.AddWithValue("@telefone", telefone);
                            cmd.Parameters.AddWithValue("@idade", idade);
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Dados alterados com sucesso!");

                            Console.ReadKey();
                            Console.Clear();
                            conexao.Close();
                        break; //fim updae

                    //delete
                    case 4:
                            conexao.Close();
                            conexao.Open();

                            Console.WriteLine("Qual o CPF de quem deve ser deletado?");
                            cpf = Console.ReadLine();
                            sql = "delete from paciente where cpf = @cpf ";
                            cmd = new MySqlCommand(sql, conexao);
                            cmd.Parameters.AddWithValue("@cpf", cpf);
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Dados deletados com sucesso");

                            Console.ReadKey();
                            Console.Clear();
                            conexao.Close();
                        break; //fim delete
                               //sair
                    case 5:
                        
                            Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;
                }
                } while (m == "1") ;
                //fim while
            
            }
        }
}
