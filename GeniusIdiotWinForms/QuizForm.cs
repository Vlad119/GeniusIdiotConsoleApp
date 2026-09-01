using GeniusIdiot.Core.Models;

namespace GeniusIdiotWinForms
{
    public partial class QuizForm : Form
    {
        private readonly List<Question> questions;
        private int currentQuestionIndex = 0;
        private int correctAnswersCount = 0;

        public QuizForm(List<Question> questions)
        {
            InitializeComponent();
            progressBar1.ForeColor = Color.LightGoldenrodYellow;
            this.questions = questions;
            quizQuestionTxtBox.Text = questions[currentQuestionIndex].QuizQuestion;
        }


        private void DigitButton_Click(object sender, EventArgs e)
        {
            if (answerLabel.Text.Length != 4)
            {
                Button button = (Button)sender;
                answerLabel.Text += button.Text;
            }
        }

        private void btnAC_Click(object sender, EventArgs e)
        {
            answerLabel.Text = "";
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (answerLabel.Text.Length > 0)
            {
                answerLabel.Text = answerLabel.Text.Remove(answerLabel.Text.Length - 1);
            }
        }

        private void btnNextQuestion_Click(object sender, EventArgs e)
        {
            int answer;
            if (!int.TryParse(answerLabel.Text, out answer))
            {
                MessageBox.Show("Ответ не может быть пустым!");
                return;
            }
            if (questions[currentQuestionIndex].CheckCorrectAnswer(answer))
            {
                correctAnswersCount++;
            }
            if (currentQuestionIndex != questions.Count - 1)
            {
                currentQuestionIndex++;
                quizQuestionTxtBox.Text = questions[currentQuestionIndex].QuizQuestion;
                progressBar1.Value = (currentQuestionIndex * 100) / questions.Count;
                answerLabel.Text = "";
            }
            else
            {
                progressBar1.Value = progressBar1.Maximum;
                MessageBox.Show($"Правильных ответов: {correctAnswersCount}");
                this.Close();
            }
        }
    }
}