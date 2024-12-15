using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DB
{
    public class klass
    {
        public static void VisaEleverBaseratPåKlass()
        {
            using (var context = new SchoolGradesContext())
            {
                
                var klasser = context.Students
                    .Select(s => s.Class)  
                    .Distinct()  
                    .ToList();

                
                Console.WriteLine("\n--- Välj Klass ---");
                for (int i = 0; i < klasser.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {klasser[i]}");
                }

                
                Console.Write("Ange numret för den klass du vill visa: ");
                int klassVal = Convert.ToInt32(Console.ReadLine());

                
                if (klassVal < 1 || klassVal > klasser.Count)
                {
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    return;
                }

                string valdKlass = klasser[klassVal - 1];

                
                var eleverIValdKlass = context.Students
                    .Where(s => s.Class == valdKlass)
                    .ToList();

               
                if (eleverIValdKlass.Any())
                {
                    Console.WriteLine($"\n--- Elever i klass {valdKlass} ---");
                    foreach (var student in eleverIValdKlass)
                    {
                        Console.WriteLine($"ID: {student.StudentID}, Namn: {student.Name}, Födelsedatum: {student.DateOfBirth.ToShortDateString()}");
                    }
                }
                else
                {
                    Console.WriteLine($"Det finns inga elever i klassen {valdKlass}.");
                }
            }

            Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }
    }
}
