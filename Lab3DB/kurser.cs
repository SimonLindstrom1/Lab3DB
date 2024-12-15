using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DB
{
    internal class kurser
    {
        public static void VisaKurserMedSnittOchBetyg()
        {
            using (var context = new SchoolGradesContext())
            {
                // Mappa betyg till numeriska poäng
                var betygPoang = new Dictionary<char, int>
        {
            { 'A', 5 },
            { 'B', 4 },
            { 'C', 3 },
            { 'D', 2 },
            { 'E', 1 },
            { 'F', 0 }
        };

                // Hämta alla betyg från databasen
                var grades = context.Grades
                    .Select(g => new
                    {
                        g.CourseName,
                        g.Grade1
                    })
                    .ToList(); // Client-side evaluation börjar här

                // Grupp och bearbeta på klienten
                var kursStatistik = grades
                    .GroupBy(g => g.CourseName)
                    .Select(group => new
                    {
                        Kurs = group.Key,
                        SnittBetyg = group.Average(g =>
                            g.Grade1 != null && g.Grade1.Length > 0 && betygPoang.ContainsKey(g.Grade1[0])
                                ? betygPoang[g.Grade1[0]]
                                : 0),
                        HogstaBetyg = group.Max(g =>
                            g.Grade1 != null && g.Grade1.Length > 0
                                ? g.Grade1
                                : "-"),
                        LagstaBetyg = group.Min(g =>
                            g.Grade1 != null && g.Grade1.Length > 0
                                ? g.Grade1
                                : "-")
                    })
                    .OrderBy(k => k.Kurs)
                    .ToList();

                // Skriv ut statistik
                Console.WriteLine("\n--- Kursstatistik ---");
                foreach (var kurs in kursStatistik)
                {
                    Console.WriteLine($"Kurs: {kurs.Kurs}");
                    Console.WriteLine($"  Snittbetyg (numeriskt): {kurs.SnittBetyg:F2}");
                    Console.WriteLine($"  Högsta betyg: {kurs.HogstaBetyg}");
                    Console.WriteLine($"  Lägsta betyg: {kurs.LagstaBetyg}");
                }

                Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
                Console.ReadKey();
            }
        }
    }
}
