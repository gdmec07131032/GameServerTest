using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransformation
{
    class Program
    {
        static void Main(string[] args)
        {
            //byte[] data = Encoding.UTF8.GetBytes("");
            int count = 10000;
            byte[] data = BitConverter.GetBytes(count);
            foreach (byte b in data)
            {
                Console.Write(b + ":");
            }
            Console.ReadKey();
        }
    }
}
