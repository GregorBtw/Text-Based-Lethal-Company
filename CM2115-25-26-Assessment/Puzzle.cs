using CM2115_25_26_Assessment;
using System;

public class Puzzle
{
    //Attributes
    public int AttemptsLeft;

    public bool isSolved;

    public String Answer;

    public IPuzzleBehaviours PuzzleBehaviour;

    //Methods
    public void AttemptPuzzle()
    {
        //Prompt the puzzle to the player
        PuzzleBehaviour.PromptPuzzle();
    }
}