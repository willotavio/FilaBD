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
            

            pacienteDAO pac = new pacienteDAO();
            pac.paciente();
           
            }






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

