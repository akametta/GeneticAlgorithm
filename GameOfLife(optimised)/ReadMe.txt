Time Complexity : O(gridLength*gridWidth)
Space Complexity : O(1)
Assumption : matrix is not sparse
Here i have used dummy values to reflect the transitions from dead to live and vice-versa

Dead(0)-->Live(1) : Reproductiion represented by 2.
Note: This change wouldn't hamper our evaluation because I am checking the absolute value of grid to be 1. This means that the value of the given cell was 0
	initially.
Live(1)-->Dead(0) : Underpopulation or Overpopulation represented by -1. Negative sign implying that the cell is dead now but the magnitude implies that the
	cell was Live initially.
Note: Again this change wouldn't hamper our evaluation because I am using absolute value of a cell and hence it will be reflected as a live cell while in 
	calculation.

How to convert it back to 0-1 grid?
if the values of the grid is greater than 0 it is Live(1) else Dead(0) 
