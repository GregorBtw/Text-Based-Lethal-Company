using entitys.players;
using interfaces.puzzlebehaviours;

namespace interfaces.puzzleInfo
{
    public interface IPuzzleInfo
    {
        // Properties
        String Answer { get; set; }
        String Question { get; set; }

    }
}
