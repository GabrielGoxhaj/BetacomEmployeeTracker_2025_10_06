using BetacomEmployeeTracker_2025_10_06.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetacomEmployeeTracker_2025_10_06.BLogic
{
    public class FindEmployeeActivities
    {
        public static void FindEmployeeActivitiesById(string MatricolaInserita)
        {
            List<EmployeesActivities> listEmployeesActivities = [];
            string rowSeparator = new string('-', 100);

            string fileName = "EmployeesActivities.txt";
            string filePath = @"..\..\..\Data";

            string[] employeeActivitiesTxt = File.ReadAllLines(Path.Combine(filePath, fileName));

            foreach (string line in employeeActivitiesTxt)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] fields = line.Split(';');

                if (fields.Length < 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(rowSeparator);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Riga Ignorata (campi: {fields.Length} / 10): {line}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(rowSeparator);
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                listEmployeesActivities.Add(new EmployeesActivities
                {
                    Data = fields[0],
                    Luogo = fields[1],
                    OreLavorative = Convert.ToUInt16(fields[2]),
                    Matricola = fields[3]
                });
            }
            bool trovateActivities = false;
            int oreLavorative = 0;
            var ultimoGiornoLavorativo = new DateOnly();
            var giornoLavorativoStored = new DateOnly();
            var countGiorniLavorativi = 0;
            string[] arrayGiorniLavorativi = [];
            foreach (var employeeActivities in listEmployeesActivities)
            {
                if (employeeActivities.Matricola == MatricolaInserita)
                {
                    // Somma delle ore Lavorative
                    oreLavorative += employeeActivities.OreLavorative;

                    arrayGiorniLavorativi = arrayGiorniLavorativi.Append(employeeActivities.Data).ToArray();

                    // Controllo della giornata lavorativa se più recente
                    giornoLavorativoStored = DateOnly.ParseExact(employeeActivities.Data, "dd/MM/yyyy", null);
                    if (giornoLavorativoStored > ultimoGiornoLavorativo)
                    {
                        ultimoGiornoLavorativo = giornoLavorativoStored;
                    }
                    // Cambia il valore del booleano di controllo    
                    trovateActivities = true;
                }
            }
            
            Console.WriteLine($"Ore lavorative: {oreLavorative}");
            Console.WriteLine($"Ultimo giorno lavorativo: {ultimoGiornoLavorativo}");
            countGiorniLavorativi = arrayGiorniLavorativi.Count();
            Console.WriteLine($"Giorni di lavoro: {countGiorniLavorativi}");
            if (!trovateActivities)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Il lavoratore con n° matricola: {MatricolaInserita} è un lazzarone.");
                Console.Write("Premi un tasto per continuare la ricerca con una nuova matricola, oppure Esc per tornare al menù principale");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
