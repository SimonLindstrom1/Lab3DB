using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DB
{
    public class meny
    {
        public static void ShowMenu()
        {
            bool programAktivt = true;
            int menuSelected = 0;
            string[] menuOptions = new string[] { "Anställda", "Elever", "Klass", "Betyg", "Kurser", "Nya Anställda", "Nya Elever" };
            int menuWidth = 35;

            while (programAktivt)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔" + new string('═', menuWidth + 16) + "╗");
                Console.WriteLine("║" + "\t\tVälkommen till Menyn".PadLeft((menuWidth + "Välkommen till Menyn".Length) / 2).PadRight(menuWidth + 8) + "║");
                Console.WriteLine("╚" + new string('═', menuWidth + 16) + "╝");
                Console.ResetColor();

                Console.WriteLine("Hej och välkommen till menyn.");
                Console.WriteLine("Du kan navigera med \" ⬇️\" och \" ⬆️\".");
                Console.WriteLine("Tryck på \"Enter\" när du vill välja den menyn du är nöjd med.");
                Console.WriteLine();
                Console.WriteLine("╔" + new string('═', menuWidth - 2) + "╗");

                // Skriv ut alla menyalternativ
                for (int i = 0; i < menuOptions.Length; i++)
                {
                    if (i == menuSelected)
                    {
                        // Markera det valda alternativet
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine("║ " + menuOptions[i].PadRight(menuWidth - 2) + " ║");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("║ " + menuOptions[i].PadRight(menuWidth - 2) + " ║");
                    }
                }

                Console.WriteLine("╚" + new string('═', menuWidth - 2) + "╝");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (menuSelected < menuOptions.Length - 1)
                            menuSelected++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (menuSelected > 0)
                            menuSelected--;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (menuSelected)
                        {
                            case 0:
                                Console.WriteLine("Visa lärare:");
                                Lärare.VisaAnstalldaMedFilter();
                                break;
                            case 1:
                                Console.WriteLine("Visa Elever:");
                                Elever.VisaEleverMedFilterOchSortering();
                                break;
                            case 2:
                                Console.WriteLine("Visa klass:");
                                klass.VisaEleverBaseratPåKlass();
                                break;
                            case 3:
                                Console.WriteLine("Visa månadens betyg:");
                                BetygMånad.VisaBetygSattSenasteManaden();
                                break;
                            case 4:
                                Console.WriteLine("Visa kurs med snittbetyg och högsta samt lägsta betygen");
                                kurser.VisaKurserMedSnittOchBetyg();
                                break;
                            case 5:
                                Console.WriteLine("Lägg till ny anställd:");
                                nyanställd.LaggTillNyAnstalld();
                                break;
                            case 6:
                                Console.WriteLine("Lägg till ny elev");
                                nyelev.LaggTillNyElev();
                                break;
                        }
                        Console.WriteLine();
                        Console.WriteLine("Tryck på valfri tangent för att återgå till menyn!");
                        Console.ReadKey(true);
                        break;
                }
            }
        }
    }
}

