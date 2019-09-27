
using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameExam
{
    class Program
    {
        
       
        static void Main(string[] args)
        {


            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("This is Poker Game Simulation Created Using Windows Console App ");
            Console.WriteLine("If you want to try, kindly type Yes or if you want to see generated");
            Console.WriteLine("game, kindly type no, Thank You and Enjoy");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine();
            string willPlay = Console.ReadLine();
            string response = willPlay.ToLower();
            if(response =="yes")
            {
                // PlayPoker();
                GameProper.PlayPoker();
            }
            if(response == "no")
            {
                GeneratedGame.PlayAutomatedGame();
            }

        }      

       
    }
}
