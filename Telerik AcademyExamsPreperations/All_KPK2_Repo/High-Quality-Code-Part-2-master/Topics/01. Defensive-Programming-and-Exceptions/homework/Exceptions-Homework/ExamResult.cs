using System;

public class ExamResult
{
    private const string InvalidGradeMassage = "The grade must be greater than zero!";
    private const string InvalidMinGradeMassage = "The min grade must be greater than zero!";
    private const string InvalidMaxGradeMassage = "The max grade must be greater or equal than min grade!";
    private const string InvalidCommentMassage = "The comment must be set!";

    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }
        private set
        {
            if (grade < 0)
            {
                throw new ArgumentOutOfRangeException(InvalidGradeMassage);
            }

            this.grade = value;
        }
    }
    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }
        private set
        {
            if (minGrade < 0)
            {
                throw new ArgumentOutOfRangeException(InvalidMinGradeMassage);
            }

            this.minGrade = value;
        }
    }
    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }
        private set
        {
            this.maxGrade = value;
        }
    }
    public string Comments
    {
        get
        {
            return this.comments;
        }
        private set
        {
            if (comments == null)
            {
                throw new ArgumentNullException(InvalidCommentMassage);
            }

            this.comments = value;
        }
    }
}
