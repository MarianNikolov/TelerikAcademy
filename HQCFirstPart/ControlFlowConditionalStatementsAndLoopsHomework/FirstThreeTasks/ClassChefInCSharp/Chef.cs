namespace ClassChefInCSharp
{
    public class Chef
    {
        public void Cook()
        {
            Potato potato = GetPotato();
            Peel(potato);
            Cut(potato);

            Carrot carrot = GetCarrot();
            Peel(carrot);
            Cut(carrot);

            Bowl bowl;
            bowl = GetBowl();
            bowl.Add(potato);
            bowl.Add(carrot);
        }

        public void Cook(Vegetable vegetable)
        {
            Peel(vegetable);
            Cut(vegetable);

            Bowl bowl;
            bowl = GetBowl();
            bowl.Add(vegetable);
            bowl.Add(vegetable);
        }

        public Potato GetPotato()
        {
            var potato = new Potato();

            return potato;
        }

        public Carrot GetCarrot()
        {
            var carrot = new Carrot();

            return carrot;
        }

        public Bowl GetBowl()
        {
            var bowl = new Bowl();

            return bowl;
        }

        public void Peel(Vegetable vegetable)
        {
            vegetable.ThereVegetablePeel = false;
        }

        private void Cut(Vegetable vegetable)
        {
            vegetable.IsCut = true;
        }
    }
}
