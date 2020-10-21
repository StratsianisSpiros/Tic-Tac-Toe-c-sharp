using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triliza
{
    class Game
    {
        //Main menu
        public void Menu()
        {
            while (true)
            {
                string inp;
                do
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("MAIN MENU");
                    Console.Write(Environment.NewLine);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Type 1 for new game.");
                    Console.WriteLine("Type exit to leave.");

                    inp = Console.ReadLine();

                    if (inp.ToLower().Equals("exit"))
                        Environment.Exit(0);

                    if (inp.Equals("1"))
                        Start();
                }
                while (!inp.Equals("1"));
            }
        }
        
        //Starts game
        private void Start()
        {
            int turn;
            string player1;
            string player2;
            string[,] stringGrid = new string[3, 3];

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Initialize(stringGrid);

            Console.Write("Enter player 1 name : ");
            player1 = Console.ReadLine();
            Console.Write("Enter player 2 name : ");
            player2 = Console.ReadLine();
            Random rand = new Random();

            turn = rand.Next(1, 3);
            if (turn == 2)
                SwapPlayer(ref player1, ref player2);

            for (int i = 1; i <= 9; i++)
            {
                 if (i % 2 == 1)
                {
                    ChooseTile(player1, stringGrid, 1);
                }
                else if (i % 2 == 0)
                {
                    ChooseTile(player2, stringGrid, 2);
                }

                if (Win(stringGrid) == 1)
                {
                    Console.Clear();
                    ShowGrid(stringGrid);
                    Console.WriteLine($"Player {player1} Wins!!!");
                    break;
                }
                else if (Win(stringGrid) == 2)
                {
                    Console.Clear();
                    ShowGrid(stringGrid);
                    Console.WriteLine($"Player {player2} Wins!!!");
                    break;
                }
            }

            if (Win(stringGrid) == 0)
            {
                Console.Clear();
                ShowGrid(stringGrid);
                Console.WriteLine("It's a draw...");
            }

            Console.ReadLine();
        }

        //Player gives two number from 1 to 3 and based assigns X or O to the grid
        //Also checks if a tile is empty (intialize) otherwise ask again the user for input
        private void ChooseTile(string name, string[,] arr, int turn)
        {
            int num1, num2;

            do
            {
                Console.Clear();
                ShowGrid(arr);
                num1 = NumberInput(name) - 1;
                num2 = NumberInput(name) - 1;
            }
            while (!arr[num1, num2].Equals("|   |"));

            if (turn == 1)
                arr[num1, num2] = "| X |";
            else
                arr[num1, num2] = "| O |";
        }

        //Checks the input of the player to be integer between 1 and 3
        private int NumberInput(string name)
        {
            string temp;
            do
            {
                Console.WriteLine($"It's {name} turn, which tile do you pick(numbers 1 to 3, row and column)? ");
                temp = Console.ReadLine();
            }
            while (!int.TryParse(temp, out int u) || int.Parse(temp) < 1 || int.Parse(temp) > 3);

            return int.Parse(temp);
        }

        //Displays grid
        private void ShowGrid(string[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.WriteLine("---------------");
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.Write(Environment.NewLine);
                Console.WriteLine("---------------");
            }
        }

        //Initializes grid in order to check easier user input
        private void Initialize(string[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = "|   |";
                }
            }
        }

        //Checks win conditions
        private int Win(string[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (arr[i,0].Equals(arr[i, 1]) && arr[i, 0].Equals(arr[i, 2]))
                {
                    if (arr[i, 0].Equals("| X |"))
                        return 1;
                    else if (arr[i, 0].Equals("| O |"))
                        return 2;
                }
                else if (arr[0, i].Equals(arr[1, i]) && arr[0, i].Equals(arr[2, i]))
                {
                    if (arr[0, i].Equals("| X |"))
                        return 1;
                    else if (arr[0, i].Equals("| O |"))
                        return 2;
                }
            }
            
            if (arr[0, 0].Equals(arr[1, 1]) && arr[0, 0].Equals(arr[2, 2]))
            {
                if (arr[0, 0].Equals("| X |"))
                    return 1;
                else if (arr[0, 0].Equals("| O |"))
                    return 2;
            }
            else if (arr[0, 2].Equals(arr[1, 1]) && arr[0, 2].Equals(arr[2, 0]))
            {
                if (arr[0, 2].Equals("| X |"))
                    return 1;
                else if (arr[0, 2].Equals("| O |"))
                    return 2;
            }

            return 0;
        }

        //Swap players turn order
        private void SwapPlayer(ref string player1, ref string player2)
        {
            string temp = player1;
            player1 = player2;
            player2 = temp;
        }

    }
}
