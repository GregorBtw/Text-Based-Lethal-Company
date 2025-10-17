using System;

namespace CM2115_25_26_Assessment;

public interface IPuzzleBehaviours
{
    //Attributes
    String Description { get; set; }

    bool IsCompleted { get; set; }

    //Method signature

    void PromptPuzzle();
}
