namespace TemplateMethod
{
    internal class Startup
    {
        static void Main()
        {
            Drinker pesho = new PeasantDrunker("Pesho");
            pesho.Drink();

            System.Console.WriteLine ("---------------------");

            Drinker gosho = new CityDdrunkar("Gosho");
            gosho.Drink();
        }
    }
}
