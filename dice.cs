using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dice_for_pirates_last
{
    internal class dice
    {
        private int face;
        private int numberOfSides = 6;

        public dice()
        {

        }

        public int getFaceValue
        {
            get { return face; }
        }


        public void roll()
        {
            Random rd = new Random();
            face = rd.Next(1, 7);

        }

        public void displayValues()
        {
            Console.WriteLine("face value is: " + this.face );

        }
    }
}
