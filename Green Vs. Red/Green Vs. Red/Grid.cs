using System;

namespace Green_Vs.Red
{
    public class Grid
    {
        private int[,] grid;
        private int generationCounter = 0;
        private int rowCount;
        private int colCount;
        private int cellCoordX;
        private int cellCoordY;
        private int gridLimitMin = 1; //taken from the task rules
        private int gridLimitMax = 1000; //taken from the task rules

        public Grid()
        {
            Console.WriteLine("Please, enter dimentions of the grid.");
            Console.Write("Rows: ");
            rowCount = GetInput(gridLimitMin, gridLimitMax);
            Console.Write("Columns: ");
            colCount = GetInput(gridLimitMin, gridLimitMax);

            // initialize grid
            grid = new int[rowCount, colCount];

            // fill the grid with random 0 and 1s
            InitializeGrid();

            // print the filled grid
            Print(generationCounter);

            // Get the coordinates for the cell, that is chosen by the user 
            Console.WriteLine("Please, enter coordinates for the watched cell.");
            Console.Write("Enter X: ");
            cellCoordX = GetInput(0, rowCount);
            Console.Write("Enter Y: ");
            cellCoordY = GetInput(0, colCount);

            //Get the generations input
            Console.Write("\nFor how many generations this cell will be watched? \nPlease, enter value:");
            int generations = GetInput(gridLimitMin, gridLimitMax);

            CalcNextGeneration(generations);
        }
        // Validating the user's input
        public int GetInput(int limitMin, int limitMax)
        {
            int input = 0;
            bool result = false;

            while (!result)
            {
                int tempInput;

                if (int.TryParse(Console.ReadLine(), out tempInput) && tempInput > limitMin - 1 && tempInput < limitMax)
                {
                    input = tempInput;
                    result = true;
                }
                else
                    Console.Write("Please, enter a value between {0} and {1}: ", limitMin, limitMax - 1);
            }

            return input;
        }

        // Fill the grid with randomly generated 0 and 1
        public int[,] InitializeGrid()
        {
            var rand = new Random();

            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    int colorValue = rand.Next((int)CellColor.Red, (int)CellColor.Green + 1);
                    grid[x, y] = colorValue;
                }
            }
            return grid;
        }

        // Print the grid for specified generation
        public void Print(int generationCounter)
        {
            Console.WriteLine("\nGrid on Generation: {0}", generationCounter);

            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    Console.Write(grid[x, y] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }

        //Calculates the new grid
        private void CalcNextGeneration(int generations)
        {
            // temporary grid that will hold the values calculated in the current generation
            int[,] nextGenGrid = new int[rowCount, colCount];


            int chosenCellGreenCount = 0; // holds the green counts of the "watched" cell
            int tempGenerations = generations; // holds the generations count in the loop


            while (tempGenerations != 0)
            {
           
                tempGenerations--;


                for (int x = 0; x < rowCount; x++)
                {
                    for (int y = 0; y < colCount ; y++)
                    {
                        var cell = new Cell();
                        int currentCellValue = grid[x, y];               

                        // get the green neighbords of the current cell
                        int greenNeighbors = cell.CountGreenNeighbors(grid, x, y);

                        // assign the new value to the cell in the nextGenGrid
                        nextGenGrid[x, y] = cell.CalcNextGenCell(currentCellValue, greenNeighbors);

                        // check if the current cell is 1 and id it's coordinates are equal to the ones of the "watched" cell
                        if (currentCellValue == 1 && x == cellCoordX && y == cellCoordY)
                            chosenCellGreenCount++; // if yes, add one to green counts of the the "watched" cell
                    }
                }

                // assign nextGenGrid values to grid
                for (int x = 0; x < rowCount; x++)
                {
                    for (int y = 0; y < colCount; y++)
                    {
                        grid[x, y] = nextGenGrid[x, y];
                    }
                }

                // Increase value for the generation counter, that informs in Print()
                generationCounter++;

                // Print the already assigned next generation grid
                Print(generationCounter);
            }

            Console.WriteLine("For {0} generations the cell with coordinates [{1},{2}] was green {3} times.", generations, cellCoordX, cellCoordY, chosenCellGreenCount);
        } 

    }
}
