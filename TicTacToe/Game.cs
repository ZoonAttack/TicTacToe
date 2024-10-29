using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace TicTacToe
{
    public partial class Game : Form
    {
        #region PrivateFields
        private static List<Button> buttons = new List<Button>();
        private static char[,] board = new char[3, 3];
        private static int plays;
        public static ENUMS.GameState GameState;
        #endregion

        #region Properties
        public static int Plays { get { return plays; } set { plays = value; } }
        #endregion

        #region Constructor
        public Game()
        {
            InitializeComponent();
            InitializeButtons();
            DisableAllButtons();
        }
        #endregion

        #region UI_Methods
        private void Button_Click(object sender, EventArgs e)
        {
            if (AlgorithmsLB.SelectedItem == null)
            {
                MessageBox.Show("Please select an algorithm first.");
                return;
            }

            Button button = (Button)sender;
            int index = int.Parse(button.Tag.ToString());
            int row = index / 3;
            int col = index % 3;

            if (board[row, col] == '\0')
            {
                board[row, col] = 'X';
                button.Text = "X";
                button.Enabled = false;
                plays++;
                RunSelectedAlgorithm(AlgorithmsLB.SelectedItem.ToString());
            }
        }

        private void ResetBTN_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void AlgorithmsLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AlgorithmsLB.SelectedItem != null)
            {
                ResetGame();
            }
        }

        #endregion

        #region HelperMethods
        private void RunSelectedAlgorithm(string algorithmName)
        {
            Algorithms algorithm = new Algorithms();
            char[,] currentBoard = (char[,])board.Clone();
            Tuple<int, int> firstMove = null;
            Tuple<int, int> sacrificeMove = null;
            switch (algorithmName)
            {
                case "DFS":
                    algorithm.ResetData();
                    algorithm.DFS(currentBoard, true, ref firstMove, ref sacrificeMove);
                    plays++;
                    break;
                case "BFS":
                    algorithm.ResetData();
                    algorithm.BFS(currentBoard, ref firstMove);
                    plays++;
                    break;
                case "Iterative Deepening":
                    algorithm.ResetData();
                    algorithm.IterativeDeepening(currentBoard, ref firstMove);
                    plays++;
                    break;
                    // Add other algorithms here as needed
            }

            ExecuteMove(firstMove ?? sacrificeMove);

            CheckWinner(algorithm);
        }

        private void CheckWinner(Algorithms obj)
        {
            if(obj.CheckWin(board, plays, 'X'))
            {
                MessageBox.Show("Player won!!");
                DisableAllButtons();
            }
            else if(obj.CheckWin(board, plays, 'O'))
            {
                MessageBox.Show("CPU won!!");
                DisableAllButtons();
            }
            else
            {
                if(plays >= 9)
                {
                    MessageBox.Show("DRAW!!");
                }
            }
        }

        private void ExecuteMove(Tuple<int, int> move)
        {
            if (move != null)
            {
                board[move.Item1, move.Item2] = 'O';
                UpdateButton(move.Item1, move.Item2, "O");
            }
        }

        private void UpdateButton(int row, int col, string text)
        {
            foreach (Button button in buttons)
            {
                int tag = int.Parse(button.Tag.ToString());
                if (tag / 3 == row && tag % 3 == col)
                {
                    button.Text = text;
                    button.Enabled = false;
                    return;
                }
            }
        }


        private void ResetGame()
        {
            EnableAllButtons();
            foreach (Button button in buttons)
                button.Text = string.Empty;

            board = new char[3, 3];
            plays = 0;
            GameState = ENUMS.GameState.PLAYING; // Assuming an initial playing state
        }
        private void InitializeButtons()
        {
            buttons.AddRange([Top_LeftBTN, Top_CentreBTN, Top_RightBTN, Centre_LeftBTN, CentreBTN, Centre_RightBTN, Bottom_LeftBTN, Bottom_CentreBTN, Bottom_RightBTN]);
        }

        private void DisableAllButtons()
        {
            foreach (Button button in buttons)
                button.Enabled = false;
        }

        private void EnableAllButtons()
        {
            foreach (Button button in buttons)
                button.Enabled = true;
        }
        #endregion
    }
}
