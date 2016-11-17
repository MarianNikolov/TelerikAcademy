namespace Facade
{
    public class Startup
    {
        static void Main()
        {
            IPlayStationFour playStation = PlayStationFour.CreateInstance();

            playStation.StartGame();
            playStation.NexGame();
            playStation.NexGame();
            playStation.PreviousGame();
            playStation.StopGame();
        }
    }
}
