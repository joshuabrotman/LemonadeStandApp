﻿using System;
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
        public int raining;
        public int temperature;
        public int humidity;
        public static ConsoleKeyInfo key;
        public double drinkPrice;
        public int sugarCubesPerCup;
        public int iceCubesPerCup;
        public double lemonsPerCup;
        public int salesCount =0;
        public int sale;

        public Store NewStore = new Store();
        public Player NewPlayer = new Player();

        public void BuyItems()
        {
            
            NewStore.DisplayPrices();
            NewPlayer.DisplayWallet();
            NewStore.SellSugarCubes(NewPlayer);
            NewPlayer.DisplayWallet();
            NewStore.SellIceCubes(NewPlayer);
            NewPlayer.DisplayWallet();
            NewStore.SellLemons(NewPlayer);
            NewPlayer.DisplayWallet();
            NewStore.SellCups(NewPlayer);
            NewPlayer.DisplayWallet();
            Console.Clear();

        }
        public void BeginGame()
        {




            //visit store/inventory
            BuyItems();
            SetPrice();
            SetRecipe();
            Console.Clear();
            DisplayBoard();
            CustomerVisit();

            //control quality/recipe and price

            //main game loop

            while (days != 7)
            {



                for (int i = 0; i < 7; i++)
                {
                    //Beginning of the Day
                    UpdateWeather();
                    for (int j = 0; j < 24; j++)
                    {
                        for (int h = 0; h < 60; h++)
                        {
                            DisplayBoard();
                            for (int l = 0; l < 60; l++)
                            {

                                UpdateInventory();
                                DisplayWeather();
                                UpdateTime();
                                UpdateWallet();
                                DisplayDrinkPrice();

                                Thread.Sleep(0);
                                seconds++;

                                //detect input
                                IsKeyPressed();
                            }
                            minutes += 1;
                            seconds = 0;
                        }
                        hours++;
                        minutes = 0;
                    }
                    days++;
                    hours = 0;
                }
                Console.ReadKey();


            }



        }

        public void CustomerVisit()
        {
            if (MadeASale)
            {
                NewPlayer.inventory.lemons -= lemonsPerCup;
                NewPlayer.inventory.sugarCubes -= sugarCubesPerCup;
                NewPlayer.inventory.iceCubes -= iceCubesPerCup;
                NewPlayer.inventory.cups.Decrement;
            }
        }

        public bool MadeASale()
        {
            Random saleChance = new Random();
            sale = saleChance.Next(0, 100);
            if(sale >= 49) 
            {
                salesCount++;
                Console.SetCursorPosition(14, 3);
                Console.Write(salesCount);
                return true; 
            }
            return false;
        }

        public void SetPrice()
        {
            Console.Clear();
            Console.WriteLine("Please enter the price per cup: (00.25) ");
            drinkPrice = Convert.ToDouble(Console.ReadLine());
        }

        public void SetRecipe()
        {
            Console.Clear();
            Console.WriteLine("Please enter the lemons per cup: (as a decimal) ");
            lemonsPerCup = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter the sugar cubes per cup:");
            sugarCubesPerCup = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the ice cubes per cup:");
            iceCubesPerCup = Convert.ToInt32(Console.ReadLine());
        }

        public void DisplayDrinkPrice()
        {
            Console.SetCursorPosition(65, 2);
            Console.Write(drinkPrice);
        }

        public void UpdateInventory()
        {
            Console.SetCursorPosition(1, 2);
            Console.Write("Lemons: "+NewPlayer.inventory.lemons.Count());
            Console.SetCursorPosition(1, 3);
            Console.Write("Sugar: "+NewPlayer.inventory.sugarCubes.Count());
            Console.SetCursorPosition(1, 4);
            Console.Write("Ice: "+NewPlayer.inventory.iceCubes.Count());
            Console.SetCursorPosition(1, 5);
            Console.Write("Cups: "+NewPlayer.inventory.cups.Count());
        }
        public void IsKeyPressed()
        {
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey();
                if (Game.key.Key == ConsoleKey.B)
                {
                    Console.Clear();
                    BuyItems();

                }
                if (Game.key.Key == ConsoleKey.R)
                {
                    Console.Clear();
                    SetRecipe();

                }
                if (Game.key.Key == ConsoleKey.P)
                {
                    Console.Clear();
                    SetPrice();

                }

            }
            
        }
        public void UpdateWeather()
        {
            //raining, temperature, humidity
            Random random1 = new Random();
            Random random2 = new Random();
            Random random3 = new Random();
            temperature = random1.Next(70, 116);
            humidity = random2.Next(40, 80);
            raining = random3.Next(0, 100);

            Console.SetCursorPosition(38, 2);
            Console.Write(temperature + "°F  ");
            Console.SetCursorPosition(38, 3);
            Console.Write(humidity + "% Humidity");
            Console.SetCursorPosition(38, 4);
            if (raining > 49)
            {
                Console.Write("Raining    ");
            }
            else
            {
                Console.Write("Not Raining");
            }

        }

        public void DisplayWeather()
        {
            
            Console.SetCursorPosition(40, 2);
            Console.Write(temperature + "°F  ");
            Console.SetCursorPosition(40, 3);
            Console.Write(humidity + "% Humidity");
            Console.SetCursorPosition(40, 4);
            if (raining > 49)
            {
                Console.Write("Raining    ");
            }
            else
            {
                Console.Write("Not Raining");
            }

        }


        public void DisplayBoard()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(" Inventory  | Sales      | Time       | Weather     | Recipe   | Price | Wallet \n");
            Console.Write("            |            |            |             |          |       |        \n");
            Console.Write("            |            |            |             |          |       |        \n");
            Console.Write("            |            |            |             |          |       |        \n");
            Console.Write("            |            |            |             |          |       |        \n");
            Console.Write("            |            |            |             |          |       |        \n\n");
            Console.Write("Press B - Buy more - R - Change Recipe - P - Adjust Price    \n");



        }

        public void UpdateWallet()
        {
            Console.SetCursorPosition(73, 2);
            Console.Write("$"+NewPlayer.wallet.Money);
        }

        public void UpdateTime()
        {
            switch (days)
            {
                case 0:
                    Console.SetCursorPosition(27, 2);
                    Console.Write("Monday   ");
                    break;
                case 1:
                    Console.SetCursorPosition(27, 2);
                    Console.Write("Tuesday   ");
                    break;
                case 2:
                    Console.SetCursorPosition(27, 2);
                    Console.Write("Wednesday  ");
                    break;
                case 3:
                    Console.SetCursorPosition(27, 2);
                    Console.Write("Thursday  ");
                    break;
                case 4:
                    Console.SetCursorPosition(27, 2);
                    Console.Write("Friday   ");
                    break;
                case 5:
                    Console.SetCursorPosition(27, 2);
                    Console.Write("Saturday  ");
                    break;
                case 6:
                    Console.SetCursorPosition(27, 2);
                    Console.Write("Sunday   ");
                    break;

            }

            Console.SetCursorPosition(27, 3);
            Console.Write(hours + ":" + minutes + ":" + seconds);
            Console.SetCursorPosition(27, 4);
            Console.Write("Days: " + days);


        }
    }
}
