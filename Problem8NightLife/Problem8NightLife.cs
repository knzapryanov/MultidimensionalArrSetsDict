using System;
using System.Collections.Generic;
using System.Linq;

class Problem8NightLife
{
    public static void Main()
    {
        // PROBLEM ASSIGNMENT
        //
        // Being a nerd means writing programs about night clubs instead of actually going to ones.
        // Spiro is a nerd and he decided to summarize some info about the most popular night clubs around the world. 
        // He's come up with the following structure :
        // – he'll summarize the data by city, where each city will have a list of venues and each venue will have a list of performers.
        // Help him finish the program, so he can stop staring at the computer screen and go get himself a cold beer.
        // You'll receive the input from the console. There will be an arbitrary number of lines until you receive the string "END".
        // Each line will contain data in format: "city;venue;performer". If either city, venue or performer don't exist yet in the database, add them.
        // If either the city and/or venue already exist, update their info.
        // Cities should remain in the order in which they were added, venues should be sorted alphabetically and performers should be unique (per venue) and also sorted alphabetically.
        // Print the data by listing the cities and for each city its venues (on a new line starting with "->") and performers (separated by comma and space).

        // SOLUTION

        // Dictinary with value SortedDictinary which have value SortedSet (all keys are strings)
        Dictionary<string, SortedDictionary<string, SortedSet<string>>> nightLifeDictionary
            = new Dictionary<string, SortedDictionary<string, SortedSet<string>>>();

        string[] inputStringWords = new String[3];
        string city = String.Empty;
        string venue = String.Empty;
        string performer = String.Empty;
        string inputString = String.Empty;
        for (; ; )
        {
            inputString = Console.ReadLine();
            if (inputString == "END")
            {
                break;
            }

            inputStringWords = inputString.Split(';').ToArray();
            city = inputStringWords[0];
            venue = inputStringWords[1];
            performer = inputStringWords[2];

            // If nightLifeDictionary does not contain key same as the current city create new entry
            // with this city as key and value new SortedDictionary 				
            if (!nightLifeDictionary.ContainsKey(city))
            {
                nightLifeDictionary[city] = new SortedDictionary<string, SortedSet<string>>();
            }
            // If the SortedDictionary for the curren city key does not contain key as the current venue
            // create new entry for this SortedDictionary with key venue and value SortedSet
            if (!nightLifeDictionary[city].ContainsKey(venue))
            {
                nightLifeDictionary[city][venue] = new SortedSet<string>();
            }
            // Add the current performer to the SortedSet of this city and venue
            nightLifeDictionary[city][venue].Add(performer);
        }

        // Print
        foreach (var cityVenue in nightLifeDictionary)
        {
            Console.WriteLine(cityVenue.Key);
            foreach (var venuePerformer in cityVenue.Value)
            {
                Console.WriteLine("->{0}: {1}", venuePerformer.Key, String.Join(", ", venuePerformer.Value));
            }
        }
    }
}