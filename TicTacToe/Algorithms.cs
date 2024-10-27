namespace TicTacToe
{
    enum States
    {
        WINNINGPATH, 
        INVALIDPATH
    }
    public class Algorithms
    {
        static States currentState = States.INVALIDPATH;

        static int currentPlays = Game.plays;
        static bool isDraw = false;
        static bool firstMoveDone = false;
        public static void DFS(char[,] currentBoard, bool isComputerTurn, ref Tuple<int, int> firstMove)
        {
            //If winning path is found. dont try other paths
            if (currentState == States.WINNINGPATH)
            {
                return;
            }
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    //If current cell is empty
                    if (currentBoard[i,j] == '\0')
                    {
                        currentBoard[i, j] = isComputerTurn ? 'O' : 'X';
                        if (currentPlays == Game.plays) firstMoveDone = true;

                        if(isComputerTurn && firstMove == null && firstMoveDone) 
                            firstMove = new Tuple<int, int>(i, j);
                        
                        currentPlays++;
                        DFS(currentBoard, !isComputerTurn, ref firstMove); //Try out that path

                        //If no valid move just keep backtracking
                        if (currentState != States.WINNINGPATH)
                        {
                            currentBoard[i, j] = '\0';
                            currentPlays--;
                            if (i == firstMove.Item1 && j == firstMove.Item2)
                            {
                                firstMoveDone = false;
                                firstMove = null;
                            }
                        }
                    }
                }
            }
            //After finishing this path.. check if it results in a win 
            if(checkState(currentBoard))
            {
                currentState = States.WINNINGPATH;
            }
        }
        public static bool checkState(char[,] currentBoard, char player = 'O')
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

            //Not a win state.
            currentState = States.INVALIDPATH;
            return false;
        }
        public static void ResetData()
        {
            currentState = States.INVALIDPATH;
            currentPlays = Game.plays;
            isDraw = false;
            firstMoveDone = false;
        }
    }
}
