using System.Collections.Concurrent;
using System;
using interfaces.puzzlebehaviours;
using entitys.players;
using System.Runtime.Serialization;

namespace behaviours.puzzlebehaviours;

public class MemoryBased : IPuzzleBehaviours
{
    // Attributes for the puzzle, including description, sequences, and player sequence
    public String Description { get; set; }
    public List<String> Sequence = new List<String>();
    public List<String> PlayerSequence = new List<String>();

    // Constructor initializes the puzzle description
    public MemoryBased(String description)
    {
        this.Description = description;
    }

    // Method to prompt the player with the memory puzzle and handle their input
    public void PromptPuzzle(Player User)
    {
        Random rnd = new Random();
        Char[] charsToRemove = [' ', ',']; // For removing unwanted characters from player input

        Console.WriteLine($"{Description} \n");

        Console.WriteLine("Please type 'Start' to begin");
        String? rawInput = Console.ReadLine();
        String input = rawInput.ToLower();

        // Wait for user to type 'Start' before beginning the sequence
        while (input != "start")
        {
            Console.WriteLine("Please type 'Start' to begin");
            rawInput = Console.ReadLine();
            input = rawInput.ToLower();
        }

        // If 'Start' is entered, begin showing the sequence
        if (input == "start")
        {
            // Generate a sequence of random numbers (0 or 1)
            for (var i = 0; i < 8; i++)
            {
                int Number = rnd.Next(0, 2); // Generate random 0 or 1
                String Str = Number.ToString();
                Sequence.Add(Str);

                Console.Clear();
                Console.WriteLine($"\nSequence: {string.Join(", ", Sequence)}\n");
                Thread.Sleep(2500); // Pause to show the sequence to the player
                Console.Clear();

                Console.WriteLine("Please enter the sequence that was shown, leaving a , between characters: ");
                String? SequenceInput = Console.ReadLine();
                string result = new string(SequenceInput.Where(c => !charsToRemove.Contains(c)).ToArray());

                // Compare the player's input to the sequence
                for (var chara = 0; chara < result.Length; chara++)
                {
                    PlayerSequence.Add(result[chara].ToString());
                }

                // If the player gets the sequence right, continue
                if (PlayerSequence.SequenceEqual(Sequence))
                {
                    Console.WriteLine("Correct");
                    PlayerSequence.Clear();
                    if (i == 8)
                    {
                        Console.WriteLine("Puzzle Complete, you pass into the room");
                        User.PuzzlesSolved += 1; // Increment puzzles solved
                        Thread.Sleep(2000); // Allow the player to read the message
                    }
                }
                else
                {
                    // If incorrect, show the penalty and exit the puzzle
                    Console.WriteLine("Incorrect sequence");
                    Console.WriteLine("You take 10 damage and pass through into the room");
                    User.SetHp(User.HP - 10); // Apply penalty to health
                    Thread.Sleep(2000);
                    return;
                }
            }
        }

    }
}
