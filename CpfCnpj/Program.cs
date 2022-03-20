using System;
using ValidarCpfCnpj;

namespace CpfCnpj
{
    class Program
    {
        static void Main(string[] args)
        {
            string executar = "0";
            do
            {
                Console.Clear();
                Console.WriteLine("\nGabriel de Oliveira Silva" +
                                  "\nEscolha uma opção para validar:" +
                                  "\n1 - Validar CPF" +
                                  "\n2 - Validar CNPJ" +
                                  "\n3 - Sair");
                Console.Write("\nInforme o número da opção......: ");
                executar = Console.ReadLine();
                string resultado = string.Empty;

                switch(executar)
                {
                    case "1":                    
                        Console.Write("insira o cpf: ");
                        resultado = Validadores.ValidarCpf(Console.ReadLine())? "CPF VERIFICADO" : "CPF INVÁLIDO";
                        Console.WriteLine(resultado);
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Write("insira o cnpj: ");
                        resultado = Validadores.ValidarCnpj(Console.ReadLine())? "CNPJ VERIFICADO" : "CNPJ INVÁLIDO";
                        Console.WriteLine(resultado);
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.WriteLine("Programa encerrado....");
                        Console.ReadKey();
                        break;                    
                    default:
                        Console.Write("\nOpção Inválida! Tente novamente.");
                        Console.ReadKey();
                        break;
                }
            }
            while (int.Parse(executar) != 3);
                       
        }
    }
}