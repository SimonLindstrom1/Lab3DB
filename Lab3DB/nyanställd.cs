using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DB
{
    public class nyanställd
    {
        public static void LaggTillNyAnstalld()
        {
            using (var context = new SchoolGradesContext())
            {
                Console.WriteLine("Ange den anställdes namn:");
                string namn = Console.ReadLine();

                Console.WriteLine("Ange arbetsrollen för den anställde (t.ex. 'Matte Lärare', 'Engelska Lärare', etc.):");
                string arbetsroll = Console.ReadLine();

                // Skapa ett nytt anställd objekt
                var nyAnstalld = new Employee
                {
                    Name = namn,
                    EmployeeRole = arbetsroll
                };

                // Lägg till den nya anställda i databasen
                context.Employees.Add(nyAnstalld);

                // Spara ändringarna
                context.SaveChanges();

                Console.WriteLine($"Den anställde {nyAnstalld.Name} med arbetsrollen '{nyAnstalld.EmployeeRole}' har lagts till.");
            }

            Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }
    }
}
