using System;
using DaLinkedList;
using System.Collections.Generic;

namespace Slorf
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            DaLinkedList.LinkedList<string> linkedList = new DaLinkedList.LinkedList<string>();

            string hamster = Console.ReadLine();

            linkedList.Add(hamster);
            linkedList.Add("Blargh");
            linkedList.Add("Sleff");

            /*
            IEnumerator<string> slorf = linkedList.GetEnumerator();
            if (slorf.MoveNext())
            {
                string smet = slorf.Current;
                slorf.Reset();

                // null, since we reset. Must call MoveNext() again.
                smet = slorf.Current;
            }
            */

            foreach (string tomte in linkedList)
            {
                Console.WriteLine(tomte);
            }

            string kneg = linkedList.Find("Blargh");
            kneg = linkedList.Find(hamster);
            kneg = linkedList.Find("Sleff");
            
            bool res = linkedList.Remove("Blargh");
            res = linkedList.Remove(hamster);
            res = linkedList.Remove("Sleff");
        }
    }
}
