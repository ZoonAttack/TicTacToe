namespace TicTacToe
{
    public class Algorithms
    {
        ENUMS.AlgorithmState currentState = ENUMS.AlgorithmState.INVALIDPATH;
        
         int currentPlays = Game.Plays;
         bool isDraw = false;
         bool firstMoveDone = false;
        public void DFS(char[,] currentBoard, bool isComputerTurn, ref Tuple<int, int> firstMove, ref Tuple<int, int> sacrificeMove)
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
                        if (currentPlays == Game.Plays) firstMoveDone = true;

                        if(isComputerTurn && firstMove == null && firstMoveDone) 
                            firstMove = new Tuple<int, int>(i, j);
                        
                        currentPlays++;
                        DFS(currentBoard, !isComputerTurn, ref firstMove, ref sacrificeMove); //Try out that path

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
            if (CheckWin(currentBoard, currentPlays))
            {
                //If win then its a winning path
                currentState = ENUMS.AlgorithmState.WINNINGPATH;
                return;
            }
            //If not then temporarily store the sacrifice move
            if(CheckWin(currentBoard, 'X'))
            {
                sacrificeMove = firstMove;
            }

            //If not a win then check whether its the human who won or draw
            //CheckState(currentBoard);
        }



        public void BFS(char[,] initialBoard, ref Tuple<int, int> firstMove)
        {
            Queue<(char[,], bool, Tuple<int, int>, bool, bool, int)> queue = new Queue<(char[,], bool, Tuple<int, int>, bool,bool, int)>();
            Tuple<int, int> winningFirstMove = null;
            Tuple<int, int> drawFirstMove = null;
            Tuple<int, int> losingFirstMove = null;
            queue.Enqueue((initialBoard, true, null, false, false, currentPlays));
            while (queue.Count > 0)
            {
                (char[,] currentBoard, bool isComputerTurn, Tuple<int, int> stateFirstMove, bool isFirstMoveDone, bool ExploringPath, int currentPlayNumber) = queue.Dequeue();

                for(int i = 0; i < 3; i++)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        if (currentBoard[i, j] == '\0')
                        {
                            char[,] nextBoard = new char[3, 3];
                            //Make a new state from THIS state
                            Array.Copy(currentBoard, nextBoard, currentBoard.Length);
                            nextBoard[i, j] = isComputerTurn ? 'O' : 'X'; //Problem here with the way im checking ??
                            if(!isFirstMoveDone && isComputerTurn && !firstMoveDone)
                            {
                                stateFirstMove = new Tuple<int, int>(i, j);
                            }
                            if (currentPlays == Game.Plays) 
                            { 
                                isFirstMoveDone = true; firstMoveDone = true; 
                            }
                            //Either found a win or a draw state(human doesnt win)
                            if (CheckWin(nextBoard, currentPlayNumber))
                            {
                                if(Game.GameState != ENUMS.GameState.DRAW)  currentState = ENUMS.AlgorithmState.WINNINGPATH;
                                winningFirstMove = stateFirstMove;
                                goto foundWinningPath;
                            }
                            //Handle draw state
                            //Probably could have done it better -_-
                            if (Game.Plays + 2 == 9)
                            {
                               //Game.GameState = ENUMS.GameState.DRAW;
                                drawFirstMove = stateFirstMove;
                            }
                            //Handle losingState
                            if(CheckWin(nextBoard, currentPlayNumber, 'X') && currentState == ENUMS.AlgorithmState.INVALIDPATH)
                            {
                                losingFirstMove = stateFirstMove;
                            }
                            queue.Enqueue((nextBoard, !isComputerTurn, stateFirstMove,  isFirstMoveDone, true, currentPlays + 1));
                            if(!ExploringPath)
                            {
                                isFirstMoveDone = false;
                                firstMoveDone = false;
                            }
                        }
                    }
                }
                currentPlays++;
            }
        foundWinningPath:
            if (winningFirstMove != null)
            {
                firstMove = winningFirstMove;
                return;
            }
            
            if (drawFirstMove != null)
            {
                firstMove = drawFirstMove;
                return;
            }
            if(losingFirstMove != null)
            {
                firstMove = losingFirstMove;
                return;
            }
        }

        public void IterativeDeepening(char[,] initialBoard, ref Tuple<int, int> firstMove)
        {
            // Set a maximum depth based on the remaining moves (9 - current plays)
            int maxDepth = 9 - Game.Plays; // or set to a predefined max like 5
            Tuple<int, int> winningMove = null;

            // Run depth-limited DFS for each depth level
            for (int depth = 1; depth <= maxDepth; depth++)
            {
                if (DepthLimitedDFS(initialBoard, depth, true, ref winningMove))
                {
                    firstMove = winningMove;
                    return; // Exit once a winning path is found
                }
            }

            // backup move
            if (firstMove == null && winningMove != null)
            {
                firstMove = winningMove;
            }
        }

        // Depth-Limited DFS function
        private bool DepthLimitedDFS(char[,] currentBoard, int depth, bool isComputerTurn, ref Tuple<int, int> firstMove)
        {
            if (depth == 0) return false; // Base case: depth limit reached

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentBoard[i, j] == '\0')
                    {
                        currentBoard[i, j] = isComputerTurn ? 'O' : 'X';

                        // Record the first move only once
                        if (isComputerTurn && firstMove == null)
                        {
                            firstMove = new Tuple<int, int>(i, j);
                        }

                        // Check if this move results in a win
                        if (CheckWin(currentBoard, Game.Plays))
                        {
                            return true; // Winning path found
                        }

                        // Recursive DFS with a reduced depth limit
                        if (DepthLimitedDFS(currentBoard, depth - 1, !isComputerTurn, ref firstMove))
                        {
                            return true; // Winning path found deeper
                        }

                        // Undo the move for backtracking
                        currentBoard[i, j] = '\0';
                    }
                }
            }

            return false; // No winning path found at this depth
        }

        public bool CheckWin(char[,] currentBoard, int plays, char player = 'O')
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
            if (player == 'O')currentState = ENUMS.AlgorithmState.INVALIDPATH;
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
        public  void ResetData()
        {
            currentState = ENUMS.AlgorithmState.INVALIDPATH;
            currentPlays = Game.Plays;
            isDraw = false;
            firstMoveDone = false;
        }

    }
}
