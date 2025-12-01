using entitys.players;
using interfaces.puzzlebehaviours;

namespace interfaces.puzzles
{
    public interface IPuzzle
    {
        // Properties
        bool isSolved { get; set; }
        IPuzzleBehaviours PuzzleBehaviour { get; set; }

        //Method signature
        void AttemptPuzzle(Player user);
    }
}
