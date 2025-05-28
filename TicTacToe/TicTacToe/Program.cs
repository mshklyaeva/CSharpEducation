using System;

namespace CSharpEducation 
{
    public class Program
    {
        const string line = "-------------";
        static void Main(string[] args)
        {
            var gameField = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            bool isWin = false, isDraw = false, isNumber;
            int step, count = 0;

            Console.Write("Начать игру? (y,n) ");
            char start = Convert.ToChar(Console.ReadLine()), player = 'X';

            if (start == 'y')
            {
                while (!isWin && !isDraw)
                {
                    PrintField(gameField);

                    Console.Write("Ход " + player + " ");
                    isNumber = int.TryParse(Console.ReadLine(), out step);

                    while (!CheckStep(isNumber, step, gameField))
                    {
                        Console.WriteLine("Неверный ход!");
                        Console.Write("Ход " + player + " ");

                        isNumber = int.TryParse(Console.ReadLine(), out step);
                    }
                    gameField[step - 1] = player;
                    count++;

                    if (CheckWin(gameField)) isWin = true;
                    else if (count == 9) isDraw = true;
                    else player = SwapPLayer(player);

                }
                PrintField(gameField);

                if (isWin) Console.WriteLine("Победа " + player + "!");
                else Console.WriteLine("Ничья!");
            }
            else
            {
                Console.WriteLine("Отмена игры");
            }
        }
        static void PrintField(char[] gameField)
        {
            int index = 0; 
            Console.WriteLine(line);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("| " + gameField[index] + " ");
                    index++;
                }
                Console.WriteLine("|");
                Console.WriteLine(line);
            }
        }

        static bool CheckWin(char[] gameField)
        {
            for (int i = 0; i < 9; i += 3)
                if (gameField[i] == gameField[i + 1] && gameField[i] == gameField[i + 2]) return true;
            for (int i = 0; i < 3; i++)
                if (gameField[i] == gameField[i + 3] && gameField[i] == gameField[i + 6]) return true;
            if (gameField[0] == gameField[4] && gameField[4] == gameField[8]) return true;
            if (gameField[2] == gameField[4] && gameField[4] == gameField[6]) return true;
            return false;
        }

        static bool CheckStep(bool isNumber, int step, char[] gameField)
        {
            if (isNumber && step > 0 && step < 10)
            {
                if (gameField[step - 1] == 'X' || gameField[step - 1] == 'O')
                    return false;
            }
            else return false;

            return true;
        }

        static char SwapPLayer(char player)
        {
            if (player == 'X') return 'O';
            else return 'X';
        }

        
    }
}
