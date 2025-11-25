using System.Collections.Concurrent;
using System;
using interfaces.puzzlebehaviours;
using entitys.players;


namespace behaviours.puzzlebehaviours;
public class MemoryBased : IPuzzleBehaviours
{
    //Attributes
    public String Description { get; set; }

    public String[] Sequence;

    public String[] PlayerSequence;

    //constructor
    public MemoryBased(String description, String[] sequence)
    {
        this.Description = description;
        this.Sequence = sequence;
    }

    //Methods
    public void PromptPuzzle()
    {
        //Prompt the puzzle to the player
    }

    public void CheckAnswer(Player User)
    {
        //
    }
}