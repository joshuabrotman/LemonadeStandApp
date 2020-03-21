using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LemonadeStand_3DayStarter
{
    class Game
    {
        public int hours =0;
        public int minutes =0;
        public int seconds = 0;
        public int days = 0;

        public void BuyItems()
        {

        }
        public void BeginGame()
        {
            string currentDay ="";
            //visit store/inventory
            //control quality/recipe and price

            //main game loop

            while(currentDay != "sunday")
            {
                DisplayStats();
                UpdateTime();

            }



        }

        public void DisplayStats()
        {
            Console.Write("Inventory | Sales      | Time       | Weather   | Recipe   | Price | Wallet \n");
            Console.Write("          |            |            |           |          |       |        \n");
            Console.Write("          |            |            |           |          |       |        \n");
            Console.Write("          |            |            |           |          |       |        \n");
            Console.Write("          |            |            |           |          |       |        \n");
            Console.Write("          |            |            |           |          |       |        \n");

            

        }

        public void UpdateTime()
        {
            
            for (int i =0; i < 7; i++)
            {
                for(int j=0; j < 24; j++)
                {
                    for(int h=0; h < 60; h++)
                    {
                        for(int l = 0; l<60; l++)
                        {
                            Console.SetCursorPosition(25, 3);
                            Console.Write(hours + ":" + minutes + ":" + seconds);
                            Console.SetCursorPosition(25, 4);
                            Console.Write("Days: " + days);
                            Thread.Sleep(2);
                            seconds+=50;
                        }
                        minutes+=5;
                        seconds = 0;
                    }
                    hours++;
                    minutes = 0;
                }
                days++;
                hours = 0;
            }
            
        }
    }
}
