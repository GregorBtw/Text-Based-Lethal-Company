using System.Collections.Concurrent;
using System;
using interfaces.puzzlebehaviours;
using entitys.players;

namespace behaviours.puzzlebehaviours;

public class ChoiceBased : IPuzzleBehaviours
{
    // Attributes related to the puzzle, such as the question, answer, and options
    public String Description { get; set; }
    public String Answer { get; set; }
    public String? UserAnswer;
    public String Question { get; set; }
    public String[] Options { get; set; }
    public bool IsCompleted = false;

    // Constructor initializes the puzzle description, question, options, and the correct answer
    public ChoiceBased(String description, String question, String[] options, String answer)
    {
        this.Description = description;
        this.Question = question;
        this.Options = options;
        this.Answer = answer;
    }

    // Method to prompt the player with the puzzle and handle their answer
    public void PromptPuzzle(Player User)
    {
        // Displaying puzzle description and question with options
        Console.WriteLine($"{Description} \n");
        Console.WriteLine($"{Question}\n");

        for(var i = 0; i < Options.Length; i++)
        {
            Console.WriteLine($"• {Options[i]}");
        }

        // Prompt user for input (answer choice)
        Console.WriteLine("\nPlease enter your answer: \n");
        String? rawInput = Console.ReadLine();
        UserAnswer = rawInput.ToUpper();

        // Ensuring valid answer input
        while (UserAnswer != "A" && UserAnswer != "B" && UserAnswer != "C")
        {
            Console.WriteLine("Please enter a valid answer: \n");
            rawInput = Console.ReadLine();
            UserAnswer = rawInput.ToUpper();
        }

        // Checking if the player's answer matches the correct answer
        if (UserAnswer == Answer)
        {
            Console.WriteLine("Puzzle Complete, you pass into the room");
            User.PuzzlesSolved += 1; // Increment puzzles solved
            Thread.Sleep(2000); // Allow the player to read the message
        }
        else
        {
            // Incorrect answer gives penalty and displays the correct answer
            Console.WriteLine($"Incorrect, the correct answer was '{Answer}'");
            Console.WriteLine("You take 10 damage and pass through into the room");
            User.SetHp(User.HP - 20); // Apply penalty to health
            Thread.Sleep(2000);
        }

    }
}
