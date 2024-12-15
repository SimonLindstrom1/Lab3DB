using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DB
{
    public class BetygMånad
    {
        public static void VisaBetygSattSenasteManaden()
        {
            using (var context = new SchoolGradesContext())
            {
                var enManadSedan = DateTime.Now.AddMonths(-1);
                var betygDenSenasteManaden = context.Grades
                    .Where(g => g.GradeDate >= enManadSedan)
                    .Include(g => g.Student)  // Hämta relaterad elev
                    .Include(g => g.Teacher)  // Hämta relaterad lärare
                    .ToList();

                if (betygDenSenasteManaden.Any())
                {
                    Console.WriteLine("\n--- Betyg Satta Den Senaste Månaden ---");
                    foreach (var betyg in betygDenSenasteManaden)
                    {
                        Console.WriteLine($"Elev: {betyg.Student?.Name}, Kurs: {betyg.CourseName}, Betyg: {betyg.Grade1}, Datum: {betyg.GradeDate.ToShortDateString()}");
                    }
                }
                else
                {
                    Console.WriteLine("Inga betyg har satts den senaste månaden.");
                }
            }

            Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }
    }
}
