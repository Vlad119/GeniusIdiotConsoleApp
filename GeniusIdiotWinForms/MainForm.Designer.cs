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
            btnStartGame.Location = new Point(24, 54);
            btnStartGame.Name = "btnStartGame";
            btnStartGame.Size = new Size(592, 116);
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
            btnAddQuestion.Location = new Point(24, 176);
            btnAddQuestion.Name = "btnAddQuestion";
            btnAddQuestion.Size = new Size(592, 116);
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
            btnDeleteQuestion.Location = new Point(24, 298);
            btnDeleteQuestion.Name = "btnDeleteQuestion";
            btnDeleteQuestion.Size = new Size(592, 116);
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
            btnShowHistory.Location = new Point(24, 420);
            btnShowHistory.Name = "btnShowHistory";
            btnShowHistory.Size = new Size(592, 116);
            btnShowHistory.TabIndex = 4;
            btnShowHistory.Text = "Показать историю";
            btnShowHistory.UseVisualStyleBackColor = false;
            btnShowHistory.Click += btnShowHistory_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkKhaki;
            ClientSize = new Size(1414, 579);
            Controls.Add(btnShowHistory);
            Controls.Add(btnDeleteQuestion);
            Controls.Add(btnAddQuestion);
            Controls.Add(btnStartGame);
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