using CM2115_25_26_Assessment;
using System;

public class MemoryBased : IPuzzleBehaviours
{
    //Attributes
    public String Description { get; set; }
    public bool IsCompleted { get; set; }

    public String[] Sequence;

    public String[] PlayerSequence;

    //Methods
    public void PromptPuzzle()
    {
        //Prompt the puzzle to the player
    }
}