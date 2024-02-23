using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dice_for_pirates_last
{
    internal class game
    {
        
        player user = new player(true);
        player comp = new player(false);

        public game()
        {//setup
            Random random = new Random();
            Console.WriteLine("setting up your cup....rolling the dice...here are your dice:");
            user.shake();
            user.displayValues();



        }

        public void gamePlay(int i, ref int compscore, ref int userscore)
        {
            user.shake();
            comp.shake();
            bool playRound;

            
            playRound = true;
            string choice;
            choice = "bid";
            while (playRound)
            {

                if (choice != "bid")
                {
                    Console.WriteLine("bid or call liar?");
                    choice = Console.ReadLine();
                }

                if (choice == "bid")
                {
                    user.Userbid();
                    Console.WriteLine("It is now the computer's turn...");
                    Console.WriteLine("computer is playing...");
                    bool win = comp.compBidOrChooseLiar(user.getFaceBid, user.getNumBid, user.getMyCup, ref compscore, ref playRound);
                    if (win)
                    {
                        userscore++;
                        playRound = false;
                    }
                    choice = "0";
                    
                }
                else if (choice == "liar")
                {
                    playRound = false;
                    Console.WriteLine("comps numBid" + comp.getNumBid);
                    bool win = user.callLiar(comp.getFaceBid, comp.getNumBid, comp.getMyCup);
                    if (win)
                    {
                        userscore++;
                    }
                    else
                    {
                        compscore++;
                    }
                    playRound = false;
                }
            }



        }

    }
}
