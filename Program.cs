using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace Biblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Menu menu = new();
            menu.MenuPrincipal();
        }
    }
}