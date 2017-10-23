using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace practica_para_19_10
{
    class Program
    {
        static int val = 65;

        static void MethodA()
        {
            while (val < 91)
            {
                if (!esPar(val))
                {
                    Console.WriteLine((char)val + " - Metodo A");
                    Thread.SpinWait(3000);
                    val++;
                }
            }
        }

        static void MethodB()
        {
            while (val < 91)
            {
                if (esPar(val))
                {
                    Console.WriteLine((char)val + " - Metodo B");
                    Thread.SpinWait(3000);
                    val++;
                }
            }
        }

        static Boolean esPar(int a)
        {
            if (a % 2 == 0)
                return true;
            else return false;
        }

        static void Main(string[] args)
        {
            var TaskA = Task.Factory.StartNew(MethodA);
            var TaskB = Task.Factory.StartNew(MethodB);

            Task.WaitAll(TaskA, TaskB);

            Console.WriteLine("Presione enter para salir...");
            //Console.WriteLine("TaskA id = {0}", TaskA.Id);
            //Console.WriteLine("TaskB id = {0}", TaskB.Id);
            Console.ReadLine();

        }
    }
}