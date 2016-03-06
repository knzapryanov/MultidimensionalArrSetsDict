using System;
using System.Collections.Generic;
using System.Linq;

class Problem7Phonebook
{
    public static void Main()
    {
        Dictionary<string, string> phonebook = new Dictionary<string, string>();
        string currentName = String.Empty;
        string currentPhone = String.Empty;
        for (int i = 0; i < 3; i++)
        {
            currentName = Console.ReadLine();
            currentPhone = Console.ReadLine();
            if (phonebook.ContainsKey(currentName))
            {
                phonebook[currentName] = phonebook[currentName] + "; " + currentPhone;
            }
            else
            {
                phonebook[currentName] = currentPhone;
            }
        }

        Console.WriteLine("Enter the command \"search\" to search the phonebook:");
        string command = Console.ReadLine();
        if (command == "search")
        {
            for (; ; )
            {
                string searchedName = Console.ReadLine();
                if (searchedName != "END")
                {
                    bool isNameFound = false;
                    foreach (var pair in phonebook)
                    {
                        if (pair.Key == searchedName)
                        {
                            isNameFound = true;
                            Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
                        }
                    }
                    if (!isNameFound)
                    {
                        Console.WriteLine("Contact {0} does not exist.", searchedName);
                    }
                }
                else
                {
                    break;
                }
            }
        }
        else
        {
            Console.WriteLine("Inavlid command!");
        }
    }
}