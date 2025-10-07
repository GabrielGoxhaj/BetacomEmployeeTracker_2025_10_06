//using BetacomEmployeeTracker_2025_10_06.DataModel;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BetacomEmployeeTracker_2025_10_06.BLogic
//{
//    internal class WorkingEmployees
//    {
//        List<Employees> employees = [];
//        internal WorkingEmployees() { }

//        internal WorkingEmployees(Employees Employee)
//        {
//            Console.Clear();
//            Console.WriteLine(
//                $"Matricola: {Employee.Matricola} - Nome e cognome: {Employee.NomeCognome}" +
//                $" - Mansione: {Employee.Mansione} in reparto {Employee.Reparto}" +
//                $"di anni {Employee.Età}" +
//                $"Residenza in {Employee.Indirizzo}, {Employee.Città} ({Employee.Provincia}), CAP {Employee.CAP}" +
//                $"Numero di telefono {Employee.Telefono}"
//                );
//        }

//        internal bool LoadEmployee(Employees Employee)
//        {
//            bool result = false;

//            try
//            {
//                Employees.Add(Employee);
//                result = true;
//            }
//            catch (Exception)
//            {
//                throw;
//            }

//            return result;
//        }

//        internal void PrintWorkingEmployees()
//        {
//            string rowSeparator = new string('-', 100);
//            foreach (Employees Employee in employees)
//            {
//                Console.ForegroundColor = ConsoleColor.Blue;
//                Console.WriteLine(rowSeparator);
//                Console.ForegroundColor = ConsoleColor.White;

//                Console.WriteLine($"Matricola: {Employee.Matricola} - Nome e cognome: {Employee.NomeCognome}" +
//                $" - Mansione: {Employee.Mansione} in reparto {Employee.Reparto}" +
//                $"di anni {Employee.Età}" +
//                $"Residenza in {Employee.Indirizzo}, {Employee.Città} ({Employee.Provincia}), CAP {Employee.CAP}" +
//                $"Numero di telefono {Employee.Telefono}");
//                foreach (EmployeesActivities activities in Employee.Activities)
//                {
//                    Console.WriteLine();
//                    Console.WriteLine($"Dove: {activities.Luogo} - Ore lavorative: {activities.OreLavorative} - in data {activities.Data}");
//                }
//            }
//        }
//    }
//}
