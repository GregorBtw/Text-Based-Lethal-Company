using System;
using System.Runtime.CompilerServices;
using entitys.players;

namespace interfaces.puzzlebehaviours;

public interface IPuzzleBehaviours
{
    // Properties
    String Description { get; set; }

    //Method signature

    void PromptPuzzle(Player User);
}
