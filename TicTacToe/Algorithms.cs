namespace TicTacToe
{
    public class Algorithms
    {
        static int  currentPlays = 1;
        public static bool DFS(char[,] currentBoard, bool isComputerTurn)
        {
            if (checkState(currentBoard, 'X')) return false; //Human wins
            if (checkState(currentBoard, 'O')) { return true; } //Computer wins
            if (isDraw()){ return false; }

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (currentBoard[i,j] == '\0')
                    {
                        currentBoard[i, j] = isComputerTurn ? 'O' : 'X';
                        currentPlays++;
                        bool result = DFS(currentBoard, !isComputerTurn);
                        currentPlays--;
                        currentBoard[i, j] = '\0';

                        //If algorithm found a winning state.. take turn and send true(Found winning state)
                        if (isComputerTurn && result)
                        {
                            Game.board[i, j] = 'O';
                            Game.UpdateButtons(i, j);
                            return true;
                        }
                    }
                }
            }


            return false;
        }
        private static bool checkState(char[,] currentBoard, char player)
        {
            //Horizontal check
            if (currentBoard[0, 0] == player && currentBoard[0, 1] == player && currentBoard[0, 2] == player) return true;
            if (currentBoard[1, 0] == player && currentBoard[1, 1] == player && currentBoard[1, 2] == player) return true;
            if (currentBoard[2, 0] == player && currentBoard[2, 1] == player && currentBoard[2, 2] == player) return true;
            //Vertical check
            if (currentBoard[0, 0] == player && currentBoard[1, 0] == player && currentBoard[2, 0] == player) return true;
            if (currentBoard[0, 1] == player && currentBoard[1, 1] == player && currentBoard[2, 1] == player) return true;
            if (currentBoard[0, 2] == player && currentBoard[1, 2] == player && currentBoard[2, 2] == player) return true;
            //Diagonal
            if (currentBoard[0, 0] == player && currentBoard[1, 1] == player && currentBoard[2, 2] == player) return true;
            if (currentBoard[2, 0] == player && currentBoard[1, 1] == player && currentBoard[0, 2] == player) return true;

            //Draw
            //check for win/loss conditions and draws
            return false;
        }
        private static bool isDraw()
        {
            if (currentPlays == 9) return true;
            return false;
        }
    }
}
