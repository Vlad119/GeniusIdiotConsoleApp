namespace GeniusIdiot.Core.Models;
public record Question(string QuizQuestion, int CorrectAnswer)
{
    public bool CheckCorrectAnswer(int userAnswer) => CorrectAnswer == userAnswer;
}