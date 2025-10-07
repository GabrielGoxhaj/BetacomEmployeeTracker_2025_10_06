using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetacomEmployeeTracker_2025_10_06.BLogic
{
    public class MenuManager
    {
        public static void MainMenu()
        {
            string rowSeparator = new string('-', 100);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("========= Gestionale Lavoratori Betacom =========");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Vedere i lavoratori");
            Console.WriteLine("2. Vedere i lavoratori con timbrature (W.I.P.)");
            Console.WriteLine("3. Vedere i lavoratori lazzaroni nullafacenti (W.I.P.)");
            Console.WriteLine("4. Vedere le timbrature");
            Console.WriteLine("5. Vedere un lavoratore nello specifico");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("9. Chiudere il programma");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(rowSeparator);
            Console.ForegroundColor = ConsoleColor.White;
            
            int scelta = Convert.ToInt16(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    FileManager.ReadEmployeesFile();
                    break;
                case 2:
                    FileManager.ReadWorkingEmployeesFile();
                    break;
                case 3:
                    FileManager.ReadNotWorkingEmployeesFile();
                    break;
                case 4:
                    FileManager.ReadActivitiesFile();
                    break;
                case 5:
                    FindEmployee.FindEmployeebyId();
                    break;
                case 9:
                    Console.WriteLine("Adieau e buon caffè");
                    break;
                default:
                    Console.WriteLine("Non hai inserito un valore corretto");
                    MenuManager.MainMenu();
                    break;
            }
        }

    }
}
