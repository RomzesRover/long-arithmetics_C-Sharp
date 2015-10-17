using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongArith
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введи число, факториал которого необходимо найти");
            String a = Console.ReadLine();

            String result = "1";

            while (!a.Equals("0"))
            {
                result = Long_Arithmetics.findProizv(result, a);
                a = Long_Arithmetics.findRaznost(a, "1");
            }

            Console.WriteLine(result);




            //Examole of using long arithmetics methods 
            //supports import of strings with digits w w\o "-" sign

            //Console.WriteLine(Long_Arithmetics.findMax("232323", "232"));
            //Console.WriteLine(Long_Arithmetics.findMin("232323", "232"));
            //Console.WriteLine(Long_Arithmetics.findSumm("223423432432432423423", "-21"));
            //Console.WriteLine(Long_Arithmetics.findRaznost("19", "10"));
            //Console.WriteLine(Long_Arithmetics.findProizv("1299", "32332322131231233"));

            Console.ReadLine();
        }

    }
}
