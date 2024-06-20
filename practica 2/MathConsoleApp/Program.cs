using System;
using MathLibrary;

namespace MathConsoleApp
{
    class Program
    {
        static void Mostrarmenu()
        {
            Console.WriteLine("Seleccione una operación:");
            Console.WriteLine("1. Sumar");
            Console.WriteLine("2. Restar");
            Console.WriteLine("3. Multiplicar");
            Console.WriteLine("4. Dividir");
            Console.WriteLine("5. Salir");
        }

        static void Main(string[] args)
        {
            MathOperations mathOps = new MathOperations();

            bool exit = false;
            while (!exit)
            {
                Mostrarmenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Ingrese el primer número:");
                        double a = double.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo número:");
                        double b = double.Parse(Console.ReadLine());
                          Console.WriteLine("Ingrese el tercer número:");
                        double c = double.Parse(Console.ReadLine());
                        Console.WriteLine($"Resultado: {mathOps.Sumar(a, b, c)}");
                        break;

                    case "2":
                        Console.WriteLine("Ingrese el primer número:");
                        a = double.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo número:");
                        b = double.Parse(Console.ReadLine());
                        Console.WriteLine($"Resultado: {mathOps.Restar(a, b)}");
                        break;

                    case "3":
                        Console.WriteLine("Ingrese el primer número:");
                        a = double.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo número:");
                        b = double.Parse(Console.ReadLine());
                        Console.WriteLine($"Resultado: {mathOps.Multiplicar(a, b)}");
                        break;

                    case "4":
                        Console.WriteLine("Ingrese el primer número:");
                        a = double.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo número:");
                        b = double.Parse(Console.ReadLine());
                        if (b != 0)
                        {
                            Console.WriteLine($"Resultado: {mathOps.Dividir(a, b)}");
                        }
                        else
                        {
                            Console.WriteLine("Error: División por cero.");
                        }
                        break;

                    case "5":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
