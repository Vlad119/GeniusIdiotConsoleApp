namespace GeniusIdiotWinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnStartGame = new Button();
            btnAddQuestion = new Button();
            btnDeleteQuestion = new Button();
            btnShowHistory = new Button();
            SuspendLayout();
            // 
            // btnStartGame
            // 
            btnStartGame.BackColor = Color.LightGoldenrodYellow;
            btnStartGame.Font = new Font("Arial", 13.875F);
            btnStartGame.ForeColor = SystemColors.ActiveCaptionText;
            btnStartGame.Location = new Point(18, 42);
            btnStartGame.Margin = new Padding(2, 2, 2, 2);
            btnStartGame.Name = "btnStartGame";
            btnStartGame.Size = new Size(455, 91);
            btnStartGame.TabIndex = 0;
            btnStartGame.Text = "Начать игру";
            btnStartGame.UseVisualStyleBackColor = false;
            btnStartGame.Click += btnStartGame_Click;
            // 
            // btnAddQuestion
            // 
            btnAddQuestion.BackColor = Color.LightGoldenrodYellow;
            btnAddQuestion.Font = new Font("Arial", 13.875F);
            btnAddQuestion.ForeColor = SystemColors.ActiveCaptionText;
            btnAddQuestion.Location = new Point(18, 138);
            btnAddQuestion.Margin = new Padding(2, 2, 2, 2);
            btnAddQuestion.Name = "btnAddQuestion";
            btnAddQuestion.Size = new Size(455, 91);
            btnAddQuestion.TabIndex = 2;
            btnAddQuestion.Text = "Добавить вопрос";
            btnAddQuestion.UseVisualStyleBackColor = false;
            btnAddQuestion.Click += btnAddQuestion_Click;
            // 
            // btnDeleteQuestion
            // 
            btnDeleteQuestion.BackColor = Color.LightGoldenrodYellow;
            btnDeleteQuestion.Font = new Font("Arial", 13.875F);
            btnDeleteQuestion.ForeColor = SystemColors.ActiveCaptionText;
            btnDeleteQuestion.Location = new Point(18, 233);
            btnDeleteQuestion.Margin = new Padding(2, 2, 2, 2);
            btnDeleteQuestion.Name = "btnDeleteQuestion";
            btnDeleteQuestion.Size = new Size(455, 91);
            btnDeleteQuestion.TabIndex = 3;
            btnDeleteQuestion.Text = "Удалить вопрос";
            btnDeleteQuestion.UseVisualStyleBackColor = false;
            btnDeleteQuestion.Click += btnDeleteQuestion_Click;
            // 
            // btnShowHistory
            // 
            btnShowHistory.BackColor = Color.LightGoldenrodYellow;
            btnShowHistory.Font = new Font("Arial", 13.875F);
            btnShowHistory.ForeColor = SystemColors.ActiveCaptionText;
            btnShowHistory.Location = new Point(18, 328);
            btnShowHistory.Margin = new Padding(2, 2, 2, 2);
            btnShowHistory.Name = "btnShowHistory";
            btnShowHistory.Size = new Size(455, 91);
            btnShowHistory.TabIndex = 4;
            btnShowHistory.Text = "Показать историю";
            btnShowHistory.UseVisualStyleBackColor = false;
            btnShowHistory.Click += btnShowHistory_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            BackColor = Color.DarkKhaki;
            ClientSize = new Size(1088, 452);
            Controls.Add(btnShowHistory);
            Controls.Add(btnDeleteQuestion);
            Controls.Add(btnAddQuestion);
            Controls.Add(btnStartGame);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(2, 2, 2, 2);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GeniusIdiotGame";
            ResumeLayout(false);
        }

        #endregion

        private Button btnStartGame;
        private Button btnAddQuestion;
        private Button btnDeleteQuestion;
        private Button btnShowHistory;
    }
}