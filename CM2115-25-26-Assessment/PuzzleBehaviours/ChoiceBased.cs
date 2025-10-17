using System.Collections.Concurrent;
using CM2115_25_26_Assessment;

public class ChoiceBased : IPuzzleBehaviours
{
    //Attributes

    public String Description { get; set; }

    public String Answer;
    public String Question;
    public String[] Options;
    public bool IsCompleted { get; set; }

    //methods

    public void PromptPuzzle()
    {
        //Prompt the puzzle to the player
    }
}