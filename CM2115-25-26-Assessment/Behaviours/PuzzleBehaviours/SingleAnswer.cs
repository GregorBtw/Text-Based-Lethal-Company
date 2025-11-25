using System.Collections.Concurrent;
using System;
using interfaces.puzzlebehaviours;
using entitys.players;

namespace behaviours.puzzlebehaviours;

    public class SingleAnswer : IPuzzleBehaviours
    {
        //Attributes
        public string Description { get; set; }

        public string Answer { get; set; }

        public string Question { get; set; }

        //constructor
        public SingleAnswer(string description, string question, string answer)
        {
            this.Description = description;
            this.Question = question;
            this.Answer = answer;
        }

        //Methods
        public void PromptPuzzle()
        {
            //Prompt the puzzle to the player
        }

        public void CheckAnswer(Player User)
        {
            //
        }
    }
