using System.Runtime.InteropServices;

namespace TicTacToe
{
    public partial class Game : Form
    {
        private static List<Button> buttons = new List<Button>();

        public static char[,] board = new char[3, 3];
        public static int plays;
        //public static ENUMS.GameState GameState;
        public Game()
        {
            InitializeComponent();
            buttons.Add(Top_LeftBTN);
            buttons.Add(Top_CentreBTN);
            buttons.Add(Top_RightBTN);
            buttons.Add(Centre_LeftBTN);
            buttons.Add(CentreBTN);
            buttons.Add(Centre_RightBTN);
            buttons.Add(Bottom_LeftBTN);
            buttons.Add(Bottom_CentreBTN);
            buttons.Add(Bottom_RightBTN);

            foreach (Button button in buttons)
            {
                button.Enabled = false;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {

            if (AlgorithmsLB.SelectedItem == null)
            {
                MessageBox.Show("Choose an algorithm first please..");
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
            }
            plays++;

            runAlgorithm(AlgorithmsLB.SelectedItem.ToString());
            if (plays == 9)
                checkWinner();
        }

        public static void UpdateButtons(int row, int col)
        {
            foreach (Button button in buttons)
            {
                int tag = Convert.ToInt32(button.Tag.ToString());
                if (tag / 3 == row && tag % 3 == col)
                {
                    button.Text = "O";
                    button.Enabled = false;
                    return;
                }
            }
        }

        private void ResetBTN_Click(object sender, EventArgs e)
        {
            foreach (Button button in buttons)
            {
                button.Enabled = true;
                button.Text = string.Empty;
            }
            board = new char[3, 3];
            plays = 0;
        }

        private void checkWinner()
        {
            if (Algorithms.CheckWin(board, 'X'))
            {
                MessageBox.Show("PLAYER HAS WON!");
                disableButtons();
            }
            else if (Algorithms.CheckWin(board, 'O'))
            {
                MessageBox.Show("COMPUTER HAS WON!");
                disableButtons();
            }
            else
            {
                if (plays == 9)
                {
                    MessageBox.Show("DRAW");
                    disableButtons();
                }
            }
        }

        private void runAlgorithm(string name)
        {
            //Sending a copy from the original board
            char[,] currentBoard = new char[3, 3];
            Array.Copy(board, currentBoard, board.Length);

            Tuple<int, int> firstmove = null;
            Algorithms.ResetData();
            switch (name)
            {
                case "DFS":
                    Algorithms.DFS(currentBoard, true, ref firstmove);
                    plays++;
                    break;
                case "BFS":
                    break;
                case "Iterative Deepening":
                    break;
                case "UCS":
                    break;
                default:
                    break;
            }
            if (firstmove != null)
            {
                board[firstmove.Item1, firstmove.Item2] = 'O';
                UpdateButtons(firstmove.Item1, firstmove.Item2);
            }
            checkWinner();
        }
        private void disableButtons()
        {
            foreach (Button button in buttons)
                button.Enabled = false; 
        }
        private void AlgorithmsLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AlgorithmsLB.SelectedItem != null)
            {
                ResetBTN.PerformClick();
            }
        }
    }
}
