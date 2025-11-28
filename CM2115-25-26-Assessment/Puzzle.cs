using System;
using System.Runtime.CompilerServices;
using entitys.players;
using interfaces.puzzlebehaviours;

namespace puzzles;

public class Puzzle
{
    // Tracks whether the puzzle has been solved.
    public bool isSolved;

    // Behaviour interface allowing different types of puzzles.
    // Uses Strategy Pattern to delegate puzzle logic (e.g., riddle, lock, mini-game).
    public IPuzzleBehaviours PuzzleBehaviour { get; set; }

    // Initializes a puzzle with a specific behaviour.
    public Puzzle(IPuzzleBehaviours puzzleBehaviour)
    {
        this.PuzzleBehaviour = puzzleBehaviour;
        this.isSolved = false;
    }

    // Attempts to solve the puzzle by delegating to its behaviour.
    // Marks the puzzle as solved in the player's current room after completion.
    public void AttemptPuzzle(Player User)
    {
        PuzzleBehaviour.PromptPuzzle(User);
        User.CurrentRoom.Puzzle.isSolved = true;
    }
}
