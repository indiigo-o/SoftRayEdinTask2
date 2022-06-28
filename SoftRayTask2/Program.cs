using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SoftRayTask2
{
    class Program
    {
        public class Foo
        {
            public static List<List<string>> SearchSuggestions(List<string> reviewsRepository, string userInput)
            {
                reviewsRepository = reviewsRepository.OrderBy(q => q).ToList();

                List<List<string>> retList = new List<List<string>>();

                for (int i = 0; i < userInput.Length; i++)
                {
                    List<string> listString = new List<string>();
                    for (int j = 0; j < reviewsRepository.Count; j++)
                    {
                        if (listString.Count < 3 && i < reviewsRepository[j].Length
                                && (reviewsRepository[j].Substring(0, i + 1).Equals(userInput.Substring(0, i + 1))))
                        {
                            listString.Add(reviewsRepository[j]);
                        }
                    }
                    retList.Add(listString);
                }
                return retList;
            }
        }

        public class Solution
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Enter number of List variables!");
                int reviewsRepositoryCount = Convert.ToInt32(Console.ReadLine().Trim());

                List<string> reviewsRepository = new List<string>();

                for (int i = 0; i < reviewsRepositoryCount; i++)
                {
                    Console.WriteLine("Enter " + (i + 1) + " variable!");
                    string reviewsRepositoryItem = Console.ReadLine();
                    reviewsRepository.Add(reviewsRepositoryItem);
                }

                Console.WriteLine("Enter userInput");
                string userInput = Console.ReadLine();

                List<List<string>> foo = Foo.SearchSuggestions(reviewsRepository, userInput);

                Console.WriteLine(String.Join("\n", foo.Select(x => String.Join(" ", x))));
            }
        }
    }
}
