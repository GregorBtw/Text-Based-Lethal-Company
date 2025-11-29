using entitys.players;
using interfaces.puzzlebehaviours;

namespace interfaces.puzzles
{
    public interface IPuzzle
    {
        bool isSolved { get; set; }
        IPuzzleBehaviours PuzzleBehaviour { get; set; }

        void AttemptPuzzle(Player user);
    }
}
