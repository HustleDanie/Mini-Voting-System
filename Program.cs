using System;
using System.Collections.Generic;

class Candidate
{
    public string Name { get; set; }
    public int Votes { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Candidate> candidates = new List<Candidate>();

        Console.WriteLine("Welcome to the Mini Voting System!");

        // Add candidates
        Console.WriteLine("\nPlease enter the names of the candidates (press enter to finish):");
        string name = Console.ReadLine();
        while (!string.IsNullOrEmpty(name))
        {
            candidates.Add(new Candidate { Name = name });
            name = Console.ReadLine();
        }

        // Start voting
        Console.WriteLine("\nVoting has started!");

        bool doneVoting = false;
        while (!doneVoting)
        {
            Console.WriteLine("\nPlease enter the number of the candidate you want to vote for (press enter to finish):");
            for (int i = 0; i < candidates.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, candidates[i].Name);
            }

            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                doneVoting = true;
            }
            else
            {
                int candidateIndex;
                if (int.TryParse(input, out candidateIndex) && candidateIndex > 0 && candidateIndex <= candidates.Count)
                {
                    candidates[candidateIndex - 1].Votes++;
                    Console.WriteLine("Vote recorded!");
                }
                else
                {
                    Console.WriteLine("Invalid candidate number.");
                }
            }
        }

        // End voting and display results
        Console.WriteLine("\nVoting has ended!");
        Console.WriteLine("\nResults:");

        for (int i = 0; i < candidates.Count; i++)
        {
            Console.WriteLine("{0}. {1}: {2} vote(s)", i + 1, candidates[i].Name, candidates[i].Votes);
        }

        Console.ReadKey();
    }
}
