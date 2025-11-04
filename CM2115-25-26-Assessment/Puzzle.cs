using System;
using interfaces.puzzlebehaviours;

namespace puzzles;
public class Puzzle
{
    //Attributes
    public int AttemptsLeft;

    public bool isSolved;

    public String Answer;

    public IPuzzleBehaviours PuzzleBehaviour;

    //Constructor
    public Puzzle(int attemptsLeft, String answer, IPuzzleBehaviours puzzleBehaviour)
    {
        this.AttemptsLeft = attemptsLeft;
        this.Answer = answer;
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