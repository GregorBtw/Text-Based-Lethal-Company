using System.Collections.Concurrent;
using System;
using interfaces.puzzlebehaviours;
using entitys.players;

namespace behaviours.puzzlebehaviours;

public class SingleAnswer : IPuzzleBehaviours
{
    // Attributes for the puzzle, including description, question, and correct answer
    public string Description { get; set; }  // A short description of the puzzle
    public string Answer { get; set; }       // The correct answer to the puzzle
    public string Question { get; set; }     // The actual question asked in the puzzle

    // Constructor initializes the puzzle description, question, and correct answer
    public SingleAnswer(string description, string question, string answer)
    {
        this.Description = description;
        this.Question = question;
        this.Answer = answer;
    }

    // Method to prompt the player with the puzzle and handle their input
    public void PromptPuzzle(Player User)
    {
        // Display the puzzle description and the question to the player
        Console.WriteLine($"{Description} \n");
        Console.WriteLine($"{Question}\n");

        // Prompt the player for their answer
        Console.WriteLine("Please enter the answer: ");
        String? Str = Console.ReadLine();   // Read the player's input
        String input = Str.ToLower();       // Convert the input to lowercase for case-insensitivity

        // Check if the player's input matches the correct answer
        if (input == Answer)
        {
            // If the answer is correct, display a success message and increment the puzzle count
            Console.WriteLine("Puzzle Complete, you pass into the room");
            User.PuzzlesSolved += 1;  // Increase the number of puzzles solved by the player
            Thread.Sleep(2000);        // Wait for 2 seconds before proceeding
        }
        else
        {
            // If the answer is incorrect, display the correct answer and apply a penalty
            Console.WriteLine($"Incorrect, the correct answer was '{Answer}'");
            Console.WriteLine("You take 10 damage and pass through into the room");
            User.SetHp(User.HP - 20);  // Apply 10 damage to the player's health
            Thread.Sleep(2000);        // Wait for 2 seconds before proceeding
        }

    }
}
