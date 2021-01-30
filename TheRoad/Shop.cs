using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRoad
{
    class Shop 
    {
        static int armorUpgrade;
        static Random rand = new Random();
        static Player currentPlayer = new Player();
        public static Inventory bag = new Inventory();
        static string[] listOfWeapons = { "Dagger", "Pistol" };
        public static void LoadShop()
        {
            armorUpgrade = Program.currentPlayer.armorValue;
            int amountOfCans = rand.Next(0, 5);
            int amountOfBottles = rand.Next(0, 5);
            int amountOfRounds = rand.Next(0, 12);
            string weapon = listOfWeapons[rand.Next(0, 2)];
            RunShop(amountOfCans, amountOfBottles, amountOfRounds, weapon, currentPlayer);
        }
        public static void RunShop(int amountOfCans, int amountOfBottles, int amountOfRounds, string weapon, Player currentPlayer)
        {
            while(true)
            {
                int cansPrice = (10 * Program.currentPlayer.difficulty); //price
                int bottlesPrice = (5 * Program.currentPlayer.difficulty); //price
                int GrenadesPrice = (15 * Program.currentPlayer.difficulty); //price
                int roundsPrice = (5 * Program.currentPlayer.difficulty); //price

                Console.WriteLine("              SHOP              ");
                Console.WriteLine("================================");
                Console.WriteLine("|    (F)ood       (A)mmunition  |"); //ADD DAGGER AND PISTOL!!!
                Console.WriteLine("|    (W)eapon     (E)xit        |");
                Console.WriteLine("================================");
                string input = Console.ReadLine();
                Console.Clear();
                if ((input.ToLower() == "f") || (input.ToLower() == "food"))
                {
                    Console.WriteLine("You want food & water? I have these my friend:\n");
                    Console.WriteLine("===========================");
                    Console.WriteLine($"(C)ans: {amountOfCans} | (W)ater: {amountOfBottles}");
                    Console.WriteLine($"(E)xit    | (M)oney: {Program.currentPlayer.coins}");
                    Console.WriteLine("===========================");
                    string answer = Console.ReadLine();
                    Console.Clear();
                    for (; ; )
                    {
                        if (answer.ToLower() == "c" || answer.ToLower() == "cans" || answer.ToLower() == "w" || answer.ToLower() == "water" || answer.ToLower() == "e" || answer.ToLower() == "exit")
                        { 
                            if(answer.ToLower() == "c" || answer.ToLower() == "cans")
                            {
                                if (Program.currentPlayer.coins - cansPrice < 0)
                                {
                                    Console.WriteLine("You do not have enough money.");
                                }
                                else
                                {
                                    if(amountOfCans > 0)
                                    {
                                        Program.currentPlayer.coins -= cansPrice;
                                        bag.cans += 1;
                                        Console.WriteLine($"You purchased 1 can for {cansPrice} coins. You have a total of {Program.bag.cans} cans");
                                        amountOfCans -= 1;
                                    }
                                    else
                                    {
                                        Console.WriteLine("I am out of cans. Stop asking for these.");
                                    }
                                }
                            }
                            else if (answer.ToLower() == "w" || answer.ToLower() == "water")
                            {
                                if (Program.currentPlayer.coins - bottlesPrice < 0)
                                {
                                    Console.WriteLine("You do not have enough money.");
                                }
                                else
                                {
                                    if (amountOfCans > 0)
                                    {
                                        Program.currentPlayer.coins -= bottlesPrice;
                                        bag.bottles += 1;
                                        Console.WriteLine($"You purchased 1 bottle of water for {bottlesPrice} coins. You have a total of {Program.bag.bottles} water bottles.");
                                        amountOfBottles -= 1;
                                    }
                                    else
                                    {
                                        Console.WriteLine("I am out of water. Apologies.");
                                    }
                                }
                            }
                            break; 
                        }
                        else
                        {
                            Console.WriteLine("Please provide a valid action");
                            answer = Console.ReadLine();
                        }
                    }
                }
                else if(input.ToLower() == "a" || input.ToLower() == "ammunition")
                {
                    for (; ; )
                    {
                        Console.WriteLine("You want Ammunition? Let's see what I have for you:\n");
                        Console.WriteLine("===========================");
                        Console.WriteLine($"(R)ounds: {amountOfRounds} | (S)tock: {bag.bullets}");
                        Console.WriteLine($"(E)xit      | Money: {Program.currentPlayer.coins}");
                        Console.WriteLine("===========================");
                        string answer = Console.ReadLine();
                        Console.Clear();
                        //--------------------------------------------------------------------------------------------
                        TryToBuy(answer, "round", roundsPrice, currentPlayer, amountOfRounds);
                        if (answer.ToLower() == "r" || answer.ToLower() == "rounds" || answer.ToLower() == "round" || answer.ToLower() == "e" || answer.ToLower() == "exit")
                        {
                            if (answer.ToLower() == "r" || answer.ToLower() == "round" || answer.ToLower() == "rounds")
                            {
                                if (Program.currentPlayer.coins - roundsPrice < 0)
                                {
                                    Console.WriteLine("You do not have enough money.");
                                }
                                else
                                {
                                    if(amountOfRounds > 0)
                                    {
                                        Console.WriteLine($"You purchased 1 bullet for {roundsPrice} coins");
                                        Program.currentPlayer.coins -= roundsPrice;
                                        bag.bullets += 1;
                                        amountOfRounds -= 1;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Such a pitty. I am now out of rounds.");
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
                else if (input.ToLower() == "w" || input.ToLower() == "weapon")
                {
                    for (; ; )
                    {
                        int priceOfWeapon;
                        Console.WriteLine("You want Weapons? Let's see what I have for you:\n");
                        Console.WriteLine("=====================================");
                        Console.WriteLine($"(W)eapon : {weapon} | Current Weapon: {Program.currentPlayer.weapon}");
                        Console.WriteLine($"(G)reande      | ");
                        Console.WriteLine($"(E)xit         | Money: {Program.currentPlayer.coins}");
                        Console.WriteLine("=====================================");
                        string answer = Console.ReadLine();
                        Console.Clear();
                        if (answer.ToLower() == "w" || answer.ToLower() == "weapon" || answer.ToLower() == "g" || answer.ToLower() == "grenade" || answer.ToLower() == "e" || answer.ToLower() == "exit")
                        {
                            if (answer.ToLower() == "w" || answer.ToLower() == "weapon")
                            {
                                Console.WriteLine($"I have a {weapon}");
                                if (weapon == "Dagger")
                                {
                                    priceOfWeapon = 50;
                                }
                                else
                                {
                                    priceOfWeapon = 200;
                                }
                                if (Program.currentPlayer.coins - priceOfWeapon < 0)
                                {
                                    Console.WriteLine("You do not have enough money.");
                                }
                                else
                                {
                                    Console.WriteLine($"You purchased a {weapon} for {priceOfWeapon} coins");
                                    Program.currentPlayer.coins -= roundsPrice;
                                    bag.bullets += 1;
                                }
                            }
                            else if(answer.ToLower() == "g" || answer.ToLower() == "grenade")
                            {
                                if (Program.currentPlayer.coins - GrenadesPrice < 0)
                                {
                                    Console.WriteLine("You do not have enough money.");
                                }
                                else
                                {
                                    Console.WriteLine($"You purchased a Grenade for {GrenadesPrice} coins");
                                    Program.currentPlayer.coins -= GrenadesPrice;
                                    bag.bullets += 1;
                                }
                            }
                            break;
                        }
                    }
                }
                else if (input.ToLower() == "e" || input.ToLower() == "exit")
                {
                    Console.WriteLine("Thanks for stopping by. Who knows, maybe we'll meet again. Hopefully both of you will still be alive.");
                    Console.WriteLine("If not, you know who's going to scavenge you. Hahaha");
                    Console.WriteLine("Press any button to continue. . .");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
            }
        }

        static void TryToBuy(string answer, string item, int cost, Player currentPlayer, int amountAvailable)
        {
            string x = Convert.ToString(answer.ToCharArray()[0]);
            if (answer.ToLower() == x || answer.ToLower() == item || answer.ToLower() == item || answer.ToLower() == "e" || answer.ToLower() == "exit")
            {
                if (Program.currentPlayer.coins - cost < 0)
                {
                    Console.WriteLine("You do not have enough money.");
                }
                else
                {
                    if (amountAvailable > 0)
                    {
                        Console.WriteLine($"You purchased 1 {item} for {cost} coins");
                        Program.currentPlayer.coins -= cost;
                        bag.bullets += 1;
                        amountAvailable -= 1;
                    }
                    else
                    {
                        Console.WriteLine($"Such a pitty. I am now out of {item}s.");
                    }
                    
                }
            }
        }

    }
}
