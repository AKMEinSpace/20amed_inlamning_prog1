using System;
using System.Linq;

namespace inlamning1
{
    class Program
    {
        //Huvudmeny: "executes" funktioner via användarinmatning.
        static void Main(string[] args)
        {
            Console.WriteLine("Tryck ENTER för att starta programmet...");
            ConsoleKeyInfo choice = Console.ReadKey();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Skriv in NUMRET före ditt val eller ESC för att avsluta programmet..");
                for (int i = 1; i < 6; i++)
                {
                    Console.WriteLine("{0}: Uppgift {0}", i);
                }
                //Läser in choice som stoppas in i switchen nedan. 
                choice = Console.ReadKey();
                //Console.WriteLine(choice.Key.ToString());
                
                
                // Kollar om inmatningen är ESC.
                if (quitConfirm(choice)) { break; }

                switch (choice.Key.ToString())
                {
                    case "D1":
                        mean();
                        break;
                    case "D2":
                        dice();
                        break;
                    case "D3":
                        mean();
                        break;
                    case "D4":
                        Console.WriteLine("Tryck A för att komma till Uppgift 4 a), Tryck B för att komma till 4 b).");
                        ConsoleKeyInfo ab_choice = Console.ReadKey();
                        while (true)
                        {
                            if (ab_choice.Key.ToString() == "A")
                            {
                                star_pyramid();
                                break;
                            }
                            else if (ab_choice.Key.ToString() == "B")
                            {
                                number_pyramid();
                                break;
                            }
                        }


                        break;
                    case "D5":
                        rectangle();
                        break;



                }
            }

        }

        static bool quitConfirm(ConsoleKeyInfo putPut)
        {
            Console.Clear();
            if (putPut.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("Är du säker på att du vill avsluta proogrammet? Y/n");
                ConsoleKeyInfo conf = Console.ReadKey();
                if (conf.Key.ToString().ToLower() == "y" || conf.Key == ConsoleKey.Enter || conf.Key == ConsoleKey.Escape)
                {
                    return true;
                }
            }
            return false;
        }
        //Används i felhantering. dvs. används inte alls..
        static string try_again(string data_type)
        {
            Console.WriteLine("Det tal du matat in är inte rätt. Ska vara: {0} Försök igen!", data_type);
            string new_sak = Console.ReadLine();
            return new_sak;
        }

        //Felhanterings funktion som tar in datan som ska kollas så att det är rätt datatyp. Tar in data och data typ som input. Funkar nästan
        /*
        static string felhantering(string  sak, string data_type)
        {
            bool is_right = true;
            switch (data_type)
            {
                case "heltal":
                    while (is_right){
                        if (int.TryParse(sak, out int value))
                        {
                            return sak;
                        }
                            
                        else
                            {
                                try_again(data_type);
                            }
                            
                    
                    }
                    break;

                case "string":
                    while (is_right)
                    {
                        try
                        {
                            return sak.ToString();
                        }
                        catch
                        {
                            try_again(data_type);
                        }

                    }


            }
            
        }
        */

        //Uppgift 1 & 3
        static void mean()
        {
            Console.WriteLine("Hur många tal vill du mata in?");
            int amount = Convert.ToInt32(Console.ReadLine());
            int sum, max, min, answer;
            sum = max = min = 0;


            for (int n = 1; n <= amount; n++)
            {

                Console.WriteLine("Mata in tal {0}", n);
                answer = Convert.ToInt32(Console.ReadLine());

                sum += answer;
                // Det finns ingen idé att komma ihåg alla tal utan bara det minsta, största samt summan av talen. Därför används ingen lista. 
                if (answer > max)
                {
                    max = answer;
                }
                // För att få en utgångspunkt sätts det första talet som en referenspunkt, sedan jämförs resten av talen tills det hittas ett mindre tal.
                if (answer < min || n == 1)
                {
                    min = answer;
                }
            }
            // Math.Round tar in två parametrar. Ett flyt tal och antal decimaler, därav står tvåan där den står.
            Console.WriteLine("Medelvärdet av talen är {0} \nDet minsta talet är: {1}\nDet största talet är: {2}", Math.Round(sum / (double)amount, 2), min, max);
            Console.ReadKey();
        }

        //Uppgift 2
        static void dice()
        {
            int rollnr, spelare1, spelare2;
            rollnr = spelare1 = spelare2 = 0;
            Random rand = new Random(); 
            
            while (rollnr < 7)
            {
                //temp sparar slaget temporärt för att visa användaren vad den slagit. Samt kunna spara slaget för att lägga till i totalen.
                int temp;
                rollnr++;

                if (rollnr % 2 == 0)
                {
                    temp = rand.Next(1, 7);
                    spelare1 += temp;
                    Console.WriteLine("Spelare 1 slog: {0} och har totalt {1}", temp, spelare1);
                }

                else
                {
                    temp = rand.Next(1, 7);
                    spelare2 += temp;
                    Console.WriteLine("Spelare 2 slog: {0} och har totalt {1}", temp, spelare2);
                }
                Console.ReadKey();
            }
            Console.WriteLine("Spelare 1: fick totalt {0} poäng\nSpelare 2 fick totalt {1} poäng.",spelare1,spelare2);
            if (spelare1 > spelare2)
            {
                Console.WriteLine("Spelare 1 vann");
            }
            else if (spelare2 > spelare1)
            {
                Console.WriteLine("Spelare 2 vann");
            }
            else
            {
                Console.WriteLine("Båda fick lika mycket poäng!");
            }
            Console.ReadKey();
        }
        //Uppgift 4 a)
        static void star_pyramid()
        {
            Console.WriteLine("Hur många rader?");
            int rows = Convert.ToInt32(Console.ReadLine());
            // for layer in range(1, rows+1):
            for (int layer = 1; layer <= rows; layer++)
            {

                string row = new string('*', layer);

                Console.WriteLine("{0}: {1}", layer, row);

            }
            Console.ReadKey();
        }
        // Uppgift 4 b)

        static void number_pyramid()
        {
            Console.WriteLine("Hur många rader?");
            int rows = Convert.ToInt32(Console.ReadLine());
            for (int layer = 1; layer <= rows; layer++)
            {
                //Skriver numren på samma rad tills loopen tar slut. Då avslutas med en newline..
                for (int mod = 1; mod <= layer; mod++)
                {
                    Console.Write("{0}\t", mod * layer);
                }
                Console.Write("\n");
            }
            Console.ReadKey();
        }
        static void rectangle()
        {
            Console.WriteLine("Tryck 1 om kvadraterna ska skrivas ut lodrätt annars tryck valfri knapp");
            string choice = Console.ReadKey().Key.ToString();

            Console.WriteLine("Hur många rektanglar?");
            int amount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Hur höga är rektanglarna?");
            int height = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Hur breda är rektanglarna?");
            int width = Convert.ToInt32(Console.ReadLine());
            if (choice == "D1")
            {
                string row = new string('#', width);
                row += "\n";
                for (int i = 0; i < amount; i++)
                {
                    //Upprepar "row" så att det bildas "amount" stycken kvadrater med bredden "row" och höjden "height".
                    Console.WriteLine(String.Concat(Enumerable.Repeat(row, height)));
                }
            }
            else
            {   //row är ett lager av en rektangel
                string row = new string('#', width);

                string big_row = "";

                //big_row är ett vägrätt lager av alla kvadrater. 
                for (int i = 0; i < amount; i++)
                {
                    big_row += row + " ";
                }
                //bygger rektanglarna lager för lager height ggr.
                for (int layer = 0; layer < height; layer++)
                {
                    Console.WriteLine("{0}", big_row);
                }


            }

            Console.ReadKey();


        }
    }

}
