using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DB
{
    public class Elever
    {
        public static void VisaEleverMedFilterOchSortering()
        {
            using (var context = new SchoolGradesContext())
            {
                Console.WriteLine("\n--- Alla Elever ---");

                
                Console.WriteLine("Vill du filtrera på:");
                Console.WriteLine("1. Förnamn");
                Console.WriteLine("2. Efternamn");
                Console.WriteLine("3. Ingen filtrering");
                Console.Write("Ange ditt val: ");
                string filterVal = Console.ReadLine();

                string filter = null;
                if (filterVal == "1" || filterVal == "2")
                {
                    Console.Write("Ange text för filtrering: ");
                    filter = Console.ReadLine();
                }

                
                Console.WriteLine("\nVälj sorteringsordning:");
                Console.WriteLine("1. Stigande (A-Ö)");
                Console.WriteLine("2. Sjunkande (Ö-A)");
                Console.Write("Ange ditt val: ");
                string sortOrder = Console.ReadLine();

                
                var studentsQuery = context.Students.AsQueryable();

                
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    if (filterVal == "1") 
                    {
                        
                        studentsQuery = studentsQuery.Where(s => s.Name.StartsWith(filter));
                    }
                    else if (filterVal == "2") 
                    {
                        
                        studentsQuery = studentsQuery.Where(s => s.Name.Contains(filter)); 
                    }
                }

               
                var students = sortOrder == "1"
                    ? studentsQuery.OrderBy(s => s.Name).ToList()  
                    : studentsQuery.OrderByDescending(s => s.Name).ToList(); 

                
                if (students.Any())
                {
                    foreach (var student in students)
                    {
                        Console.WriteLine($"ID: {student.StudentID}, Namn: {student.Name}, Födelsedatum: {student.DateOfBirth.ToShortDateString()}, Klass: {student.Class}");
                    }
                }
                else
                {
                    Console.WriteLine("Inga elever hittades med den angivna filtreringen.");
                }
            }

            Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }
    }
}
