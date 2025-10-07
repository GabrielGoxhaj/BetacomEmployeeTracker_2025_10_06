using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetacomEmployeeTracker_2025_10_06.BLogic
{
    public static class Loading
    {
        public static void LoadingMenu()
        {
            string rowSeparator = new string('-', 100);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("Caricando, attendere prego.");
            Thread.Sleep(500);
            Console.Clear();
            Console.Write("Caricando, attendere prego..");
            Thread.Sleep(500);
            Console.Clear();
            Console.Write("Caricando, attendere prego...");
            Thread.Sleep(500);
            Console.ForegroundColor = ConsoleColor.White;
            MenuManager.MainMenu();
        }
    }
}
