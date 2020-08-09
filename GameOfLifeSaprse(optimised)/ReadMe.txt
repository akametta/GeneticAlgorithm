Time complexity : O(Number of Live cell)
Space complexity : O(Number of live cell) + O(Number of Live cell*8)

When the matrix is large and sparse it is better to store the co-ordinates of live cell and update as usual rather than visiting each cell.
To implement this I have used a list to store the Live cell's co-ordinates and then used a dictionary to store the number of live neighbours of cells which
matter in our evaluation. It is important to notice that the dictionary may not contain live neighbours of all cells. I am constraing the calculation to only 
those cells where we have live cells.