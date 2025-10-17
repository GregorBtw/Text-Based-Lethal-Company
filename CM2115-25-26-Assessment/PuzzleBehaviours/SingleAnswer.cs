using CM2115_25_26_Assessment;
using System;

public class SingleAnswer : IPuzzleBehaviours
{
    //Attributes
    public String Description { get; set; }
    public bool IsCompleted { get; set; }

    public String Answer;

    public String Question;

    //Methods
    public void PromptPuzzle()
    {
        //Prompt the puzzle to the player
    }
}