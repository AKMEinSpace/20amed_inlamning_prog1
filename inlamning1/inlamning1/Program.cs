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
            

            while (true) {
                Console.Clear();
                Console.WriteLine("Skriv in NUMRET före ditt val. \n1.  Uppgift 1\n2.   Uppgift 2\n3.   Uppgift 3");
                choice = Console.ReadKey();
                Console.WriteLine(choice.Key.ToString());
                if (quitConfirm(choice)){break;}
                switch (choice.Key.ToString())
                {
                    case "D1":
                        mean();
                        Console.Write("1");
                        break;
                    case "D2":
                        dice();
                        Console.Write("1");
                        break;
                    case "D3":
                        break;

                }
            }
        }

        static bool quitConfirm(ConsoleKeyInfo putPut)
        {
            Console.Clear();
            if (putPut.Key == ConsoleKey.Escape) {
                Console.WriteLine("Are you sure you want to quit? Y/n");
                ConsoleKeyInfo conf = Console.ReadKey();
                if (conf.Key.ToString().ToLower() == "y" || conf.Key == ConsoleKey.Enter || conf.Key == ConsoleKey.Escape)
                {
                    return true;
                }
            }
            return false;
        }

        static string try_again(string data_type)
        {
            Console.WriteLine("Det tal du matat in är inte rätt. Ska vara: {0} Försök igen!", data_type);
            string new_sak = Console.ReadLine();
            return new_sak;
        }

        //Felhanterings funktion som tar in datan som ska kollas så att det är rätt datatyp. Tar in data och data typ som input.
        static string felhantering(string  sak, string data_type)
        {
            bool is_right = true;
            switch (data_type)
            {
                case "heltal":
                    while (is_right){
                        if ()
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
       
        //Uppgift 1
        static void mean()
        {
            Console.WriteLine("Hur många tal vill du mata in?");
            int amount = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            string answer = "";

            for (int n = 0; n < amount; n++)
            {
                //Inmatning av talen 1 till amount.
                Console.WriteLine("Mata in tal " + (n+1));
                answer = Console.ReadLine();
                
                sum += Convert.ToInt32(answer);
            }
            // Math.Round tar in två parametrar. Ett flyt tal och antal decimaler, därav står tvåan där den står.
            Console.WriteLine("Medelvärdet av talen är " + Math.Round(sum / (double)amount, 2));
            Console.ReadKey();
        }
        static void dice()
        {

        }
        static void rectangle()
        {
            Console.WriteLine("Hur många rektanglar?");
            int amount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Hur höga är rektanglarna?");
            int height = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Hur breda är rektanglarna?");
            int width = Convert.ToInt32(Console.ReadLine());

            string row = new string('#', width);
            row += "\n";
            for (int i = 0; i < amount; i++)
            {
                //Upprepar "row" så att det bildas "amount" stycken kvadrater med bredden "row" och höjden "height".
                Console.WriteLine(String.Concat(Enumerable.Repeat(row, height)));
            }

            Console.ReadKey();


        }
    }

}
