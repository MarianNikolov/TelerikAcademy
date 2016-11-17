namespace Composite
{
    public class Startup
    {
        static void Main()
        {
            ITrainer viktor = new Trainer("Viktor");

            ITrainer ivan = new Trainer("Ivan");
            viktor.AddPerson(ivan);
            IStudent pesho = new Student("Pesho");
            IStudent gosho = new Student("Gosho");
            IStudent simeon = new Student("Simeon");
            ivan.AddPerson(pesho);
            ivan.AddPerson(gosho);
            ivan.AddPerson(simeon);

            ITrainer marto = new Trainer("Marto");
            viktor.AddPerson(marto);
            IStudent drago = new Student("Drago");
            IStudent sasho = new Student("Sasho");
            IStudent milen = new Student("Milen");
            marto.AddPerson(drago);
            marto.AddPerson(sasho);
            marto.AddPerson(milen);

            ITrainer stivi = new Trainer("Stivi");
            viktor.AddPerson(stivi);
            IStudent mimi = new Student("Mimi");
            IStudent galq = new Student("Galq");
            IStudent petq = new Student("Petq");
            stivi.AddPerson(mimi);
            stivi.AddPerson(galq);
            stivi.AddPerson(petq);

            viktor.PrintOnConsole(4);
        }
    }
}
