using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static console.ATMSystem;
using System.Security.Cryptography;

namespace console
{
   
    class ATMSystem
    {

        public static void Main()
        {
            Entrance();

            static void Entrance()
            {
                Console.WriteLine("**************Welcome to XOX Bank*****************");
                Console.WriteLine("    Please choose your process that you want.     ");
                Console.WriteLine($"    1) Withdrawal               2) Deposit \n    3) Balance Inquiry          4) Eject card    ");

                byte option = Convert.ToByte(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        withdrawal();
                        break;
                    case 2:
                        deposit();
                        break;
                    case 3:
                        balanceInquiry();
                        break;
                    case 4:
                        ejectCard();
                        break;
                    default:
                        Console.WriteLine("Please enter true option");
                        break;


                }
                Console.Clear();
            }

            static void withdrawal()
            {
                var cardInfo = new CardInfo();

                Console.WriteLine($"${cardInfo.cardAmount} in your bank account");
                Console.WriteLine("Please enter the amount you want to withdraw");
                ulong withdrawed = ulong.Parse(Console.ReadLine());

                ulong remainingMoney = ulong.Parse(cardInfo.cardAmount) - withdrawed;
                File.WriteAllText("C:\\Users\\Deniz\\Desktop\\apps\\Coding\\frameworkconsole\\console\\card.txt", Convert.ToString(remainingMoney));
                Console.WriteLine($"Here your money... Remaining money is ${remainingMoney}");

                Task.Delay(2000).Wait();
                Console.WriteLine($"If you want to make this process again press \"w\", if you want to go to menu press any button ");
                string decision = Console.ReadLine();

                Console.Clear();

                if (decision == "w")
                {
                    withdrawal();
                }
                else 
                {
                    Entrance();
                }
                

                Console.Clear();
            }

            static void deposit()
            {
                var cardInfo = new CardInfo();

                Console.WriteLine($"${cardInfo.cardAmount} in your bank account");
                Console.WriteLine("Please enter the amount you want to deposit.(Maximum amount is $5000)");
                ulong deposited = ulong.Parse(Console.ReadLine());

                ulong totalMoney = ulong.Parse(cardInfo.cardAmount) + deposited;
                File.WriteAllText("C:\\Users\\Deniz\\Desktop\\apps\\Coding\\frameworkconsole\\console\\card.txt", Convert.ToString(totalMoney));
                Console.WriteLine($"Your money is deposited... Total money is ${totalMoney}");

                Task.Delay(2000).Wait();
                Console.WriteLine($"If you want to make this process again press \"d\", if you want to go to menu press any button");
                string decision = Console.ReadLine();

                Console.Clear();

                if (decision == "d")
                {
                    deposit();
                }
                else
                {
                    Entrance();
                }
            }

            static void balanceInquiry()
            {
                var cardInfo = new CardInfo();
                Console.WriteLine($"Your balance is ${cardInfo.cardAmount}");
                Console.WriteLine("Press \"m\" to go back to menu. ");
                string back = Console.ReadLine();

                Console.Clear();

                switch (back)
                {
                    case "m":
                        Entrance();
                        break;
                }
            }

            static void ejectCard()
            {
                Environment.Exit(0);
            }

            
        }





        public class CardInfo
        {
            public static string card = "C:\\Users\\Deniz\\Desktop\\apps\\Coding\\frameworkconsole\\console\\card.txt";

            public string cardAmount = File.ReadAllText(card);

        }

    }
}
