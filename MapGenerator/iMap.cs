using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGenerator
{
    interface IMap
    {
        int Width { get; }
        int Height { get; }
        int SquareSize { get; }

        void GenerateMap();
        
    }
}
