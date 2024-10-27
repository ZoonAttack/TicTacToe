﻿namespace TicTacToe
{
    public class Algorithms
    {
        static ENUMS.AlgorithmState currentState = ENUMS.AlgorithmState.INVALIDPATH;

        static int currentPlays = Game.plays;
        static bool isDraw = false;
        static bool firstMoveDone = false;
        public static void DFS(char[,] currentBoard, bool isComputerTurn, ref Tuple<int, int> firstMove)
        {
            //If winning path is found. dont try other paths
            if (currentState == ENUMS.AlgorithmState.WINNINGPATH)
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
                        if (currentState != ENUMS.AlgorithmState.WINNINGPATH)
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
            if (CheckWin(currentBoard))
            {
                //If win then its a winning path
                currentState = ENUMS.AlgorithmState.WINNINGPATH;
                return;
            }
            //If not a win then check whether its the human who won or draw
            //CheckState(currentBoard);
        }
        public static bool CheckWin(char[,] currentBoard, char player = 'O')
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
            if(player == 'O')currentState = ENUMS.AlgorithmState.INVALIDPATH;
            return false;
        }

        //private static void CheckState(char[,] currentBoard)
        //{
        //    //If an INVALIDPATH goal has been reached
        //    if(currentState != ENUMS.AlgorithmState.WINNINGPATH)
        //    {
        //        //Check if human has won
        //        if (CheckWin(currentBoard, 'X')) Game.GameState = ENUMS.GameState.HUMANWIN;
        //        //If not then it's a draw
        //        else Game.GameState = ENUMS.GameState.DRAW;
        //    }
        //}
        public static void ResetData()
        {
            currentState = ENUMS.AlgorithmState.INVALIDPATH;
            currentPlays = Game.plays;
            isDraw = false;
            firstMoveDone = false;
        }

    }
}
