using System;
using System.Collections.Generic;

namespace Dijkstra
{
    public class Dijkstra
    {
        public float[] dist { get; private set; }
        public int[] path { get; private set; }
        private List<int> queue = new List<int>();

        private void Initialize(int s, int len)
        {
            dist = new float[len];
            path = new int[len];

            for (int i = 0; i < len; i++)
            {
                dist[i] = float.PositiveInfinity;

                queue.Add(i);
            }
            dist[s] = 0;
            path[s] = -1;
        }

        private int GetNextVertex()
        {
            double min = Double.PositiveInfinity;
            int Vertex = -1;

            foreach (int j in queue)
            {
                if (dist[j] <= min)
                {
                    min = dist[j];
                    Vertex = j;
                }
            }

            queue.Remove(Vertex);

            return Vertex;

        }

        /* Takes a graph as input an adjacency matrix (see top for details) and a starting node */
        public Dijkstra(float[,] G, int s)
        {
            /* Check graph format and that the graph actually contains something */
            if (G.GetLength(0) < 1 || G.GetLength(0) != G.GetLength(1))
            {
                throw new ArgumentException("Graph error, wrong format or no nodes to compute");
            }

            int len = G.GetLength(0);

            Initialize(s, len);

            while (queue.Count > 0)
            {
                int u = GetNextVertex();

                /* Find the nodes that u connects to and perform relax */
                for (int v = 0; v < len; v++)
                {
                    /* Checks for edges with negative weight */
                    if (G[u, v] < 0)
                    {
                        throw new ArgumentException("Graph contains negative edge(s)");
                    }

                    /* Check for an edge between u and v */
                    if (G[u, v] > 0)
                    {
                        /* Edge exists, relax the edge */
                        if (dist[v] > dist[u] + G[u, v])
                        {
                            dist[v] = dist[u] + G[u, v];
                            path[v] = u;
                        }
                    }
                }
            }
        }
    }
}
