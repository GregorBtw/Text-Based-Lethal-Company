using System.Collections.Concurrent;
using System;
using interfaces.puzzlebehaviours;

namespace behaviours.puzzlebehaviours;
public class ChoiceBased : IPuzzleBehaviours
{
    //Attributes

    public String Description { get; set; }

    public String Answer;
    public String Question;
    public String[] Options;
    public bool IsCompleted { get; set; }

    //constructor
    public ChoiceBased(String description, String question, String[] options, String answer)
    {
        this.Description = description;
        this.Question = question;
        this.Options = options;
        this.Answer = answer;
        this.IsCompleted = false;
    }

    //methods

    public void PromptPuzzle()
    {
        //Prompt the puzzle to the player
    }
}