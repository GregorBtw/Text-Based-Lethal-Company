using System;
using interfaces.puzzlebehaviours;

namespace puzzles;
public class Puzzle
{
    //Attributes
    public int AttemptsLeft;

    public bool isSolved;

    public IPuzzleBehaviours PuzzleBehaviour;

    //Constructor
    public Puzzle(int attemptsLeft, IPuzzleBehaviours puzzleBehaviour)
    {
        this.AttemptsLeft = attemptsLeft;
        this.PuzzleBehaviour = puzzleBehaviour;
        this.isSolved = false;
    }

    //Methods
    public void AttemptPuzzle()
    {
        //Prompt the puzzle to the player
        PuzzleBehaviour.PromptPuzzle();
    }
}