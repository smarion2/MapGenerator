using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGenerator
{
    public class Cave : IMap
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int SquareSize { get; private set; }

        private int BirthChance;
        private int BirthLimit;
        private int DeathLimit;

        private int[,] Squares;

        public Cave(int width, int height, int squareSize, int birthChance, int birthLimit, int deathLimit)
        {
            Width = width;
            Height = height;
            squareSize = SquareSize;
            Squares = new int[width, height];
            BirthChance = birthChance;
            BirthLimit = birthLimit;
            DeathLimit = deathLimit;
        }

        public void GenerateMap()
        {

        }
    }
}
