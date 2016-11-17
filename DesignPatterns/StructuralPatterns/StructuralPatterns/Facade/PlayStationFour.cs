using System;
using System.Collections.Generic;

namespace Facade
{
    /// <summary>
    /// Facade
    /// </summary>
    public class PlayStationFour : IPlayStationFour
    {
        private static Supply supplay = new Supply();
        private static List<Game> game = new List<Game>();
       
        private PlayStationFour()
        {
            game.Add(new Game() {Title = "Hallo 666" });
            game.Add(new Game() {Title = "Fifa 2017" });
        }

        public static PlayStationFour CreateInstance()
        {
            return new PlayStationFour();
        }
        public void StartGame()
        {
            supplay.CheckForSupply();
            supplay.StartSupply();
            Console.WriteLine("Game started...");
        }
        
        public void StopGame()
        {
            Console.WriteLine("Bye bye");
            supplay.StopSupply();

        }

        public void NexGame()
        {
            Console.WriteLine("Next game ...");
        }

        public void PreviousGame()
        {
            Console.WriteLine("Previous game ...");
        }
    }
}