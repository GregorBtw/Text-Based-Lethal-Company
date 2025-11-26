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
        public void PromptPuzzle(Player User)
        {
            Console.WriteLine($"{Description} \n");

            Console.WriteLine($"{Question}\n");

            Console.WriteLine("Please enter the answer: ");
            String Str = Console.ReadLine();
            String input = Str.ToLower();

            if (input == Answer)
            {
                Console.WriteLine("Puzzle Complete, you pass into the room");
                User.PuzzlesSolved+=1;
                Thread.Sleep(2000);
            }else if (input != Answer)
            {
                Console.WriteLine($"Incorrect, the correct answer was '{Answer}'");
                Console.WriteLine("you take 10 damage and pass through into the room");
                User.SetHp(User.HP-10);
                Thread.Sleep(2000);
            }
       
        }

    }
