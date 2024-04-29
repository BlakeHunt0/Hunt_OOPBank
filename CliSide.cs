//Blake Hunt
//IT 101
//NOTES:
//NOT IMPLIMENTED:

//requirements:
//  The bank class will not directly write or read from the user. Instead, all interactions with the user will be passed in and out via properties or methods.

//  The bank will have a singular one-argument constructor, which will accept the bank's initial balance.

//  The bank will have an balance of 1000, as passed in via the constructor.

//  When the program starts, a Bank object will be created. The bank object should be created only once and that instance should be used for the entire run of the application.

//  The class will be defined in it's own file called bank.

//  As the program starts, a menu should be offered allowing the choice of deposit, withdraw or check Balance, or Quit. After every choice that menu should be re-displayed.

//  Each time a deposit or withdrawal is performed, the resulting balance should be displayed to the user (screen).

//  If the bank's balance falls below zero, the withdrawal will be allowed, but the negative balance will be overridden and set to zero.

//  All money displayed will be in currency format.

//  Withdrawals of greater than 500 at one time are not allowed and will be capped automatically at 500.

//  Assume all user input is well-formed.

//  Name your project Lastname_OOPBank.

//  Post your code to a public GitHub URL and submit that URL to Canvas by deadline .

using System.Net.Quic;

namespace Blake_OOPBank
{
    internal class CliSide
    {
        static void Main(string[] args)
        {
            //menu booleans
            bool quit = false;

            //create new bank object (once at start)
            Bank Account = new Bank();

            do
            {
                //start menu
                Console.WriteLine("1.Deposit\n2.Withdraw\n3.Balance\n4.Quit");
                var menuInput = Console.ReadLine();

                //get bank info
                double newBalance = Account.Balance();

                //deposit
                if (menuInput == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Deposit Amount: ");
                    double da = double.Parse(Console.ReadLine());
                    Console.WriteLine(Account.Deposit(da));
                    newBalance = Account.Balance();
                    Console.Clear();
                    Console.WriteLine("Current Balance: ");
                    Console.Write(newBalance.ToString("C"));
                    Console.ReadLine();
                }
                //withdraw
                if (menuInput == "2")
                {
                    bool validwa = false;
                    while (validwa == false)
                    {
                        //Nothing to withdraw if balance is 0
                        if (newBalance <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("You have nothing to wthdraw");
                            Console.ReadLine();
                            Console.Clear();
                            validwa = true;
                        }
                        Console.Clear();
                        Console.WriteLine("Withdraw Amount: ");
                        double wa = double.Parse(Console.ReadLine());
                        // withwraw over 500
                        if (wa > 500)
                        {
                            Console.Clear();
                            Console.WriteLine("Max withdraw must be 500 or less");
                            Console.WriteLine("1. Default to 500 or 2. Withdraw different amount.");
                            menuInput = Console.ReadLine();
                            if (menuInput == "1")
                            {
                                Console.Clear();
                                Account.Withdraw(500);
                                newBalance = Account.Balance();
                                Console.Write(newBalance.ToString("C"));
                                Console.ReadLine();
                                validwa = true;
                            }
                        }
                        //acceptable withdraw
                        if (wa <= 500)
                        {
                            Console.Clear();
                            Account.Withdraw(wa);
                            newBalance = Account.Balance();
                            Console.WriteLine(newBalance.ToString("C"));
                            Console.ReadLine();
                            validwa = true;
                        }
                    }
                }
                //balance
                if (menuInput == "3")
                {
                    Console.Clear();
                    Console.WriteLine(newBalance);
                    Console.ReadLine();
                    Console.Clear();
                }
                //quit
                if (menuInput == "4")
                {
                    quit = true;
                }
                Console.Clear();

            } while (quit == false);
        }
    }
}
