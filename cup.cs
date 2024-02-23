using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dice_for_pirates_last
{
    internal class cup
    {
        private List<dice> cupOfDice = new List<dice>();
        private object get;

        public cup()
        {

        }


        public dice this[int i]//returns a single value in the cup
        {
            get { return cupOfDice[i]; }
        }




        public void shake()
        {
            for (int i = 0; i < 5; i++)
            {
                dice Dice = new dice();
                Dice.roll();
                cupOfDice.Add(Dice);

            }
        }

        public void displayValues()
        {
            for (int i = 0; i < 5; i++)
            {
                int num = i + 1;
                dice currentDice = cupOfDice[i];
                currentDice.displayValues();
            }
        }
    }
}
