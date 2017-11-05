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

        private bool[,] Squares;
        Random rand;

        public Cave(int width, int height, int squareSize, int birthChance, int birthLimit, int deathLimit)
        {
            Width = width;
            Height = height;
            squareSize = SquareSize;
            Squares = new bool[width, height];
            BirthChance = birthChance;
            BirthLimit = birthLimit;
            DeathLimit = deathLimit;
            rand = new Random();
        }

        public Boolean[,] GenerateMap()
        {
            InitializeMap();
            for (int i = 0; i < 2; i++)
            { 
                DoSimulationStep();
            }
            return Squares;            
        }

        private void InitializeMap()
        {
            for (int i = 0; i < Squares.GetLength(0); i++)
            {
                for (int j = 0; j < Squares.GetLength(1); j++)
                {
                    var roll = rand.Next(0, 100) < BirthChance;
                    Squares[i, j] = roll;
                }    
            }
        }

        private void DoSimulationStep()
        {
            bool[,] newMap = new bool[Width, Height];
            for (int x = 0; x < Squares.GetLength(0); x++)
            {
                for (int y = 0; y < Squares.GetLength(1); y++)
                {
                    int nbs = AliveNeighbours(x, y);
                    if (Squares[x, y])
                    {
                        if (nbs < DeathLimit)
                        {
                            newMap[x, y] = false;
                        }
                        else
                        {
                            newMap[x, y] = true;
                        }
                    }
                    else
                    {
                        if (nbs > BirthLimit)
                        {
                            newMap[x, y] = true;
                        }
                        else
                        {
                            newMap[x, y] = false;
                        }
                    }
                }
            }
            Squares = newMap;
        }

        private int AliveNeighbours(int x, int y)
        {
            int count = 0;
            int xLength = Squares.GetLength(0);
            int yLength = Squares.GetLength(1);
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int neighborX = x + i;
                    int neighborY = y + j;

                    if (i == 0 && j == 0)
                    {
                        continue;
                    }
                    else if (neighborX < 0 || neighborY < 0 || neighborX >= xLength || neighborY >= yLength)
                    {
                        continue;
                    }
                    else if (Squares[neighborX, neighborY])
                    {
                        count++;
                    }   
                }
            }
            return count;
        }
    }
}
