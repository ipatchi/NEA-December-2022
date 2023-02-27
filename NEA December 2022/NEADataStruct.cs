using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_December_2022
{
    internal class NEAQueue
    {
        public List<int> l = new List<int>();
        public NEAQueue()
        {
            
            
        }
        public int Dequeue()
        {
            int a = l[0];
            for (int i = 0; i < l.Count; i++)
            {
                l[i] = l[i + 1];
            }
            l.RemoveAt(l.Count);
            return a;
        }
        public void Enqueue(int d)
        {
            l.Add(d);
        }

        public int[] GetQueue()
        {
            return l.ToArray();
        }
    }
}
