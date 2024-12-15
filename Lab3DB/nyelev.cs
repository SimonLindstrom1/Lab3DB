using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DB
{
    public class nyelev
    {
        public static void LaggTillNyElev()
        {
            using (var context = new SchoolGradesContext())
            {
                Console.WriteLine("Ange elevens namn:");
                string namn = Console.ReadLine();

                Console.WriteLine("Ange elevens födelsedatum (format: YYYY-MM-DD):");
                DateTime födelsedatum;
                while (!DateTime.TryParse(Console.ReadLine(), out födelsedatum))
                {
                    Console.WriteLine("Ogiltigt datum. Försök igen (format: YYYY-MM-DD):");
                }

                Console.WriteLine("Ange elevens klass:");
                string klass = Console.ReadLine();

                // Skapa ett nytt studentobjekt
                var nyElev = new Student
                {
                    Name = namn,
                    DateOfBirth = födelsedatum,
                    Class = klass
                };

                // Lägg till eleven i databasen
                context.Students.Add(nyElev);

                // Spara ändringarna
                context.SaveChanges();

                Console.WriteLine($"Eleven {nyElev.Name} har lagts till i {nyElev.Class}.");
            }

            Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }
    }
}
