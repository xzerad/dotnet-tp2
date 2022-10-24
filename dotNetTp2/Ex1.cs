using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace dotNetTp2
{
    internal class Ex1
    {
        public static void Question1()
        {
            int age = 0;
            Console.WriteLine("Quel age avez-vous");
            try
            {
                age = int.Parse(Console.ReadLine());

            }
            catch (System.FormatException)
            {
                Console.WriteLine("Error assigning default value to age");
                age = 0;
            }
            finally
            {
                Console.WriteLine("Vous avez " + age + " ans!");

            }
        }

        public static void Question2()
        {
            uint? a = null;
            uint? b = null;
            Console.WriteLine("Nous allons faire une division avec nombres positifs: ");
            Console.WriteLine("\nEntrez un premier nombre : ");
            try
            {
                 a = uint.Parse(Console.ReadLine());

            }
            catch (Exception ex ) when (ex is System.FormatException || ex is OverflowException)
            {
                Console.WriteLine("not a positve number");
                Environment.Exit(1);

            }
            Console.WriteLine("Entrez un deuxieme nombre : ");
            try
            {
                b = uint.Parse(Console.ReadLine());

              
            }
            catch (Exception ex) when (ex is System.FormatException || ex is OverflowException )
            {
                Console.WriteLine("not a positve number");
                Environment.Exit(1);
            }
            try
            {
                if (a != null && b != null)
                {
                    uint? c = a / b;
                    Console.WriteLine("Le resultat de la division est " + c);
                }
               


            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("can't divide by zero");
                Environment.Exit(1);

            }
        }
    }
}
