namespace TicTacToe
{
    internal class Program
    {
        static public string[,] board = new string[3, 3] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
        static public bool isWinner = false;
        static public int activePlayer = 0;

        static void Main()
        {
            PlayGame();
        }

        static public void PlayGame()
        {
            while (!isWinner)
            {
                PrintBoard(board);
                Console.WriteLine($"Player {activePlayer + 1}: Choose your field!");
                GetPlayerChoice();
                CheckWinner(board);
                if (!isWinner)
                {
                    activePlayer = activePlayer == 0 ? 1 : 0;
                }
                Console.Clear();
            }

            Console.WriteLine($"Player {activePlayer + 1} is the winner!!");
        }


        static public void PrintBoard(string[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.WriteLine("     |     |     ");
                Console.WriteLine($"  {board[i, 0]}  |  {board[i, 1]}  |  {board[i, 2]}   ");
                Console.WriteLine("     |     |     ");
                if (i <= 1)
                {
                    Console.WriteLine("----------------");
                }
            }
        }

        static public void GetPlayerChoice()
        {
            bool choiceMade = false;

            while (!choiceMade)
            {
                string playerInput = Console.ReadLine();

                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        if (board[i, j] == playerInput)
                        {
                            board[i, j] = activePlayer == 0 ? "O" : "X";
                            choiceMade = true;
                        }
                    }
                }
                if (!choiceMade)
                {
                    Console.WriteLine("That point is taken, try again!");
                }
            }
        }

        static public void CheckWinner(string[,] board)
        {
            // Check for horizontal win
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    isWinner = true;
                }
            }
            // Check for vertical win
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    isWinner = true;
                }
            }
            // Check for diagonal win
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                isWinner = true;
            }
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                isWinner = true;
            }
        }
    }
}