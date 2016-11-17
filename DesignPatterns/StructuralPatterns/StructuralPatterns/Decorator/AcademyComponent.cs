namespace Decorator
{
    public abstract class AcademyComponent
    {
        public string Name { get; set; }

        public string AuditoriumName { get; set; }

        public abstract void PrintOnConsole();
    }
}
