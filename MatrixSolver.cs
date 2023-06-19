/// Author: Fernando Sebastian Lopez Ochoa

class MatrixSolver {
    /// Element used to store the three values together in a queue
    public class queueElement {
        public int x;
        public int y;
        public int dist;

        public queueElement(int x, int y, int dist) {
            this.x = x;
            this.y = y;
            this.dist = dist;
        }
    }

    /// Auxiliary function to determine if the cell that we want to visit is 
    /// inside the boundaries
    static bool isValidCell(int x, int y, int n) {
        return (x >= 0) && (x < n) && (y >= 0) && y < n;
    }

    /// All 8 directions the maze can be traversed as
    static int []xMoves = {-1, 0, 1, -1, 1, -1, 0, 1};
    static int []yMoves = {-1, -1, -1, 0, 0, 1, 1, 1};

    /// Main function of the class. It uses a queue to perform breadth first search
    /// The process will ignore those cells whose value is not 0, if it reaches dead
    /// ends, the queue will be exhausted and will determine the corner is unreachable
    /// Explanation of this algorithm is attached in the pdf
    public static int Solve(int[,] matrixToSolve) {
        int n = matrixToSolve.GetLength(0);
        bool [,] visited = new bool[n, n];

        // Return -1 directly if the matrix is unsolvable
        if (matrixToSolve[0, 0] == 1 || matrixToSolve[n-1, n-1] == 1) {
            return -1;
        }

        // 0,0 is the origin, so we set it up based on that location
        visited[0, 0] = true;
        Queue<queueElement> q = new Queue<queueElement>();
        queueElement r = new queueElement(0, 0, 1);
        q.Enqueue(r);

        // BFS implementation, explained in the pdf
        while (q.Count != 0) {
            queueElement current = q.Peek();
            int x = current.x;
            int y = current.y;

            if (x == n - 1 && y == n - 1) {
                return current.dist;
            }

            q.Dequeue();

            for (int i = 0; i < 8; i++) {
                int newX = x + xMoves[i];
                int newY = y + yMoves[i];
                if (isValidCell(newX, newY, n) && matrixToSolve[newX, newY] == 0 && !visited[newX, newY]) {
                    visited[newX, newY] = true;
                    queueElement AdjacentCell = new queueElement(newX, newY, current.dist + 1);
                    q.Enqueue(AdjacentCell);
                }
            }
        }
        return -1;
    }
}