using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_NumberWars
{
    class Startup
    {
        static void Main()
        {
            var deck1 = new Queue<KeyValuePair<int, char>>();
            var deck2 = new Queue<KeyValuePair<int, char>>();
            var played1 = new List<KeyValuePair<int, char>>();
            var played2 = new List<KeyValuePair<int, char>>();

            var tokens = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (var token in tokens)
            {
                deck1.Enqueue(new KeyValuePair<int, char>(int.Parse(token.Substring(0, token.Length - 1)), token[token.Length - 1]));
            }
            tokens = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (var token in tokens)
            {
                deck2.Enqueue(new KeyValuePair<int, char>(int.Parse(token.Substring(0, token.Length - 1)), token[token.Length - 1]));
            }

            int turns = 0;
            while (deck1.Count > 0 && deck2.Count > 0)
            {
                turns++;
                played1.Add(deck1.Dequeue());
                played2.Add(deck2.Dequeue());

                if (played1[0].Key > played2[0].Key)
                {
                    deck1.Enqueue(played1[0]);
                    deck1.Enqueue(played2[0]);
                    played1.Clear();
                    played2.Clear();
                }
                else if (played1[0].Key < played2[0].Key)
                {
                    deck2.Enqueue(played2[0]);
                    deck2.Enqueue(played1[0]);
                    played1.Clear();
                    played2.Clear();
                }
                else
                {
                    int warCount = 0;
                    while (deck1.Count > 0 && deck2.Count > 0)
                    {
                        played1.Add(deck1.Dequeue());
                        played2.Add(deck2.Dequeue());
                        warCount++;
                        if (warCount % 3 == 0)
                        {
                            int p1 = 0;
                            int p2 = 0;
                            for (int i = played1.Count - 1; i > played1.Count - 4; i--)
                            {
                                p1 += played1[i].Value - 96;
                                p2 += played2[i].Value - 96;
                            }

                            if (p1 > p2)
                            {
                                played1.AddRange(played2);
                                played1 = played1.OrderByDescending(c => c.Key)
                                    .ThenByDescending(c => c.Value)
                                    .ToList();
                                foreach (var card in played1)
                                {
                                    deck1.Enqueue(card);
                                }
                                played1.Clear();
                                played2.Clear();
                                break;
                            }
                            if (p1 < p2)
                            {
                                played1.AddRange(played2);
                                played1 = played1.OrderByDescending(c => c.Key)
                                    .ThenByDescending(c => c.Value)
                                    .ToList();
                                foreach (var card in played1)
                                {
                                    deck2.Enqueue(card);
                                }
                                played1.Clear();
                                played2.Clear();
                                break;
                            }
                        }
                    }
                }

                if (turns == 1000000) break;
            }

            if (deck1.Count == 0 && deck2.Count == 0)
            {
                Console.WriteLine($"Draw after {turns} turns");
            }
            else if (deck1.Count > deck2.Count)
            {
                Console.WriteLine($"First player wins after {turns} turns");
            }
            else
            {
                Console.WriteLine($"Second player wins after {turns} turns");
            }
        }
    }
}