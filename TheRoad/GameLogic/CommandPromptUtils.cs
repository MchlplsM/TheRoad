using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRoad.GameLogic
{
    class CommandPromptUtils
    {
        //CONSTRUCTOR
        public CommandPromptUtils()
        { }
        //METHOD
        public void Start()
        {
            Console.WriteLine("The Road by CORMAC MCCARTHY");
            for (; ; )
            {
                Console.Write("Please enter your name: ");
                Program.currentPlayer.name = Console.ReadLine();
                if (Program.currentPlayer.name != "")
                {
                    break;
                }
            }
            Console.Clear();

            Console.WriteLine("- Please select the difficulty -\n1 - Easy\n2 - Normal\n3 - Survival");
            for (; ; )
            {
                Program.currentPlayer.difficulty = Convert.ToInt32(Console.ReadLine());
                if (Program.currentPlayer.difficulty == 1 || Program.currentPlayer.difficulty == 2 || Program.currentPlayer.difficulty == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Let the Journey begin.");
                    Console.ReadKey();
                    break;
                }
            }
            Console.Clear();
            Program.narrative.Story();
        }
        
    }
}
