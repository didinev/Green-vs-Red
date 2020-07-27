using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Green_Vs.Red
{
    class Cell
    {
        // Count the green neighbors around a cell
        public int CountGreenNeighbors(int[,] grid, int coordX, int coordY)
        {
            int count = 0;
            int rowLength = grid.GetLength(0) - 1;
            int colLength = grid.GetLength(1) - 1;

            for (int x = Math.Max(0, coordX - 1); x <= Math.Min(coordX + 1, rowLength); x++)
            {
                for (int y = Math.Max(0, coordY - 1); y <= Math.Min(coordY + 1, colLength); y++)
                {
                    // if the coordinates of the current cell are not the same as the ones of the "watched" cell                   
                    if (x != coordX || y != coordY)
                    {
                        if (grid[x, y] == 1)
                            count++;
                    }
                }
            }
            return count;
        }

        // Calculate the cell value for the next generation
        public int CalcNextGenCell(int currentCellValue, int greenNeighbors)
        {
            int cellValue;

            // Apply the rules, described in the task
            if (currentCellValue == 0 && (greenNeighbors == 3 || greenNeighbors == 6))
                cellValue = 1;
            else if (currentCellValue == 1 && !(greenNeighbors == 2 || greenNeighbors == 3 || greenNeighbors == 6))
                cellValue = 0;
            else
                cellValue = currentCellValue;

            return cellValue;
        }
    }
}
