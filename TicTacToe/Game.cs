using System.Runtime.InteropServices;

namespace TicTacToe
{
    public partial class Game : Form
    {
        private static Dictionary<int, Button> buttons = new Dictionary<int, Button>();


        public static char[,] board = new char[3, 3];
        public static int plays;
        public Game()
        {
            AllocConsole();
            InitializeComponent();
            buttons.Add(0, Top_LeftBTN);
            buttons.Add(1, Top_CentreBTN);
            buttons.Add(2, Top_RightBTN);
            buttons.Add(3, Centre_LeftBTN);
            buttons.Add(4, CentreBTN);
            buttons.Add(5, Centre_RightBTN);
            buttons.Add(6, Bottom_LeftBTN);
            buttons.Add(7, Bottom_CentreBTN);
            buttons.Add(8, Bottom_RightBTN);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();


        private void AlgorithmsLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AlgorithmsLB.SelectedItem != null) MessageBox.Show(AlgorithmsLB.SelectedItem.ToString());
        }

        private void Button_Click(object sender, EventArgs e)
        {
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
            //Sending a copy from the original board
            char[,] currentBoard = new char[3, 3];
            Array.Copy(board, currentBoard, board.Length);

            Tuple<int, int> firstmove = null;

            Algorithms.DFS(currentBoard, true, ref firstmove);

            UpdateButtons(firstmove.Item1, firstmove.Item2);
        }
        public static void UpdateButtons(int row, int col)
        {
            int buttonTag = -1;
            foreach (var item in buttons)
            {
                int index = item.Key;
                if (index / 3 == row && index % 3 == col)
                {
                    buttonTag = index;
                }
            }
            if (buttons.TryGetValue(buttonTag, out Button pressedButton))
            {
                pressedButton.Text = "O";
                pressedButton.Enabled = false;
                plays++;
            }
            
        }

        private void ResetBTN_Click(object sender, EventArgs e)
        {
            //BoardGB.Controls.Clear();
        }
    }
}
