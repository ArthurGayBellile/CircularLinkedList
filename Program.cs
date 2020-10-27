

namespace CircularLinkedList
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    

    public class GenericCollection
    {
        static void Listemusique(LinkedListNode<Musique> current)
        {
            int number = 1;
            while (current != null)
            {
                Console.Clear();
                string numberString = $"- {number} -";
                int leadingSpaces = (90 - numberString.Length) / 2;
                Console.WriteLine(numberString.PadLeft(leadingSpaces + numberString.Length));
                Console.WriteLine();

                string content = current.Value.Content;
                for (int i = 0; i < content.Length; i += 90)
                {
                    string line = content.Substring(i);
                    line = line.Length > 90 ? line.Substring(0, 90) : line;
                    Console.WriteLine(line);
                }

                Console.WriteLine();
                //Console.WriteLine($"Quote from \"Windows Application Development Cookbook\" by Marcin Jamro,{Environment.NewLine}published by Packt Publishing in 2016.");

                Console.WriteLine();
                Console.Write("< PREVIOUS [P]");
                Console.Write( "[N] NEXT >".PadLeft(76));
                Console.WriteLine();

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.N:
                        if (current.Next != null)
                        {
                            current = current.Next;
                            number++;
                        }
                        else
                        {
                            current = current.List.First;
                            number = 1;
                        }
                        break;
                    case ConsoleKey.P:
                        if (current.Previous != null)
                        {
                            current = current.Previous;
                            number--;
                        }
                        else
                        {
                            current = current.List.Last;
                            number = 4;
                        }
                        break;
                    default:
                        return;
                }
            }


            static string GetSpaces(int number)
            {
                string result = string.Empty;
                for (int i = 0; i < number; i++)
                {
                    result += " ";
                }
                return result;
            }
        }
    
        public static void Main()
        {

            


            Queue<string> Callcenterqueue = new Queue<string>();
            Callcenterqueue.Enqueue("#1234");
            Callcenterqueue.Enqueue("#1456");
            Callcenterqueue.Enqueue("#5489");
            Callcenterqueue.Enqueue("#9876");
            
            foreach (string a in Callcenterqueue)
            {
                Console.WriteLine(a);
            }
            while (Callcenterqueue.Count > 0)
            {
                Console.WriteLine("Voulez-vous prendre cet appel ? : " + Callcenterqueue.Peek() + "\nOui \nNon");
                string b = Console.ReadLine();
                if (b == "oui")
                {
                    Thread.Sleep(3000);
                    Callcenterqueue.Dequeue();
                }
                else Callcenterqueue.Dequeue();
                Console.WriteLine("Il vous reste tous ces appels en attente :\n");
                foreach (string a in Callcenterqueue)
                {
                    Console.WriteLine(a);
                }
                Console.WriteLine();
            }
            

            Console.ReadKey();
            /*
            CircularLinkedList<Musique> listemusique = new CircularLinkedList<Musique>();

            Musique une = new Musique() { Content = "Coldplay" };
            Musique deux = new Musique() { Content = "Kaaris" };
            Musique trois = new Musique() { Content = "Bosh" };
            Musique quatre = new Musique() { Content = "U2" };
            listemusique.AddLast(une);
            LinkedListNode<Musique> noeud4 = listemusique.AddLast(trois);

            listemusique.AddBefore(noeud4, deux);
            listemusique.AddAfter(noeud4, quatre);

            LinkedListNode<Musique> current = listemusique.First;
            
            Listemusique(current);*/
            
        }
        
    }

}
