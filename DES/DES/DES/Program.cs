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

            string m = "1";
            do
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                int escolha;
                Console.WriteLine(" ATENDIMENTO\n\n MENU\n 1.FILA\n 2.ADICIONAR PACIENTE\n 3.ALTERAR DADOS\n 4.ATENDER PACIENTE\n 5.FECHAR PROGRAMA");
                escolha = int.Parse(Console.ReadLine());

                Console.Clear();
                switch (escolha)
                {
                    case 1:
                        c.IniciarCon();
                        c.Cons();
                        break;
                    
                    case 2:
                        c.IniciarCon();
                        c.Add();
                        break;

                    case 3:
                        c.IniciarCon();
                        c.Alt();
                        break; 
                    
                    case 4:
                        c.IniciarCon();
                        c.Del();
                        break; 
                    
                    case 5:
                        Environment.Exit(0);
                        break;
                    
                    default:
                        Console.WriteLine("Opção Inválida!");
                        Console.ReadKey();
                        break;
                }

            } while (m != "q");

        }

    }
    }

