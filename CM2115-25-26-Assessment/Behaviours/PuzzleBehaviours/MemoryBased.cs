using System.Collections.Concurrent;
using System;
using interfaces.puzzlebehaviours;
using entitys.players;
using System.Runtime.Serialization;


namespace behaviours.puzzlebehaviours;
public class MemoryBased : IPuzzleBehaviours
{
    //Attributes
    public String Description { get; set; }

    public List<String> Sequence = new List<String>();

    public List<String> PlayerSequence = new List<String>();

    //constructor
    public MemoryBased(String description)
    {
        this.Description = description;
    }

    //Methods
    public void PromptPuzzle(Player User)
    {
        Random rnd = new Random();
        Char[] charsToRemove = [' ', ','];

        Console.WriteLine($"{Description} \n");

        Console.WriteLine("Please type 'Start' to begin");
        String rawInput = Console.ReadLine();
        String input = rawInput.ToLower();

        while (input != "start")
        {
            Console.WriteLine("Please type 'Start' to begin");
            rawInput = Console.ReadLine();
            input = rawInput.ToLower();
        }

        if (input == "start")
        {
            for(var i = 0; i < 8; i++)
            {
                int Number = rnd.Next(0, 2);
                String Str = Number.ToString();
                Sequence.Add(Str);

                Console.WriteLine($"\nSequence: {string.Join(", ", Sequence)}\n");
                Thread.Sleep(2500);
                Console.Clear();

                Console.WriteLine("Please enter the sequence that was shown, leaving a , inbetween characters: ");
                String SequenceInput = Console.ReadLine();
                string result = new string(SequenceInput.Where(c => !charsToRemove.Contains(c)).ToArray());
                

                for(var chara = 0;chara < result.Length; chara++)
                {
                    PlayerSequence.Add(result[chara].ToString());
                }

                if (PlayerSequence.SequenceEqual(Sequence))
                {
                    Console.WriteLine("Correct");
                    PlayerSequence.Clear();
                }else if(PlayerSequence != Sequence)
                {
                    Console.WriteLine("Incorrect sequence");
                    Console.WriteLine("you take 10 damage and pass through into the room");
                    Thread.Sleep(2000);
                    return;
                }

            }           
        }

    }
}