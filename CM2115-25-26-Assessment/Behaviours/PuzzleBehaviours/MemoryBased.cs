using System.Collections.Generic;
using interfaces.puzzlebehaviours;
using System;

namespace behaviours.puzzlebehaviours;
public class MemoryBased : IPuzzleBehaviours
{
    //Attributes
    public String Description { get; set; }
    public bool IsCompleted { get; set; }

    public String[] Sequence;

    public String[] PlayerSequence;

    //constructor
    public MemoryBased(String description, String[] sequence)
    {
        this.Description = description;
        this.Sequence = sequence;
        this.IsCompleted = false;
    }

    //Methods
    public void PromptPuzzle()
    {
        //Prompt the puzzle to the player
    }
}