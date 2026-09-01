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
            label.Location = new Point(97, 183);
            label.Name = "label";
            label.Size = new Size(1224, 72);
            label.TabIndex = 23;
            label.Text = "Для того, чтобы продолжить, введите Ваше имя";
            label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // userNameTxtBox
            // 
            userNameTxtBox.BackColor = Color.LightGoldenrodYellow;
            userNameTxtBox.Font = new Font("Segoe UI", 19.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            userNameTxtBox.Location = new Point(97, 334);
            userNameTxtBox.Name = "userNameTxtBox";
            userNameTxtBox.Size = new Size(804, 78);
            userNameTxtBox.TabIndex = 24;
            // 
            // btnStartQiuz
            // 
            btnStartQiuz.BackColor = Color.LightGoldenrodYellow;
            btnStartQiuz.Font = new Font("Arial", 19.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnStartQiuz.ForeColor = SystemColors.ActiveCaptionText;
            btnStartQiuz.Location = new Point(939, 326);
            btnStartQiuz.Name = "btnStartQiuz";
            btnStartQiuz.Size = new Size(312, 100);
            btnStartQiuz.TabIndex = 25;
            btnStartQiuz.Text = "Запуск";
            btnStartQiuz.UseVisualStyleBackColor = false;
            // 
            // NameForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkKhaki;
            ClientSize = new Size(1414, 579);
            Controls.Add(btnStartQiuz);
            Controls.Add(userNameTxtBox);
            Controls.Add(label);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
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