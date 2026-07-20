namespace GeniusIdiotConsoleApp
{
    public record GameResult(string UserName, int CorrectAnswers, string Diagnosis, DateTime Date);
}


//полный вариант record
//public record GameResult 
//{
//    public string UserName { get; init; }
//    public int CorrectAnswers { get; init; }
//    public string Diagnosis { get; init; }
//    public DateTime Date { get; init; }

//    public GameResult(string UserName, int CorrectAnswers, string Diagnosis, DateTime Date)
//    {
//        this.UserName = UserName;
//        this.CorrectAnswers = CorrectAnswers;
//        this.Diagnosis = Diagnosis;
//        this.Date = Date;
//    }
//}