using System;

public class CSharpExam : Exam
{
    private const int MinScore = 0;
    private const int MaxScore = 100;
    private const string InvalidScoreMassage = "Score must be greater than zero!";
    private const string ExamComment = "Exam results calculated by score.";

    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }
        private set
        {
            ChekInputScoreIsCorrect(value);

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        ChekInputScoreIsCorrect(Score);

        return new ExamResult(this.Score, MinScore, MaxScore, ExamComment);
    }

    private void ChekInputScoreIsCorrect(int score)
    {
        if (score < MinScore || score > MaxScore)
        {
            throw new ArgumentOutOfRangeException(InvalidScoreMassage);
        }
    }
}

