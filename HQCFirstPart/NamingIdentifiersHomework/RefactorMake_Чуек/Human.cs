namespace RefactorMake_Чуек
{

    public class Human
    {
        public GendarType Gender { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public void MakeHuman(int ID)
        {
            Human human = new Human();
            human.Age = ID;
            if (ID % 2 == 0)
            {
                human.Name = "Marian";
                human.Gender = GendarType.Man;
            }
            else
            {
                human.Name = "Martina";
                human.Gender = GendarType.Woman;
            }
        }
    }
}
