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
                reviewsRepository = reviewsRepository.OrderBy(q => q).ToList(); //sortiranje repozitorija

                List<List<string>> retList = new List<List<string>>(); //pravljenje novog repozitorija

                for (int i = 1; i < userInput.Length; i++) //for petlja za svako slovo u userInput
                {
                    List<string> listString = new List<string>(); //pravljenje liste stringova
                    for (int j = 0; j < reviewsRepository.Count; j++) //for petlja za svaku stavku u reviewRepository
                    { //provjera da li je lista vec puna (3 vrijednsti unutar 1 liste), provjera da li taj dio rijeci odgovara rijeci unutar reviewrepozitoriju
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
                int reviewsRepositoryCount = Convert.ToInt32(Console.ReadLine().Trim()); //unos broja varijabli za reviewRepository

                List<string> reviewsRepository = new List<string>(); //pravljenje reviewrepository

                for (int i = 0; i < reviewsRepositoryCount; i++)//unosenje vrijednosti unutar reviewrepository
                {
                    Console.WriteLine("Enter " + (i + 1) + " variable!");
                    string reviewsRepositoryItem = Console.ReadLine();
                    reviewsRepository.Add(reviewsRepositoryItem);
                }

                Console.WriteLine("Enter userInput");
                string userInput = Console.ReadLine(); //unos userInputa

                List<List<string>> foo = Foo.SearchSuggestions(reviewsRepository, userInput); //poziv funkcije za searchalgoritam

                Console.WriteLine(String.Join("\n", foo.Select(x => String.Join(" ", x)))); //ispis
            }
        }
    }
}
