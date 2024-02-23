namespace dice_for_pirates_last
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to liar's dice! we will play 3 rounds. whoever wins 2 rounds automatically wins the whole game.");
            int compscore = 0;
            int userscore = 0;

            bool play = true;
            int i = 1;
            while ( play && i<4)
            {
                Console.WriteLine("ROUND " + i);
                Console.WriteLine("comp score:" + compscore);
                Console.WriteLine("user score: " + userscore);
                game game = new game();
                game.gamePlay(i, ref compscore, ref userscore);
                i++;

                if (compscore == 2)
                {
                    play = false;
                    Console.WriteLine("sadly comp has won 2/3 rounds so comp automatically wins :((");

                }
                else if (userscore == 2)
                {
                    play = false;
                    Console.WriteLine("you have won 2/3 rounds so you win!");
                }
            }
            
            
        }
    }
}
