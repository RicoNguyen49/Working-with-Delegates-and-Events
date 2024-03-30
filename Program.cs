using System;

namespace delegatesAndEvents
{
    // Create a delegate
    public delegate void RaceEventNotify(int winner);

    public class Race
    {
        // Create a delegate event object
        public event RaceEventNotify RaceEvent;

        public void Racing(int contestants, int laps)
        {
            Console.WriteLine("Ready\nSet\nGo!");
            Random r = new Random();
            int[] participants = new int[contestants];
            bool done = false;
            int champ = -1;
            // First to finish specified number of laps wins
            while (!done)
            {
                for (int i = 0; i < contestants; i++)
                {
                    if (participants[i] <= laps)
                    {
                        participants[i] += r.Next(1, 5);
                    }
                    else
                    {
                        champ = i;
                        done = true;
                        continue;
                    }
                }
            }

            // Invoke the delegate event object and pass champ to the method
            TheWinner(champ);
        }
        private void TheWinner(int champ)
        {
            Console.WriteLine("We have a winner!");
            RaceEvent(champ);
            // invoke the delegate event object and pass champ to the method

        }
    }

    class Program
    {
        public static void Main()
        {
            // Create a class object
            Race round1 = new Race();

            // Register with the footRace event and trigger the event
            round1.RaceEvent += footRace;
            round1.Racing(15, 10); // 15 contestants, 10 laps

            // Register with the carRace event and trigger the event
            round1.RaceEvent += carRace;
            round1.Racing(10, 15); 

            // Register a bike race event using a lambda expression and trigger the event
            round1.RaceEvent += winner => Console.WriteLine($"Biker number {winner} is the winner.");
            round1.Racing(7, 12); 
        }

        // Event handlers
        public static void carRace(int winner)
        {
            Console.WriteLine($"Car number {winner} is the winner.");
        }

        public static void footRace(int winner)
        {
            Console.WriteLine($"Racer number {winner} is the winner.");
        }
    }
}
