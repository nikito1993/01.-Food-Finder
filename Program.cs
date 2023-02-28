using System.Xml;

namespace _01_Food_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<char>> Words = new Dictionary<string, HashSet<char>>
            {
                {
                    "pear",new HashSet<char>()
                },
                {
                    "pork", new HashSet<char>()
                },
                {
                   "olive" , new HashSet<char>()
                },
                {
                    "flour", new HashSet<char>()
                }
            };

            Queue<char> vowels = new Queue<char>(string.Join("",Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)));

            Stack<char> consonants = new Stack<char>(string.Join("", Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)));

            while (consonants.Count>0)
            {
                char vowel = vowels.Dequeue();
                char consonat = consonants.Pop();

                foreach (var word in Words)
                {
                    if (word.Key.Contains(vowel))
                    {
                        word.Value.Add(vowel);
                    }
                    if (word.Key.Contains(consonat))
                    {
                        word.Value.Add(consonat);
                    }
                }
                vowels.Enqueue(vowel);
            }
            List<string>WordsFinder=Words.Where(w=>w.Key.Count()==w.Value.Count).Select(w=>w.Key).ToList();

            Console.WriteLine($"Words found: {WordsFinder.Count}");
            Console.WriteLine(string.Join(Environment.NewLine,WordsFinder));
        }
    }
}