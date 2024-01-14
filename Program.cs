namespace GuessingGame
{
    internal class Program
    {
        static void Main()
        {
            Play();      
        }

        /// <summary>
        /// Shows the welcome message and asks the user to select the game difficulty.
        /// </summary>
        /// <returns>Game difficulty</returns>
        static int SetDifficulty()
        {
            string welcomeDecoration = new('=', 30);
            Console.Write(welcomeDecoration + "\n" + "Welcome to the guessing game!\n" + welcomeDecoration + "\n\n");

            Dictionary<int, string> difficulties = new()
            {
                { 1, "Easy" },
                { 2, "Normal" },
                { 3, "Hard" }
            };

            Console.WriteLine("Please, select the difficulty:");
            foreach (KeyValuePair<int, string> difficulty in difficulties)
            {
                Console.WriteLine($"{difficulty.Key} - {difficulty.Value}");
            }
            Console.Write("\nYour choice: ");

            int selectedDifficulty;

            while(true)
            {
                try
                {
                    selectedDifficulty = Convert.ToInt32(Console.ReadLine());
                    if (difficulties.ContainsKey(selectedDifficulty)) break;
                    else throw new Exception();
                }
                catch (Exception)
                {
                    Console.Write("Invalid difficulty. Please, try again: ");
                }
            }       

            Console.WriteLine($"\nDifficulty selected: {difficulties[selectedDifficulty]}");
            Thread.Sleep(1500);
            Console.Clear();

            return selectedDifficulty;
        }

        /// <summary>
        /// Generates a random number based on the game difficulty.
        /// </summary>
        /// <returns>Random number</returns>
        static int GenerateNumber(int difficulty)
        {
            Random random = new();
            int number = 0;

            switch (difficulty)
            {
                case 1:
                    Console.WriteLine("I'm going to think a number between 1 and 50.");
                    number = random.Next(1, 50);
                    break;
                case 2:
                    Console.WriteLine("I'm going to think a number between 1 and 100.");
                    number = random.Next(1, 100);
                    break;
                case 3:
                    Console.WriteLine("I'm going to think a number between 1 and 150.");
                    number = random.Next(1, 150);
                    break;
            }

            Thread.Sleep(1500);
            Console.WriteLine("\n*** Number generated. Try to guess it! ***");

            return number;
        }

        /// <summary>
        /// Asks the user to guess the number and shows the result.
        /// </summary>
        static void GuessNumber(int randomNumber)
        {
            int attempts = 0;

            while (true)
            {
                int guess;

                Console.Write("\nYour guess: ");
                while (true)
                {
                    try
                    {
                        if (int.TryParse(Console.ReadLine(), out guess)) break;
                        else throw new Exception();
                    }
                    catch (Exception)
                    {
                        Console.Write("Invalid guess. Please, try again using only numbers: ");
                    }
                }

                attempts++;

                Console.Clear();

                if (guess == randomNumber)
                {
                    string decoration = new('=', 40);
                    Console.Write(decoration + "\n" + "Congratulations! You guessed the number!\n" + decoration + "\n\n");
                    Console.WriteLine($"Attempts: {attempts}");
                    break;
                }
                else if (guess > randomNumber)
                {
                    Console.WriteLine("*** Your guess is higher than the number I thought. Try again! ***");
                }
                else
                {
                    Console.WriteLine("*** Your guess is lower than the number I thought. Try again! ***");
                }
            }
        }

        /// <summary>
        /// Keeps the game running until the user decides to stop playing.
        /// </summary>
        static void Play()
        {
            while (true)
            {
                int difficulty = SetDifficulty();
                int randomNumber = GenerateNumber(difficulty);
                GuessNumber(randomNumber);

                Thread.Sleep(2000);
                Console.Clear();

                Console.Write("Do you want to play again? (Y/N): ");

                while (true)
                {
                    string answer = Console.ReadLine().ToLower();

                    if (answer == "y" || answer == "yes")
                    {
                        Console.Clear();
                        break;
                    }
                    else if (answer == "n" || answer == "no")
                    {
                        Console.WriteLine("\nThanks for playing! See you next time!");
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.Write("Invalid answer. Please, try again: ");
                    }
                }
            }
        }
    }
}
