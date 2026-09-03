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
        private string userName = "Хитрюга";

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            
            var nameForm = new NameForm();
            nameForm.ShowDialog();

            // Создаём и открываем форму викторины
            
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
