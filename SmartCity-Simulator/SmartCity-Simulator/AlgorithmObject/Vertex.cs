/*
 * Author: Jeppe Andersen
 * Website: nocture.dk
 * 
 * Feel free to use this in any way you want :-)
 * 
 */
using System;
using System.Drawing;

namespace Dijkstra
{
    public class Vertex
    {
        public int p { get; private set; }
        public int dist { get; set; }

        public Vertex(int p)
        {
            this.p = p;
        }
    }
}
