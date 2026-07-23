namespace GeniusIdiotConsoleApp;

public class QuestionsStorage
{
    public List<Question> GetQuestions()
    {
        var questionsData = new (string Question, int Answer)[]
        {
            ("Сколько будет 2 + 2 * 2?", 6),
            ("Бревно нужно распилить на 10 частей. Сколько надо сделать распилов?", 9),
            ("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25),
            ("Укол делают каждые полчаса. Сколько нужно минут для трех уколов?", 60),
            ("5 свечей горело, 2 потухли. Сколько свечей осталось?", 2),
            ("В комнате 4 угла, в каждом углу сидит кошка. Напротив каждой кошки сидят 3 кошки. Сколько всего кошек в комнате?", 4),
            ("Шел мужик в Москву и повстречал 7 женщин. Сколько человек шло в Москву?", 1),
            ("Сколько яиц можно съесть натощак?", 1),
            ("В семье 5 сыновей и у каждого есть сестра. Сколько детей в семье?", 6),
            ("Сколько месяцев в году имеют 28 дней?", 12)
        };
        var questions = questionsData.Select(q => new Question(q.Question, q.Answer)).ToList();
        return questions;
    }

    public List<Question> ShuffleQuestions(List<Question> questions)
    {
        return questions.OrderBy(x => Random.Shared.Next()).ToList();
    }  
}