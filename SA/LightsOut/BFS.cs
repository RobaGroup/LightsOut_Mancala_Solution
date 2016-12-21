﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.LightsOut
{
    class BFS
    {
        public Node.State[,] Initial { set; get; }

        public IList<Node> Solve()
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(new Node() { Board = Initial });
            ISet<Node> visited = new HashSet<Node>();
            while (q.Count != 0)
            {
                var n = q.Dequeue();
                if (n.IsFinal)
                {
                    return n.Parents;
                }
                visited.Add(n);
                n.GenerateChildren().Where(s => !visited.Contains(s)).ToList().ForEach(e => q.Enqueue(e));
            }
            return new List<Node>();
        }
    }
}