using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labben
{
    class Program
    {
        static void Main(string[] args) 
        {
            double pengar;
            int moneyfrom;
            int moneyto;

            if (args.Count() == 3)
            {
                Console.WriteLine("Belopp" + args[0]);
                pengar = double.Parse(args[0]);
                Console.WriteLine("Från: " + args[1]); 
                moneyfrom = StringToIntMeny(args[1]);
                Console.WriteLine("Till: " + args[2]);
                moneyto = StringToIntMeny(args[2]);
            }
            
            else
            {
                Console.WriteLine("Välj den valuta du har:  ");
                moneyfrom = ValValutor();
                Console.WriteLine("Välj valuta du vill växla till:   ");
                moneyto = ValValutor();
                Console.WriteLine("Ange beloppet du vill växla");
                pengar = MoneyIn();
            }
            double NewMoney = Moneychange(moneyfrom, moneyto, pengar);

            Console.WriteLine("Du ska få tillbaka: ");

            if (moneyto == 1)//SEK
            {
                string valuta = "SEK";
                double[] Sedlar = { 500, 100, 50, 20, 10, 1 };
                double newmoney = Math.Round(NewMoney);
                ValUtorna(newmoney, Sedlar, valuta);                
            }
            else if (moneyto == 2)//Euro
            {
                string valuta = "EUR";
                double[] Euro = { 500, 200, 100, 50, 20, 10, 5, 2, 1, 0.50d, 0.20d, 0.10d, 0.05d, 0.02d, 0.01d };
                ValUtorna(NewMoney, Euro, valuta);
            }
            else if (moneyto == 3)//USD
            {
                string valuta = "USD";
                double[] Dollar = { 100, 50, 20, 10, 5, 2, 1, 0.50d, 0.25d, 0.10d, 0.05d, 0.01d };
                ValUtorna(NewMoney, Dollar, valuta);
            }
            else
            {
                Environment.Exit(0);
            }
            Console.ReadKey();
        }

        static int ValValutor() //Här är en metod som jag anropar varje gång man ska välja valuta
        {
            Console.WriteLine("Ange 1 = SEK");
            Console.WriteLine("Ange 2 = Euro");
            Console.WriteLine("Ange 3 = USD");
            int tal = int.Parse(Console.ReadLine());
            return tal;      
        }

        static double MoneyIn() // I denna metod ska jag ange hur mycket jag vill växla
        {
            string input = Console.ReadLine();
            if (!double.TryParse(input, out double belopp)) {
                Environment.Exit(0);
            }
            return belopp;
        }

        static int StringToIntMeny(string moneyfrom) // Metod till argument
        {

            if (moneyfrom == "SEK" || moneyfrom == "sek" )
            {
                return 1;
            }

            else if (moneyfrom == "EUR" || moneyfrom == "eur")
            {
                return 2;
            }

            else if (moneyfrom == "USD" || moneyfrom == "usd")
            {
                return 3;
            }

            else // om inget av ovan gäller körs denna
            {
                Environment.Exit(0);
                return 0;
            }
        }

        static double Moneychange(int MoneyFrom, int MoneyTo, double ValueToExchange) //Växla från
        {
            if (MoneyFrom == 1) // om jag vill växla från SEK
            {
                if (MoneyTo == 1)                //SEK
                    return (ValueToExchange);
                if (MoneyTo == 2)                // SEK till Euro
                    return (ValueToExchange / 9.48);
                if (MoneyTo == 3)                //SEK till USD
                    return (ValueToExchange /  8.08);
                else { return 0; }
            }

            else if (MoneyFrom == 2)//om jag vill växla från Euro
            {
                if (MoneyTo == 1)
                    return (ValueToExchange * 9.48); //SEK
                if (MoneyTo == 2)
                    return (ValueToExchange);//Euro
                if (MoneyTo == 3)
                    return (ValueToExchange / 0.85); //USD
                else { return 0; }
            }

            else if (MoneyFrom == 3)//om jag vill växla från USD
            {
                if (MoneyTo == 1)                    //SEK
                    return (ValueToExchange * 8.08);
                if (MoneyTo == 2)                    //EUR
                    return (ValueToExchange * 0.85);
                if (MoneyTo == 3)                    //USD
                    return (ValueToExchange);
                else { return 0; }
            }
            else
            { return 0; }
        }

        static void ValUtorna(double amount, double[] Sedlar, string valuta)//Beräknar valörer
        {
            int arrlen = Sedlar.Length - 1;
            int i = 0;
            double Avrundare = Math.Round(amount, 2); 

            Console.WriteLine("Belopp " + Avrundare);
            while (Avrundare >= Sedlar[arrlen])
            {
                int antalsedlar = 0;
               
                while (Avrundare >= Sedlar[i])
                {
                    Avrundare = Avrundare - Sedlar[i];             
                    antalsedlar++;                  
                }

                if (antalsedlar > 0)
                    
                {
                    if (Sedlar[i] >= 1)
                    {
                        Console.WriteLine("Ge " + antalsedlar + " st " + Sedlar[i] + " " + valuta);
                    }

                    else 
                    {
                        double centsedlar = Math.Round(Sedlar[i] * 100);
                        Console.WriteLine("Ge " + antalsedlar + " st " + centsedlar + " cent");
                    }
                }
                i++;
            }        
        }
    }
}