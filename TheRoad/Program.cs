using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRoad.GameLogic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TheRoad
{
    class Program
    {
        public static Player currentPlayer = new Player();
        public static Narrative narrative = new Narrative();
        public static Encounters encounter = new Encounters();
        public static CommandPromptUtils cputils = new CommandPromptUtils();
        public static Inventory bag = new Inventory();
        static void Main(string[] args)
        {
            cputils.Start();

        }
        
    }
}
