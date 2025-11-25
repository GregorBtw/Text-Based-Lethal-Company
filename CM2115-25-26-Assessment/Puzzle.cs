using System;
using System.Runtime.CompilerServices;
using entitys.players;
using interfaces.puzzlebehaviours;

namespace puzzles;
public class Puzzle
{
    //Attributes
    public bool isSolved;

    public IPuzzleBehaviours PuzzleBehaviour { get; set; }

    //Constructor
    public Puzzle(IPuzzleBehaviours puzzleBehaviour)
    {
        this.PuzzleBehaviour = puzzleBehaviour;
        this.isSolved = false;
    }

    //Methods
    public void AttemptPuzzle(Player User)
    {
        //Prompt the puzzle to the player
        PuzzleBehaviour.PromptPuzzle();
        PuzzleBehaviour.CheckAnswer(User);
        isSolved = true;
    }
}