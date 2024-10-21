using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EseLista
{
    internal class Program
    {
        static void Main()
        {
            AbiList v = new AbiList();
            v.Add(4);
            v.Add(8);
            v.Add(5);
            v.Add(6);
            v.Add(0);
            v.Add(2);
            v.Add(3);
            v.Add(1);
            v.Add(7);
            DebugInfos(v);

            v.Remove(5);
            DebugInfos(v);

            Console.WriteLine("Test: " + v.Contains(4) + "\t" + v.Contains(44));
            Console.WriteLine("Test: " + v.Find(7));
            Console.WriteLine("Test: " + v.IndexOf(3) + "\n");

            v.Sort();
            DebugInfos(v);
            
            Console.ReadLine();
        }

        static void DebugInfos(AbiList a)
        {
                Console.WriteLine("Array:");
                for (int i = 0; i < a.Length; i++)
                {
                    Console.WriteLine(a[i]);

                }

                Console.WriteLine($"\nCount: {a.Length}\n\n");
        }
    }
}
