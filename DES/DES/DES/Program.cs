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
            PacienteDAO c = new PacienteDAO();
            c.Conexao();
            c.IniciarCon();
            Pessoa p = new Pessoa();
            p.cadPessoa();

            string m = "1";
            do
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                int escolha;
                Console.WriteLine(" ATENDIMENTO\n\n MENU\n 1.Listar\n 2.Adicionar\n 3.Atualizar\n 4.Deletar\n 5.Sair");
                escolha = int.Parse(Console.ReadLine());

                Console.Clear();
                switch (escolha)
                {
                    case 1:
                        c.Cons();
                        break;
                    
                    case 2:
                        c.Add();
                        break;

                    case 3:
                        c.Alt();
                        break; 
                    
                    case 4:
                        c.Del();
                        break; 
                    
                    case 5:
                        Environment.Exit(0);
                        break;
                    
                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;
                }

            } while (m != "q");

        }

    }
    }

