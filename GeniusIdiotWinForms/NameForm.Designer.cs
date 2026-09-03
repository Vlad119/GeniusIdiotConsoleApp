namespace GeniusIdiotWinForms
{
    partial class NameForm
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
            label = new Label();
            userNameTxtBox = new TextBox();
            btnStartQiuz = new Button();
            SuspendLayout();
            // 
            // label
            // 
            label.AutoSize = true;
            label.BackColor = Color.DarkKhaki;
            label.Font = new Font("Segoe UI", 20F);
            label.Location = new Point(75, 143);
            label.Margin = new Padding(2, 0, 2, 0);
            label.Name = "label";
            label.Size = new Size(903, 54);
            label.TabIndex = 23;
            label.Text = "Для того, чтобы продолжить, введите Ваше имя";
            label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // userNameTxtBox
            // 
            userNameTxtBox.BackColor = Color.LightGoldenrodYellow;
            userNameTxtBox.Font = new Font("Segoe UI", 19.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            userNameTxtBox.Location = new Point(75, 261);
            userNameTxtBox.Margin = new Padding(2);
            userNameTxtBox.Name = "userNameTxtBox";
            userNameTxtBox.Size = new Size(619, 60);
            userNameTxtBox.TabIndex = 24;
            // 
            // btnStartQiuz
            // 
            btnStartQiuz.BackColor = Color.LightGoldenrodYellow;
            btnStartQiuz.Font = new Font("Arial", 19.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnStartQiuz.ForeColor = SystemColors.ActiveCaptionText;
            btnStartQiuz.Location = new Point(722, 255);
            btnStartQiuz.Margin = new Padding(2);
            btnStartQiuz.Name = "btnStartQiuz";
            btnStartQiuz.Size = new Size(240, 78);
            btnStartQiuz.TabIndex = 25;
            btnStartQiuz.Text = "Запуск";
            btnStartQiuz.UseVisualStyleBackColor = false;
            btnStartQiuz.Click += btnStartQiuz_Click;
            // 
            // NameForm
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            BackColor = Color.DarkKhaki;
            ClientSize = new Size(1088, 452);
            Controls.Add(btnStartQiuz);
            Controls.Add(userNameTxtBox);
            Controls.Add(label);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(2);
            Name = "NameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NameForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label;
        private TextBox userNameTxtBox;
        private Button btnStartQiuz;
    }
}