namespace TicTacToe
{
    partial class Game
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BoardGB = new GroupBox();
            Bottom_RightBTN = new Button();
            Bottom_CentreBTN = new Button();
            Bottom_LeftBTN = new Button();
            Centre_RightBTN = new Button();
            CentreBTN = new Button();
            Centre_LeftBTN = new Button();
            Top_CentreBTN = new Button();
            Top_RightBTN = new Button();
            Top_LeftBTN = new Button();
            AlgorithmsLB = new ListBox();
            AlgorithmGB = new GroupBox();
            ResetBTN = new Button();
            BoardGB.SuspendLayout();
            AlgorithmGB.SuspendLayout();
            SuspendLayout();
            // 
            // BoardGB
            // 
            BoardGB.Controls.Add(Bottom_RightBTN);
            BoardGB.Controls.Add(Bottom_CentreBTN);
            BoardGB.Controls.Add(Bottom_LeftBTN);
            BoardGB.Controls.Add(Centre_RightBTN);
            BoardGB.Controls.Add(CentreBTN);
            BoardGB.Controls.Add(Centre_LeftBTN);
            BoardGB.Controls.Add(Top_CentreBTN);
            BoardGB.Controls.Add(Top_RightBTN);
            BoardGB.Controls.Add(Top_LeftBTN);
            BoardGB.Location = new Point(184, 12);
            BoardGB.Name = "BoardGB";
            BoardGB.Size = new Size(364, 387);
            BoardGB.TabIndex = 0;
            BoardGB.TabStop = false;
            BoardGB.Text = "Board";
            // 
            // Bottom_RightBTN
            // 
            Bottom_RightBTN.Location = new Point(246, 267);
            Bottom_RightBTN.Name = "Bottom_RightBTN";
            Bottom_RightBTN.Size = new Size(114, 118);
            Bottom_RightBTN.TabIndex = 8;
            Bottom_RightBTN.Tag = "8";
            Bottom_RightBTN.UseVisualStyleBackColor = true;
            Bottom_RightBTN.Click += Button_Click;
            // 
            // Bottom_CentreBTN
            // 
            Bottom_CentreBTN.Location = new Point(126, 267);
            Bottom_CentreBTN.Name = "Bottom_CentreBTN";
            Bottom_CentreBTN.Size = new Size(114, 118);
            Bottom_CentreBTN.TabIndex = 7;
            Bottom_CentreBTN.Tag = "7";
            Bottom_CentreBTN.UseVisualStyleBackColor = true;
            Bottom_CentreBTN.Click += Button_Click;
            // 
            // Bottom_LeftBTN
            // 
            Bottom_LeftBTN.Location = new Point(6, 267);
            Bottom_LeftBTN.Name = "Bottom_LeftBTN";
            Bottom_LeftBTN.Size = new Size(114, 118);
            Bottom_LeftBTN.TabIndex = 6;
            Bottom_LeftBTN.Tag = "6";
            Bottom_LeftBTN.UseVisualStyleBackColor = true;
            Bottom_LeftBTN.Click += Button_Click;
            // 
            // Centre_RightBTN
            // 
            Centre_RightBTN.Location = new Point(246, 146);
            Centre_RightBTN.Name = "Centre_RightBTN";
            Centre_RightBTN.Size = new Size(114, 118);
            Centre_RightBTN.TabIndex = 5;
            Centre_RightBTN.Tag = "5";
            Centre_RightBTN.UseVisualStyleBackColor = true;
            Centre_RightBTN.Click += Button_Click;
            // 
            // CentreBTN
            // 
            CentreBTN.Location = new Point(126, 146);
            CentreBTN.Name = "CentreBTN";
            CentreBTN.Size = new Size(114, 118);
            CentreBTN.TabIndex = 4;
            CentreBTN.Tag = "4";
            CentreBTN.UseVisualStyleBackColor = true;
            CentreBTN.Click += Button_Click;
            // 
            // Centre_LeftBTN
            // 
            Centre_LeftBTN.Location = new Point(6, 146);
            Centre_LeftBTN.Name = "Centre_LeftBTN";
            Centre_LeftBTN.Size = new Size(114, 118);
            Centre_LeftBTN.TabIndex = 3;
            Centre_LeftBTN.Tag = "3";
            Centre_LeftBTN.UseVisualStyleBackColor = true;
            Centre_LeftBTN.Click += Button_Click;
            // 
            // Top_CentreBTN
            // 
            Top_CentreBTN.Location = new Point(126, 22);
            Top_CentreBTN.Name = "Top_CentreBTN";
            Top_CentreBTN.Size = new Size(114, 118);
            Top_CentreBTN.TabIndex = 2;
            Top_CentreBTN.Tag = "1";
            Top_CentreBTN.UseVisualStyleBackColor = true;
            Top_CentreBTN.Click += Button_Click;
            // 
            // Top_RightBTN
            // 
            Top_RightBTN.Location = new Point(246, 22);
            Top_RightBTN.Name = "Top_RightBTN";
            Top_RightBTN.Size = new Size(114, 118);
            Top_RightBTN.TabIndex = 1;
            Top_RightBTN.Tag = "2";
            Top_RightBTN.UseVisualStyleBackColor = true;
            Top_RightBTN.Click += Button_Click;
            // 
            // Top_LeftBTN
            // 
            Top_LeftBTN.Location = new Point(6, 22);
            Top_LeftBTN.Name = "Top_LeftBTN";
            Top_LeftBTN.Size = new Size(114, 118);
            Top_LeftBTN.TabIndex = 0;
            Top_LeftBTN.Tag = "0";
            Top_LeftBTN.UseVisualStyleBackColor = true;
            Top_LeftBTN.Click += Button_Click;
            // 
            // AlgorithmsLB
            // 
            AlgorithmsLB.BackColor = SystemColors.Window;
            AlgorithmsLB.BorderStyle = BorderStyle.FixedSingle;
            AlgorithmsLB.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AlgorithmsLB.ForeColor = SystemColors.WindowText;
            AlgorithmsLB.FormattingEnabled = true;
            AlgorithmsLB.ItemHeight = 20;
            AlgorithmsLB.Items.AddRange(new object[] { "DFS", "BFS", "Iterative Deepening", "UCS" });
            AlgorithmsLB.Location = new Point(15, 22);
            AlgorithmsLB.Name = "AlgorithmsLB";
            AlgorithmsLB.Size = new Size(120, 82);
            AlgorithmsLB.TabIndex = 1;
            AlgorithmsLB.SelectedIndexChanged += AlgorithmsLB_SelectedIndexChanged;
            // 
            // AlgorithmGB
            // 
            AlgorithmGB.BackgroundImageLayout = ImageLayout.None;
            AlgorithmGB.Controls.Add(AlgorithmsLB);
            AlgorithmGB.Location = new Point(615, 28);
            AlgorithmGB.Name = "AlgorithmGB";
            AlgorithmGB.Size = new Size(156, 124);
            AlgorithmGB.TabIndex = 2;
            AlgorithmGB.TabStop = false;
            AlgorithmGB.Text = "Algorithms";
            // 
            // ResetBTN
            // 
            ResetBTN.Location = new Point(332, 408);
            ResetBTN.Name = "ResetBTN";
            ResetBTN.Size = new Size(78, 30);
            ResetBTN.TabIndex = 3;
            ResetBTN.Text = "Reset";
            ResetBTN.UseVisualStyleBackColor = true;
            ResetBTN.Click += ResetBTN_Click;
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ResetBTN);
            Controls.Add(AlgorithmGB);
            Controls.Add(BoardGB);
            Name = "Game";
            Text = "TicTacToe";
            BoardGB.ResumeLayout(false);
            AlgorithmGB.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox BoardGB;
        private Button Bottom_RightBTN;
        private Button Bottom_CentreBTN;
        private Button Bottom_LeftBTN;
        private Button Centre_RightBTN;
        private Button CentreBTN;
        private Button Centre_LeftBTN;
        private Button Top_CentreBTN;
        private Button Top_RightBTN;
        private Button Top_LeftBTN;
        private ListBox AlgorithmsLB;
        private GroupBox AlgorithmGB;
        private Button ResetBTN;
    }
}
