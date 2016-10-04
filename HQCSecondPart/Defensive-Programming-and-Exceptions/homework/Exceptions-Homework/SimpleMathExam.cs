using System;

public class SimpleMathExam : Exam
{
    private const string BadResultMassage = "Bad result: nothing done.";
    private const string AverageResultMassage = "Average result: nothing done.";
    private const string HighResultMassage = "High result: nothing done.";
    private const string IncorrectResultMassage = "Invalid number of problems solved!";
    private const int BadResult = 0;
    private const int AverageResult = 1;
    private const int HighResult = 2;
    private const int MinProblemSolved = 0;
    private const int MaxProblemSolved = 10;

    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }
        private set
        {
            var probSolved = CheckProblemsSolvedAndInsertinInRange(value);

            this.problemsSolved = probSolved;
        }
    }

    public override ExamResult Check()
    {
        if (ProblemsSolved == BadResult)
        {
            return new ExamResult(2, 2, 6, BadResultMassage);
        }
        else if (ProblemsSolved == AverageResult)
        {
            return new ExamResult(4, 2, 6, AverageResultMassage);
        }
        else if (ProblemsSolved == HighResult)
        {
            return new ExamResult(6, 2, 6, HighResultMassage);
        }
        else
        {
            return new ExamResult(0, 0, 0, IncorrectResultMassage);
        }
    }

    private int CheckProblemsSolvedAndInsertinInRange(int problemsSolved)
    {
        if (problemsSolved < MinProblemSolved)
        {
            problemsSolved = MinProblemSolved;
        }
        else if (problemsSolved > MaxProblemSolved)
        {
            problemsSolved = MaxProblemSolved;
        }

        return problemsSolved;
    }
}
