using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRoad
{
    class Encounters
    {
        static Random rand = new Random();

        public static void WillYouFightEncounter()
        {
            string decision;
            Console.WriteLine("As you walk with your son side by side, you can hear noises. \nYou have to decide if you are going to run & hide, or fight the enemy.\n(F)ight | (R)un");
            do
            {
                decision = Console.ReadLine();
                if (decision.ToLower() == "fight" || decision.ToLower() == "f")
                {
                    Console.WriteLine("While your son is reluctant, you decide to step forward and face the stranger.\nPress any key to start the battle. . .");
                    Console.ReadKey();
                    Console.Clear();
                    Combat(true, 0, 0);
                }
                else if (decision.ToLower() == "run" || decision.ToLower() == "r")
                {
                    Console.WriteLine("You grab your son by the hand, and slowly avoid the enemy");
                    Console.WriteLine("Press any key to continue. . .");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
            }
            while (decision.ToLower() != "fight" || decision.ToLower() != "f" || decision.ToLower() != "r" || decision.ToLower() != "run");
        }

        //Encounter tools
        public static void Combat(bool random, int enemyPower, int enemyHealth)
        {
            
            if (random)
            {
                enemyPower = rand.Next(1, 6);
                enemyHealth = Program.currentPlayer.Difficulty(Program.currentPlayer.difficulty);
            }
            while((enemyHealth > 0) && (Program.currentPlayer.health > 0))
            {
                Console.WriteLine("================================");
                Console.WriteLine("|    (A)ttack       (D)efend   |");
                Console.WriteLine("|    (H)eal         (R)un      |");
                Console.WriteLine("================================");
                Console.WriteLine($"     Health: {Program.currentPlayer.health}      Enemy: {enemyHealth}");
                Console.WriteLine("================================");
                string input = Console.ReadLine();
                Console.Clear();
                if((input.ToLower() == "a") || (input.ToLower() == "attack"))
                {
                    //attack
                    int attackFirst = rand.Next(0, 2);
                    int damDealt = 0;
                    if (attackFirst == 0)
                    {
                        Console.WriteLine($"You are faster and attack your enemy with your {Program.currentPlayer.weapon}.");
                        damDealt = Program.currentPlayer.damage + rand.Next(0, 3);
                        Console.WriteLine($"You dealt {damDealt} damage.");
                        enemyHealth -= Program.currentPlayer.damage; // see here
                        if (enemyHealth <= 0)
                        {
                            Console.WriteLine("Your enemy is defeated");
                            Console.WriteLine("================================");
                            Console.WriteLine($"     Health: {Program.currentPlayer.health}      Enemy: 0");
                            Console.WriteLine("================================");
                        }
                        else
                        {
                            if(enemyPower - Program.currentPlayer.armorValue <= 0)
                            {
                                Console.WriteLine("The attack of the opponent is too weak. It dealt no damage.");
                            }
                            else
                            {
                                Console.WriteLine($"Your enemy attacks and deals {enemyPower - Program.currentPlayer.armorValue} damage");
                                Program.currentPlayer.health = Program.currentPlayer.health - (enemyPower - Program.currentPlayer.armorValue);
                            }
                        }
                    }
                    else if (attackFirst == 1)
                    {
                        Console.Write($"The enemy is faster and attacks first. ");
                        if (enemyPower - Program.currentPlayer.armorValue <= 0)
                        {
                            Console.WriteLine("The attack of the opponent is too weak. It dealt no damage.");
                        }
                        else
                        {
                            Console.WriteLine($"The enemy deals {enemyPower - Program.currentPlayer.armorValue} damage.");
                            Program.currentPlayer.health = Program.currentPlayer.health - (enemyPower - Program.currentPlayer.armorValue);
                        }
                        if (Program.currentPlayer.health <= 0)
                        {
                            Console.WriteLine("You died... While laying on the ground you can hear the screams of your son...");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"You attack your enemy with your {Program.currentPlayer.weapon}.");
                            damDealt = Program.currentPlayer.damage + rand.Next(0, 3);
                            Console.WriteLine($"You dealt {damDealt} damage.");
                            enemyHealth -= damDealt;
                            if (enemyHealth <= 0)
                            {
                                Console.WriteLine("Your enemy is defeated");
                                Console.WriteLine("================================");
                                Console.WriteLine($"     Health: {Program.currentPlayer.health}      Enemy: 0");
                                Console.WriteLine("================================");
                            }
                        }
                    }
                }
                //DEFEND
                else if((input.ToLower() == "d") || (input.ToLower() == "defend"))
                {
                    Console.Write("You try to defend yourself. ");
                    if (enemyPower - Program.currentPlayer.armorValue <= 0)
                    {
                        Console.WriteLine("The attack of the opponent is too weak. It dealt no damage.");
                    }
                    else
                    {
                        Console.WriteLine($"Your enemy attacks and deals {(enemyPower - Program.currentPlayer.armorValue)/2} damage");
                        Program.currentPlayer.health -= ((enemyPower - Program.currentPlayer.armorValue)/2);
                    }
                }
                //HEAL
                else if ((input.ToLower() == "h") || (input.ToLower() == "heal"))
                {
                    Console.WriteLine("With one hand you try to reach the:\n");
                    Console.WriteLine("=================================");
                    Console.WriteLine($"(C)ans: {Program.bag.cans} | (W)ater: {Program.bag.bottles} | (E)xit |"); 
                    Console.WriteLine("=================================");
                    string heal = Console.ReadLine();
                    Console.Clear();//ERROR
                    for (; ; )
                    {
                        if(heal == "c" || heal == "cans" || heal == "w" || heal == "water" || heal == "e" || heal == "exit")
                        { 
                            break; 
                        }
                        else
                        {
                            Console.WriteLine("Please provide a valid action");
                            heal = Console.ReadLine();
                        }
                    }
                    //for so when it hits break it ends the loop
                    for (; ; )
                    {
                        if ((heal.ToLower() == "c") || (heal.ToLower() == "cans"))
                        {
                            if (Program.bag.cans > 0)
                            {
                                Console.WriteLine("You open the can and hastily eat the food inside. You regain some of your health");
                                if (Program.currentPlayer.health + 5 > Program.currentPlayer.maxHealth)
                                {

                                    Program.currentPlayer.health = Program.currentPlayer.maxHealth;
                                }
                                else
                                {
                                    Program.currentPlayer.health += 5;
                                }
                                Program.bag.cans -= 1;
                            }
                            else
                            {
                                Console.WriteLine("As you desperately grasp for a can in your bag, all you can find are useless utensils.");
                            }
                        }
                        else if ((heal.ToLower() == "w") || (heal.ToLower() == "water"))
                        {
                            if (Program.bag.bottles > 0)
                            {
                                Console.WriteLine("You open the bag and hastily drink the bottle of water. You regain a bit of your health");
                                Program.currentPlayer.health += 2;
                                if (Program.currentPlayer.health > Program.currentPlayer.maxHealth)
                                {
                                    Program.currentPlayer.health = Program.currentPlayer.maxHealth;
                                }
                            }
                            else
                            {
                                Console.WriteLine("As you desperately grasp for a bottle in your bag, all that you feel are empty bottles of water.");
                            }
                            Program.bag.bottles -= 1;
                        }
                        else if ((heal.ToLower() == "e") || (heal.ToLower() == "exit"))
                        {
                            break;
                        }
                        Console.WriteLine("Your enemy attacked. ");
                        if (enemyPower - Program.currentPlayer.armorValue <= 0)
                        {
                            Console.WriteLine("The attack of the opponent is too weak. It dealt no damage.");
                        }
                        else
                        {
                            Console.WriteLine($"Your enemy attacks and deals {(enemyPower - Program.currentPlayer.armorValue)} damage");
                            Program.currentPlayer.health -= ((enemyPower - Program.currentPlayer.armorValue));
                            break;
                        }
                    }
                }

                //RUN
                else if ((input.ToLower() == "r") || (input.ToLower() == "run"))
                {
                    if(rand.Next(1,3) == 1)
                    {
                        Console.WriteLine("You grabbed your son by the hand and ran away from the enemy. You remained hidden until you could no longer see or hear anything.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }    
                    else
                    {
                        Console.WriteLine("You tried to escape but your enemy was faster than you. By hitting you, you lost 1 health point.");
                        Program.currentPlayer.health -= 1;
                    }
                }
                if (Program.currentPlayer.health <= 0)
                {
                    Console.WriteLine("You died... While laying on the ground you can hear the screams of your son...");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                if(enemyHealth <= 0)
                {
                    int coins = rand.Next(2, 35);
                    Console.WriteLine($"You search the corpse and you salvage {coins} coins");
                    Program.currentPlayer.coins += coins;
                    Console.ReadKey();
                    Console.Clear();

                }
            }
        }
    }
}
