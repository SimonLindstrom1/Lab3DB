using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DB
{
    public class Lärare
    {
        public static void VisaAnstalldaMedFilter()
        {
            using (var context = new SchoolGradesContext())
            {
                Console.WriteLine("\n--- Alla Roller ---");

                // Hämta alla roller (utan duplicering) från databasen
                var roles = context.Employees
                                   .Select(e => e.EmployeeRole)
                                   .Distinct()
                                   .ToList();

                // Visa tillgängliga roller
                Console.WriteLine("Tillgängliga roller:");
                for (int i = 0; i < roles.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {roles[i]}");
                }
                Console.WriteLine("0. Visa alla anställda");

                // Be användaren välja en roll
                Console.Write("\nVälj en roll genom att ange numret (eller 0 för att visa alla): ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 0 && choice <= roles.Count)
                {
                    // Hämta anställda baserat på valet
                    var employees = choice == 0
                        ? context.Employees.ToList() // Visa alla om 0 väljs
                        : context.Employees.Where(e => e.EmployeeRole == roles[choice - 1]).ToList();

                    // Visa resultaten
                    Console.WriteLine("\n--- Resultat ---");
                    if (employees.Any())
                    {
                        foreach (var employee in employees)
                        {
                            Console.WriteLine($"ID: {employee.EmployeeID}, Namn: {employee.Name}, Roll: {employee.EmployeeRole}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Inga anställda hittades för den valda rollen.");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                }
            }

            Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }
    }
}
