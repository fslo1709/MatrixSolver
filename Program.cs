/// Author: Fernando Sebastian Lopez Ochoa
using System;

/// Main class to run the program, located in the file 

class Program {
    static public void Main() {
        int[,] customInput = {{0, 0, 0},{1, 1, 0}, {1, 1, 0}};
        int customOutput = MatrixSolver.Solve(customInput);
        Console.WriteLine(customOutput.ToString());
    }
}