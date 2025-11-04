using System;

namespace interfaces.puzzlebehaviours;

public interface IPuzzleBehaviours
{
    //Attributes
    String Description { get; set; }

    bool IsCompleted { get; set; }

    //Method signature

    void PromptPuzzle();
}
