using entitys.players;
using interfaces.puzzlebehaviours;

namespace interfaces.puzzleInfo
{
    public interface IPuzzleInfo
    {
        String Answer { get; set; }
        String Question { get; set; }

    }
}
