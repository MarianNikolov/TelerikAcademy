namespace Decorator
{
    public class CourseWithTrainer : Decorator
    {
        public string TrainerName { get; set; }

        public CourseWithTrainer(AcademyComponent academyComponent, string trainerName) : base(academyComponent)
        {
            this.TrainerName = trainerName;
        }

        public override void PrintOnConsole()
        {
            base.PrintOnConsole();
            System.Console.WriteLine($"   Trainer: {this.TrainerName}");
        }
    }
}
