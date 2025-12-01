using Observers.HealthBar;
using rooms;
using entitys.players;
using entitys.Creatures;

namespace interfaces.GameData
{
    public interface IGameData
    {
        // Properties
        int Quota { get; set; }
        Player Player { get; }

        //Method signature
        void displayUIinfo(HealthBar healthBar, Room CurrentRoom);
        void PromptTerminal();

    }
}
