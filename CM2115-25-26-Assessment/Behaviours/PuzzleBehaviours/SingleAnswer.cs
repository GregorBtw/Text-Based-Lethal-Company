using interfaces.puzzlebehaviours;
using System;

namespace behaviours.puzzlebehaviours;
public class SingleAnswer : IPuzzleBehaviours
{
    //Attributes
    public String Description { get; set; }
    public bool IsCompleted { get; set; }

    public String Answer;

    public String Question;

    //constructor
    public SingleAnswer(String description, String question, String answer)
    {
        this.Description = description;
        this.Question = question;
        this.Answer = answer;
        this.IsCompleted = false;
    }

    //Methods
    public void PromptPuzzle()
    {
        //Prompt the puzzle to the player
    }
}