# Green-vs-Red
Green vs. Red Game

This is a game played on a 2D grid that in theory can be infinite. Think of it as a modified verion of Game of Life.

Each cell on this grid can be either green (represented by 1) or red (represented by 0). The game always receives an initial state of the grid which is called "Generation Zero". After that a set of 4 rules are applied across the grid and those rules form the next generation.

Rules:
1. Each red cell that is surrounded by exactly 3 or exactly 6 green cells will also become green in the next generation.
2. A red cell will stay red in the next generation if has either 0, 1, 2, 4, 5, 7 or 8 green neighbours.
3. Each green cell surrounded by 0, 1, 4, 5, 7 or 8 green neighbours will become red in the next generation.
4. A green cell will stay green in the next generation if has either 2, 3 or 6 green neighbours.

Important notes:
  - Each cell can be surrounded by up to 8 cells. 4 on the sides and 4 on the corners. Exceptions are the corners and the sides of the grid.
  - All the 4 rules apply at the same time for the whole grid in order for the next generation to be formed.

The program accepts the size of the grid, the number of generations and the coordinates of a specific cell. The result should be how many times this cell was green during those n generations.
