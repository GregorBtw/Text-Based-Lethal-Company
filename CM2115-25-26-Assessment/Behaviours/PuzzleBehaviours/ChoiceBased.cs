using System.Collections.Concurrent;
using System;
using interfaces.puzzlebehaviours;
using entitys.players;

namespace behaviours.puzzlebehaviours;
public class ChoiceBased : IPuzzleBehaviours
{
    //Attributes

    public String Description { get; set; }

    public String Answer { get; set; }

    public String UserAnswer { get; set; }
    public String Question;
    public String[] Options { get; set; }
    public bool IsCompleted = false;

    //constructor
    public ChoiceBased(String description, String question, String[] options, String answer)
    {
        this.Description = description;
        this.Question = question;
        this.Options = options;
        this.Answer = answer;
    }

    //methods

    public void PromptPuzzle()
    {

            Console.WriteLine($"{Description} \n");

            Console.WriteLine($"{Question}\n");

            for(var i = 0; i < Options.Length; i++)
            {
                Console.WriteLine($"• {Options[i]}");
            }

            Console.WriteLine("\nPlease enter your answer: \n");
            String rawInput = Console.ReadLine();
            UserAnswer = rawInput.ToUpper();
        while (UserAnswer != "A" && UserAnswer != "B" && UserAnswer != "C")
        {
            Console.WriteLine("Please enter a valid answer: \n");
            rawInput = Console.ReadLine();
            UserAnswer = rawInput.ToUpper();
        }

    }

    public void CheckAnswer(Player User)
    {
        if (UserAnswer==Answer)
        {
            Console.WriteLine("Puzzle Complete, you pass into the room");
            Thread.Sleep(2000);
        
        }else if (UserAnswer!=Answer)
        {
            Console.WriteLine($"Incorrect, the correct answer was '{Answer}'");
            Console.WriteLine("you take 10 damage and pass through into the room");
            User.SetHp(User.HP-10);
            Thread.Sleep(2000);
        }
    }
}