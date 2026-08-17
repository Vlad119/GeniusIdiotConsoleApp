using GeniusIdiot.Core.Managers;
using GeniusIdiot.Core.Models;

namespace GeniusIdiotWinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private readonly QuestionManager questionManager = new();
        private readonly ResultManager resultManager = new("results.json");
        private string userName = "";

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            var questions = questionManager.GetQuestions();
            if (questions.Count == 0)
            {
                MessageBox.Show("Внимание! Не найдено ни одного вопроса, пожалуйста добавьте их вручную");
                return;
            }
            var shuffledQuestions = questionManager.ShuffleQuestions(questions);

            // Создаём и открываем форму викторины
            var quizForm = new QuizForm(shuffledQuestions);
            quizForm.ShowDialog();
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
         
        }

        private void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
      
        }

        private void btnShowHistory_Click(object sender, EventArgs e)
        {
        
        }
    }
}
