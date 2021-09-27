using System;
using System.Collections.Generic;

namespace LeetCode_146.LRUCache_CSharp
{
    public class LRUCache
    {

        class S
        {
            public LinkedListNode<int> n;
            public int v;

            public S(LinkedListNode<int> node, int value)
            {
                n = node;
                v = value;
            }
        }

        Dictionary<int, S> m;
        LinkedList<int> l = new LinkedList<int>();
        LinkedListNode<int> n;
        int c = 0;

        public LRUCache(int capacity)
        {
            c = capacity;
            m = new Dictionary<int, S>(capacity);
        }

        public int Get(int key)
        {
            if (!m.TryGetValue(key, out S s))
                return -1;

            if (n.Value != key)
            {
                l.Remove(s.n);
                n = l.AddLast(key);
                s.n = n;
            }

            return s.v;
        }

        public void Put(int key, int value)
        {

            if (m.TryGetValue(key, out S s))
            {
                if (n.Value != key)
                {
                    l.Remove(s.n);
                    s.n = l.AddLast(key);
                }

                s.v = value;
                return;
            }

            if (l.Count == c)
            {
                m.Remove(l.First.Value);
                l.RemoveFirst();
            }

            n = l.AddLast(key);
            m.Add(key, new S(n, value));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int capacity = 2;
            LRUCache lru = new LRUCache(capacity);
            Console.WriteLine($"LRUCache:[{capacity}]");

            int key = 1;
            int value = 1;
            lru.Put(key, value);
            Console.WriteLine($"put:[{key}, {value}]");

            key = 2;
            value = 2;
            lru.Put(key, value);
            Console.WriteLine($"put:[{key}, {value}]");

            key = 1;
            lru.Get(key);
            Console.WriteLine($"get:[{key}]");

            key = 3;
            value = 3;
            lru.Put(key, value);
            Console.WriteLine($"put:[{key}, {value}]");

            key = 2;
            lru.Get(key);
            Console.WriteLine($"get:[{key}]");

            key = 4;
            value = 4;
            lru.Put(key, value);
            Console.WriteLine($"put:[{key}, {value}]");

            key = 1;
            lru.Get(key);
            Console.WriteLine($"get:[{key}]");

            key = 3;
            lru.Get(key);
            Console.WriteLine($"get:[{key}]");

            key = 4;
            lru.Get(key);
            Console.WriteLine($"get:[{key}]");
        }
    }
}
