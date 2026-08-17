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
            quizQuestionTxtBox.Text = questions[0].QuizQuestion;
        }

        private void label_Click(object sender, EventArgs e)
        {

        }
    }
}