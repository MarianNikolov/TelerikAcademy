namespace Decorator
{
    public class CourseWithRepositoryDirectory : Decorator
    {
        public CourseWithRepositoryDirectory(AcademyComponent academyComponent) 
            : base(academyComponent)
        {
            
        }

        public string DirectoryName { get; set; }

        public void SetDirectory(string fullPath)
        {
            this.DirectoryName = fullPath;
        }

        public override void PrintOnConsole()
        {
            base.PrintOnConsole();

            System.Console.WriteLine($"   Repository directory: {this.DirectoryName}");
        }
    }
}
