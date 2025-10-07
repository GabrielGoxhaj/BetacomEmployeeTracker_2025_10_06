using BetacomEmployeeTracker_2025_10_06.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BetacomEmployeeTracker_2025_10_06.BLogic
{
    public class FindEmployee
    {
        public static void FindEmployeebyId()
        {
            List<Employees> listEmployees = [];
            string rowSeparator = new string('-', 100);

            string fileName = "Employees.txt";
            string filePath = @"..\..\..\Data";

            string[] employeeTxt = File.ReadAllLines(Path.Combine(filePath, fileName));

            Console.Clear();
            foreach (string line in employeeTxt)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] fields = line.Split(';');

                if (fields.Length < 10)
                {
                    continue;
                }

                listEmployees.Add(new Employees
                {
                    Matricola = fields[0],
                    NomeCognome = fields[1],
                    Mansione = fields[2],
                    Reparto = fields[3],
                    Età = Convert.ToInt16(fields[4]),
                    Indirizzo = fields[5],
                    Città = fields[6],
                    Provincia = fields[7],
                    CAP = Convert.ToInt32(fields[8]),
                    Telefono = Convert.ToInt32(fields[9]),
                    Activities = new List<EmployeesActivities>(),
                });
            }

            string MatricolaInserita = "";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Inserisci il numero matricola del lavoratore: ");
            Console.ForegroundColor = ConsoleColor.White;
            MatricolaInserita = Console.ReadLine();
            if (MatricolaInserita == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Non hai inserito un numero matricola. Premi un tasto per ricominciare la ricerca");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                FindEmployeebyId();
            }
            else
            {
                bool trovato = false;
                foreach (var employee in listEmployees)
                {
                    if (employee.Matricola == MatricolaInserita)
                    {
                        Console.WriteLine($"N° Matricola: {employee.Matricola} - {employee.NomeCognome} - {employee.Reparto}");
                        trovato = true;

                        // Pezzo codice per le attività
                        Console.WriteLine(rowSeparator);
                        FindEmployeeActivities.FindEmployeeActivitiesById(MatricolaInserita);
                        // Pezzo codice per le attività

                        break;
                    }
                }
                if (!trovato)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Non esistono lavoratori con matricola n° {MatricolaInserita} nel database.");
                    Console.Write("Premi un tasto per continuare la ricerca con una nuova matricola, oppure Esc per tornare al menù principale");
                    Console.ForegroundColor = ConsoleColor.White;

                    while (true)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        if (keyInfo.Key == ConsoleKey.Escape)
                        {
                            MenuManager.MainMenu();
                            break;
                        }
                        else
                        {
                            FindEmployeebyId();
                            break;
                        }
                    }
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(rowSeparator);
                Console.WriteLine("Premi un tasto per tornare al menù principale");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;
                Loading.LoadingMenu();
            }
        }
    }
}