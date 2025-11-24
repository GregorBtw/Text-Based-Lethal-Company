using System.Collections.Concurrent;
using System;
using interfaces.puzzlebehaviours;

namespace behaviours.puzzlebehaviours;
public class ChoiceBased : IPuzzleBehaviours
{
    //Attributes

    public String Description { get; set; }

    public String[] Answers { get; set; }

    public String[] UserAnswers;
    public String Question;
    public String[] Options { get; set; }
    public bool IsCompleted { get; set; }

    //constructor
    public ChoiceBased(String description, String question, String[] options, String[] answers)
    {
        this.Description = description;
        this.Question = question;
        this.Options = options;
        this.Answers = answers;
        this.IsCompleted = false;
    }

    //methods

    public void PromptPuzzle()
    {

        for(var list = 0; list < Options.Length; list++)
        {
            Console.WriteLine("This room contains a choice based puzzle, to pass through you must answer the following: \n");

            Console.WriteLine($"{Question}\n");

            for(var item = 0; item < Options[list].Length; item++)
            {
                Console.WriteLine($"• {Options}");
            }

            Console.WriteLine("Please enter your answer: \n");
            String rawInput = Console.ReadLine();
            UserAnswers.Append(rawInput.ToLower());
        
        }

    }
}