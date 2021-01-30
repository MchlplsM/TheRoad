using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TheRoad
{
    class Narrative
    {
        string file = "deer.txt"; //could use -@- if i inserted full path or -\-
        public void Story ()
        {
            Narrative1();
            Encounters.WillYouFightEncounter();
            Shop.LoadShop();
            //Combat(false, 2, 10);
        }
        public void Narrative1()
        {
            if (File.Exists(file))
            {
                string str = File.ReadAllText(file);
                Console.WriteLine(str);
            }
            Console.WriteLine("You woke up in the woods in the dark. The cold of the night pierced your bones. Next to you, your son was sleeping.");
            Console.WriteLine("His breast rose and fell softly with each precious breath.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You couldn't sleep. You pushed away the blanket and looked toward the east for any light but there was none.");
            Console.WriteLine("You thought the month was October, but you weren't sure. You hadn't kept a calendar for years.");
            Console.WriteLine($"All you could clearly remember was that your name was {Program.currentPlayer.name} and you had a son. What the hell happened on earth?");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("The sun was finally up. When you returned from your morning scouting, the boy was already waiting for you.");
            Console.WriteLine("Hi Papa");
            Console.ReadKey();
            
            for (; ; )
            {
                Console.Clear();
                Console.WriteLine("DECISION          ");
                Console.WriteLine("==============================================");
                Console.WriteLine("|(A) Prepare yourself. It's not a safe place.|");
                Console.WriteLine("|(B) Are you hungry? We do have some cans.   |");
                Console.WriteLine("==============================================");
                string decision = Console.ReadLine();
                if(decision.ToLower() == "a")
                {
                    Console.Clear();
                    Console.WriteLine("10 minutes later you were on the road. Both you and the boy carried knapsacks and you also had a backpack.");
                    Console.WriteLine("You only carried essential things. Some cans and bottles of water along with two blankets to cover yourselves at night.");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("You crossed the river by an old concrete bridge and a few miles on you came upon a roadside gas station.");
                    //here
                    Console.Clear();
                    break;
                }
                else if(decision.ToLower() == "b")
                {
                    Console.Clear();
                    Console.WriteLine("Thank you Papa. Your son looked thinner and skinner as the days went by. A 10 year old boy that never had the chance to live.");
                    Console.WriteLine("He was born and raised in the wilderness.");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Had it not been for your son, you would most probably be dead by now. Not from someone else. But from yourself.");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("1 hour later you were on the road. Both you and the boy carried knapsacks and you also had a backpack.");
                    Console.WriteLine("You only carried essential things. Some cans and bottles of water along with two blankets to cover yourselves at night.");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("You crossed the river by an old concrete bridge and a few miles on you came upon a roadside gas station.");
                    Console.Clear();
                    break;
                }
            }
        }
    }
}
