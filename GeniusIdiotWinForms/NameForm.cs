using GeniusIdiot.Core.Managers;
using GeniusIdiot.Core.Models;

namespace GeniusIdiotWinForms
{
    public partial class NameForm : Form
    {
        public NameForm()
        {
            InitializeComponent();
        }


        private readonly QuestionManager questionManager = new();
        private readonly ResultManager resultManager = new("results.json");

        private void btnStartQiuz_Click(object sender, EventArgs e)
        {
            User user = new User(userNameTxtBox.Text);
            var questions = questionManager.GetQuestions();
            if (questions.Count == 0)
            {
                MessageBox.Show("Внимание! Не найдено ни одного вопроса, пожалуйста добавьте их вручную");
                return;
            }
            var shuffledQuestions = questionManager.ShuffleQuestions(questions);
            var quizForm = new QuizForm(shuffledQuestions);
            quizForm.ShowDialog();
            this.Close();
        }
    }
}
