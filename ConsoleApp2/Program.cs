using System; using System.Globalization;
namespace GameOfLife
{
    public class LifeSimulation
    {
        private int Heigth;
        private int Width; 
        private bool[,] cells;
        private bool[,] next;
        private string choice;
        public LifeSimulation(int Heigth, int Width , string choice)
        {
            this.Heigth = Heigth;
            this.Width = Width;
            cells = new bool[Heigth, Width];
            next = new bool[Heigth, Width]; 
            this.choice = choice;
            GenerateField(choice);
        }    
        public void DrawAndGrow()
        {  
            DrawGame();
            Grow();
        }
        private void Grow()
        {
            int numOfAliveNeighbors = 0;
            for (int k=0;k<Heigth;k++)
            {
                for (int l = 0; l < Width; l++)
                {
                    next[k, l] = cells[k, l];
                }
            }
            for (int i = 0; i < Heigth; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (i == 0 || j == 0 || i == Heigth - 1 || j == Width - 1)
                    {
                        if (i == 0 && j == 0)
                        {
                            if (next[i,j+1] == true) { numOfAliveNeighbors++; }
                            if (next[i+1,j] == true) { numOfAliveNeighbors++; }
                            if (next[i + 1, j + 1] == true) { numOfAliveNeighbors++; }
                            if (next[Heigth - 1, j] == true) { numOfAliveNeighbors++; }
                            if (next[i, Width - 1] == true) { numOfAliveNeighbors++; }
                            if (next[Heigth - 1, j + 1] == true) { numOfAliveNeighbors++; }
                            if (next[i+1,Width-1] == true) { numOfAliveNeighbors++;}
                            if (next[Heigth-1,Width-1] == true) { numOfAliveNeighbors++; }
                        }
                        if (i == 0 && j == Width - 1)
                        {
                            if (next[i , Width-2] == true) { numOfAliveNeighbors++; }
                            if (next[i+1, Width-2] == true) { numOfAliveNeighbors++; }
                            if (next[i+1, Width-1] == true) { numOfAliveNeighbors++; }
                            if (next[0,0] == true) { numOfAliveNeighbors++; }
                            if (next[i+1,0] == true) { numOfAliveNeighbors++; }
                            if (next[Heigth - 1,Width-1 ] == true) { numOfAliveNeighbors++; }
                            if (next[Heigth - 1, Width - 2] == true) { numOfAliveNeighbors++;}
                            if (next[Heigth - 1, 0] == true) { numOfAliveNeighbors++; }
                        }
                        if (i == Heigth-1 && j == 0)
                        {
                            if (next[i-1, j] == true) { numOfAliveNeighbors++; }
                            if (next[i-1, j+1] == true) { numOfAliveNeighbors++; }
                            if (next[i,j+1] == true) { numOfAliveNeighbors++; }
                            if (next[0, 0] == true) { numOfAliveNeighbors++; }
                            if (next[0,j+1] == true) { numOfAliveNeighbors++; }
                            if (next[i,Width-1] == true) { numOfAliveNeighbors++; }
                            if (next[i-1,Width-1] == true) { numOfAliveNeighbors++; }
                            if (next[0, Width-1] == true) { numOfAliveNeighbors++; }
                        }
                        if (i == Heigth - 1 && j == Width-1)
                        {
                            if (next[Heigth-1,Width-2] == true) { numOfAliveNeighbors++; }
                            if (next[Heigth-2,Width-1] == true) { numOfAliveNeighbors++; }
                            if (next[Heigth-2,Width-2] == true) { numOfAliveNeighbors++; }
                            if (next[0, 0] == true) { numOfAliveNeighbors++; }
                            if (next[Heigth-1,0] == true) { numOfAliveNeighbors++; }
                            if (next[Heigth-2,0] == true) { numOfAliveNeighbors++; }
                            if (next[0,Width-2] == true) { numOfAliveNeighbors++; }
                            if (next[0, Width - 1] == true) { numOfAliveNeighbors++; }
                        }
                        if (i==0 && j< Width-1 && j>0)
                        {
                            if (next[0,j-1] == true) { numOfAliveNeighbors++; }
                            if (next[0,j+1] == true) { numOfAliveNeighbors++; }
                            if (next[i+1,j-1] == true) { numOfAliveNeighbors++; }
                            if (next[i+1,j] == true) { numOfAliveNeighbors++; }
                            if (next[i+1,j+1] == true) { numOfAliveNeighbors++; }
                            if (next[Heigth-1,j-1] == true) { numOfAliveNeighbors++; }
                            if (next[Heigth-1,j] == true) { numOfAliveNeighbors++; }
                            if (next[Heigth-1,j+1] == true) { numOfAliveNeighbors++; }
                        }
                        if (i == Heigth-1 && j < Width - 1 && j > 0)
                        {
                            if (next[Heigth-1,j-1] == true) { numOfAliveNeighbors++; }
                            if (next[Heigth-1,j+1] == true) { numOfAliveNeighbors++; }
                            if (next[Heigth-2,j-1] == true) { numOfAliveNeighbors++; }
                            if (next[Heigth-2,j] == true) { numOfAliveNeighbors++; }
                            if (next[Heigth-2,j+1] == true) { numOfAliveNeighbors++; }
                            if (next[0,j-1] == true) { numOfAliveNeighbors++; }
                            if (next[0,j] == true) { numOfAliveNeighbors++; }
                            if (next[0, j + 1] == true) { numOfAliveNeighbors++; }
                        }
                        if (i >0 && i<Heigth-1 && j==0)
                        {
                            if (next[i-1,j] == true) { numOfAliveNeighbors++; }
                            if (next[i+1,j] == true) { numOfAliveNeighbors++; }
                            if (next[i-1,j+1] == true) { numOfAliveNeighbors++; }
                            if (next[i,j+1] == true) { numOfAliveNeighbors++; }
                            if (next[i+1,j+1] == true) { numOfAliveNeighbors++; }
                            if (next[i,Width-1] == true) { numOfAliveNeighbors++; }
                            if (next[i-1,Width-1 ] == true) { numOfAliveNeighbors++; }
                            if (next[i+1,Width-1 ] == true) { numOfAliveNeighbors++; }
                        }
                        if (i > 0 && i < Heigth - 1 && j == Width-1)
                        {
                            if (next[i-1,j] == true) { numOfAliveNeighbors++; }
                            if (next[i + 1, j] == true) { numOfAliveNeighbors++; }
                            if (next[i-1,j-1] == true) { numOfAliveNeighbors++; }
                            if (next[i,j-1] == true) { numOfAliveNeighbors++; }
                            if (next[i+1,j-1] == true) { numOfAliveNeighbors++; }
                            if (next[i-1,0] == true) { numOfAliveNeighbors++; }
                            if (next[i,0] == true) { numOfAliveNeighbors++; }
                            if (next[i+1,0] == true) { numOfAliveNeighbors++; }
                        }
                    }
                    else
                    {
                         numOfAliveNeighbors = GetNeighbors(i, j);
                    }                
                    if (next[i, j]==true)
                    {
                        if (numOfAliveNeighbors < 2 || numOfAliveNeighbors > 3)
                        {
                            cells[i, j] = false;
                        }
                    }
                    if (next[i,j]== false && numOfAliveNeighbors==3)
                    {
                        cells[i, j] = true;
                    }
                    numOfAliveNeighbors = 0;
                }
            }
        }
        private int GetNeighbors(int x, int y)
        {   
            int NumOfAliveNeighbors = 0;
            if (next[x - 1, y - 1] == true) NumOfAliveNeighbors++;
            if (next[x - 1, y ] == true) NumOfAliveNeighbors++;
            if (next[x - 1, y +1] == true) NumOfAliveNeighbors++;
            if (next[x , y - 1] == true) NumOfAliveNeighbors++;
            if (next[x , y + 1] == true) NumOfAliveNeighbors++;
            if (next[x + 1, y - 1] == true) NumOfAliveNeighbors++;
            if (next[x + 1, y ] == true) NumOfAliveNeighbors++;
            if (next[x + 1, y + 1] == true) NumOfAliveNeighbors++;
            return NumOfAliveNeighbors;
        }
        private void DrawGame()
        {
            for (int i = 0; i < Heigth; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write(cells[i, j] ? "O" : ".");
                    if (j == Width - 1) Console.WriteLine("\r");
                }
                if (i == Heigth - 1) Console.WriteLine("\r");
            }
            Console.SetCursorPosition(0, Console.WindowTop); //to make it simulation 'cursortop' should be 'windowstop'
        }
        private void GenerateField(string choice)
        {
            if (choice == "r")
            {
                Random generator = new Random();
                int number;
                for (int i = 0; i < Heigth; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        number = generator.Next(2);
                        cells[i, j] = ((number == 0) ? false : true);
                    }
                }
            }
            else
            {
                cells[0, 0] = false; cells[0, 1] = false; cells[0, 2] = false; cells[0, 3] = false; cells[0, 4] = false; cells[0, 5] = false; cells[0, 6] = false; cells[0, 7] = false; cells[0, 8] = false; cells[0, 9] = false;
                cells[1, 0] = false; cells[1, 1] = false; cells[1, 2] = false; cells[1, 3] = false; cells[1, 4] = false; cells[1, 5] = false; cells[1, 6] = false; cells[1, 7] = false; cells[1, 8] = false; cells[1, 9] = false;
                cells[2, 0] = false; cells[2, 1] = false; cells[2, 2] = false; cells[2, 3] = false; cells[2, 4] = false; cells[2, 5] = false; cells[2, 6] = false; cells[2, 7] = false; cells[2, 8] = false; cells[2, 9] = false;
                cells[3, 0] = false; cells[3, 1] = false; cells[3, 2] = false; cells[3, 3] = false; cells[3, 4] = true; cells[3, 5] = false; cells[3, 6] = false; cells[3, 7] = false; cells[3, 8] = false; cells[3, 9] = false;
                cells[4, 0] = false; cells[4, 1] = false; cells[4, 2] = false; cells[4, 3] = false; cells[4, 4] = false; cells[4, 5] = true; cells[4, 6] = false; cells[4, 7] = false; cells[4, 8] = false; cells[4, 9] = false;
                cells[5, 0] = false; cells[5, 1] = false; cells[5, 2] = false; cells[5, 3] = true;  cells[5, 4] = true; cells[5, 5] = true;   cells[5, 6] = false; cells[5, 7] = false; cells[5, 8] = false; cells[5, 9] = false;
                cells[6, 0] = false; cells[6, 1] = false; cells[6, 2] = false; cells[6, 3] = false; cells[6, 4] = false; cells[6, 5] = false; cells[6, 6] = false; cells[6, 7] = false; cells[6, 8] = false; cells[6, 9] = false;
                cells[7, 0] = false; cells[7, 1] = false; cells[7, 2] = false; cells[7, 3] = false; cells[7, 4] = false; cells[7, 5] = false; cells[7, 6] = false; cells[7, 7] = false; cells[7, 8] = false; cells[7, 9] = false;
                cells[8, 0] = false; cells[8, 1] = false; cells[8, 2] = false; cells[8, 3] = false; cells[8, 4] = false; cells[8, 5] = false; cells[8, 6] = false; cells[8, 7] = false; cells[8, 8] = false; cells[8, 9] = false;
                cells[9, 0] = false; cells[9, 1] = false; cells[9, 2] = false; cells[9, 3] = false; cells[9, 4] = false; cells[9, 5] = false; cells[9, 6] = false; cells[9, 7] = false; cells[9, 8] = false; cells[9, 9] = false;

            }
        }
    }
    internal class Program
    { 
        private const uint MaxRuns = 100; //to increase turn number , this should be increased
        private static void Main(string[] args)
        {
            int Heigth = 5;
            int Width = 5;
            string Choice = Console.ReadLine();
            if (Choice == "m")
            {
                Heigth = 10;
                Width = 10;
            }
            int runs =0;
            LifeSimulation sim = new LifeSimulation(Heigth, Width, Choice);

            while (runs++ < MaxRuns)
            {
                sim.DrawAndGrow();
                System.Threading.Thread.Sleep(400); // to increase speed number should be decreased
            }
        }
    }
}