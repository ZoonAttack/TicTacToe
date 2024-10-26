namespace TicTacToe
{
    enum States
    {
        VALIDMOVE, 
        INVALIDMOVE
    }
    public class Algorithms
    {
        static States currentState;

        static int currentPlays = Game.plays;

        public static void DFS(char[,] currentBoard, bool isComputerTurn, ref Tuple<int, int> firstMove)
        {            
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (currentBoard[i,j] == '\0')
                    {
                        currentBoard[i, j] = isComputerTurn ? 'O' : 'X';
                        if(isComputerTurn && firstMove == null) 
                            firstMove = new Tuple<int, int>(i, j);
                        
                        currentPlays++;
                        DFS(currentBoard, !isComputerTurn, ref firstMove); //Try out that path
                        currentPlays--;
                        
                        //If no valid move just keep backtracking
                        if(currentState != States.VALIDMOVE)
                            currentBoard[i, j] = '\0';
                    }
                }
            }
            //If board full
            if (currentPlays >= 9)
            {
                //if Reached a winning state.
                if (checkState(currentBoard)) currentState = States.VALIDMOVE;
                return;
            }
            if (currentState != States.VALIDMOVE)
            {
                //Found valid move 
                firstMove = null;
                return;
            }
        }
        private static bool checkState(char[,] currentBoard, char player = 'O')
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
            currentState = States.INVALIDMOVE;
            return false;
        }
        private static void isDraw()
        {
            //Not a win state
            if (currentPlays == 9) currentState = States.INVALIDMOVE;
        }
    }
}
