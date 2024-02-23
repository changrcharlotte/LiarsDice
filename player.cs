using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dice_for_pirates_last
{
    internal class player
    {
        private bool human;
        private int numBid;
        private int faceBid;
        //private int realNum, realFace;
        cup myCup = new cup();

        public player(bool human)
        {
            this.human = human;

        }

        public int getNumBid
        {
            get { return numBid; }
        }
        public int getFaceBid
        {
            get { return faceBid; }
        }

        public cup getMyCup
        {
            get { return myCup; }
        }
        public void Userbid()
        {
            bool go = true;
            while (go)
            {

                Console.WriteLine("What is the face value you are biddling?");
                string fNum = Console.ReadLine();
                if (int.TryParse(fNum, out faceBid))
                {
                    Console.WriteLine("what is the minimum number of dice you believe are being shown?");
                    string dNum = Console.ReadLine();
                    if (int.TryParse(dNum, out numBid))
                    {
                        go = false;
                    }

                }
            }
        }

        public bool callLiar(int compFaceBid, int compNumBid, cup compCup)
        {

            Console.WriteLine("the user has called Liar!, these are the values on the table");
            compCup.displayValues();
            myCup.displayValues();


            int numCount = 0;
            for (int i = 0; i < 5; i++)
            {

                dice item = myCup[i];
                if (item.getFaceValue == compFaceBid)
                {
                    numCount++;
                }

                dice compItem = compCup[i];
                if (compItem.getFaceValue == compFaceBid)
                {
                    numCount++;
                }
            }

            Console.WriteLine("total number of " + compFaceBid + "= " + numCount);

            if (numCount <= compNumBid)
            {
                Console.WriteLine("the computer's bid was correct, so they win this round!");
                return false;
            }
            else if (numCount > compNumBid) 
            {
                

                Console.WriteLine("you are right, so you win this round!");
                return true;
            }
            

        }

        public void shake()
        {
            myCup.shake();
        }


        public void displayValues()
        {
            myCup.displayValues();
        }

        public bool compBidOrChooseLiar(int userFaceBid, int userNumBid, cup UserCup, ref int compscore, ref bool playRound) 
        {
            double prob = 0;
            
            for (int i = userNumBid; i < 10; i++)
            {
                prob = prob + binomialProbability(i);

            }

            if (prob > 0.2)
            {
                Random random = new Random();
                if (random.Next(0, 2) == 0|| userFaceBid >= 6)
                {
                    numBid = userNumBid + 1;
                    faceBid = userFaceBid;
                    Console.WriteLine("the computer has bidded " + numBid + " of  face:" + faceBid);

                    
                }
                else
                {
                    faceBid = userFaceBid + 1;
                    numBid = userNumBid;
                    Console.WriteLine("the computer has bidded " + numBid + " of face:" + faceBid);
                }

                return false;
                
            }
            else
            {
                Console.WriteLine("the computer has called liar");
                Console.WriteLine("here are the values");
                UserCup.displayValues();
                myCup.displayValues();

                int numCount = 0;
                for (int i = 0; i < 5; i++)
                {

                    dice item = myCup[i];
                    if (item.getFaceValue == userFaceBid)
                    {
                        numCount++;
                    }

                    dice compItem = UserCup[i];
                    if (compItem.getFaceValue == userFaceBid)
                    {
                        numCount++;
                    }
                }


                if (numCount <= userNumBid)
                {
                    Console.WriteLine("the computer's bid was correct, so they win this round!");
                    playRound = false;
                    compscore++;

                    return false;
                    
                }
                else
                {
                    Console.WriteLine("you are right, so you win this round!");


                    return true;

                }


            }

        }
        public double binomialProbability(int r)
        {
            double p = 1.0 / 6.0;
            double q = 5.0 / 6.0;
            int n = 10;
            int ncr = calculateNcr(n, r);
            return ncr * Math.Pow(p, r) * Math.Pow(q, n - r);
        }

        public int calculateNcr(int n, int r)
        {
            if (r == 0 || n == r)
                return 1;
            else if (r == 1)
                return n;
            else
                return calculateNcr(n - 1, r - 1) + calculateNcr(n - 1, r);
        }
    }
}
