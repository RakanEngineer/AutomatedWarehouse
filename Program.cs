using System.Threading;
using static System.Console;

namespace AutomatedWarehouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //bool[,] Shelf = new bool[0, 0];
            string[,] Shelf = new string[0, 0];

            bool shouldNotExit = true;

            string name = "";
            int slotsCounter = 0;
            string content = "";

            Package package = new Package(name, content);
            Shelf shelf = new Shelf(name);

            while (shouldNotExit)
            {
                Clear();
                WriteLine("");
                WriteLine(" 1. Create shelf");
                WriteLine(" 2. Print shelf");
                WriteLine(" 3. Place package");
                WriteLine(" 4. Fetch package");
                WriteLine(" 5. Exit");
                ConsoleKeyInfo keyPressed = ReadKey(true);
                Clear();
                switch (keyPressed.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        WriteLine("");
                        SetCursorPosition(1, 2);
                        Write("Name: ");
                        SetCursorPosition(1, 4);
                        Write("Rows: ");
                        SetCursorPosition(1, 6);
                        Write("Columns: ");
                        SetCursorPosition("Name: ".Length + 2, 2);
                        shelf.nameShelf = ReadLine();
                        SetCursorPosition("Rows: ".Length + 2, 4);
                        ushort rows = ushort.Parse(ReadLine());
                        SetCursorPosition("Columns: ".Length + 2, 6);
                        ushort columns = ushort.Parse(ReadLine());
                        Shelf = new string[rows, columns];
                        for (int i = 0; i < Shelf.GetLength(0); i++)
                        {
                            for (int j = 0; j < Shelf.GetLength(1); j++)
                            {
                                Shelf[i, j] = null;
                            }
                        }
                        //Shelf[1, 0] = true;
                        //Shelf[1, 2] = true;
                        //Shelf[2, 1] = true;
                        //Shelf[2, 2] = true;
                        //Shelf[2, 3] = true;
                        //Shelf[4, 2] = true;
                        //Shelf[4, 3] = true;

                        Clear();
                        WriteLine("Shelf successfully created");
                        Thread.Sleep(2000);
                        break;

                    case ConsoleKey.D2:
                        WriteLine("");
                        slotsCounter = 0;
                        for (int i = 0; i < Shelf.GetLength(0); i++)
                        {
                            for (int j = 0; j < Shelf.GetLength(1); j++)
                            {
                                if (Shelf[i, j]==null)
                                {
                                    Write("|   ");
                                    ++slotsCounter;
                                }
                                else
                                {
                                    Write("| X ");
                                }

                            }
                            Write("|");
                            WriteLine("");
                        }
                        WriteLine("");
                        WriteLine("Name: " + shelf.nameShelf);
                        WriteLine("");
                        WriteLine("Available slots: " + slotsCounter);
                        WriteLine("<Press Esc to continue>");
                        bool stang = true;
                        while (stang)
                        {
                            ConsoleKeyInfo choose = ReadKey(true);
                            switch (choose.Key)
                            {
                                case ConsoleKey.Escape:
                                    stang = false;
                                    break;
                            }
                        }
                        break;
                    case ConsoleKey.D3:
                        WriteLine("");
                        SetCursorPosition(1, 2);
                        Write("Content: ");
                        SetCursorPosition(1, 4);
                        Write("Rows: ");
                        SetCursorPosition(1, 6);
                        Write("Columns: ");
                        SetCursorPosition("Content: ".Length + 2, 2);
                        content = ReadLine();
                        SetCursorPosition("Rows: ".Length + 2, 4);
                        ushort rowPlace = ushort.Parse(ReadLine());
                        SetCursorPosition("Columns: ".Length + 2, 6);
                        ushort columnPlace = ushort.Parse(ReadLine());
                        Clear();
                        if (Shelf[rowPlace, columnPlace] == null)
                        {
                            WriteLine("Success");
                            Shelf[rowPlace, columnPlace] = package.content;
                        }
                        else
                        {
                            WriteLine("Slot occupied");
                        }
                        Thread.Sleep(2000);
                        break;
                    case ConsoleKey.D4:
                        SetCursorPosition(1, 2);
                        Write("Row: ");
                        SetCursorPosition(1, 4);
                        Write("Column: ");
                        SetCursorPosition("Row: ".Length + 2, 2);
                        ushort row = ushort.Parse(ReadLine());
                        SetCursorPosition("Column: ".Length + 2, 4);
                        ushort column = ushort.Parse(ReadLine());
                        Clear();
                        if (Shelf[row, column] == null)
                        {
                            WriteLine("Slot occupied (empty)");
                        }
                        else
                        {
                            WriteLine("Package successfully retrieved");
                            WriteLine("");
                            WriteLine("Countent:" + Shelf[row, column]);
                            WriteLine("");
                            WriteLine("<Press any key to continue>");
                            ReadKey();
                            Shelf[row, column] = null;
                        }
                        Thread.Sleep(2000);
                        break;
                    case ConsoleKey.D5:
                        shouldNotExit = false;
                        break;

                }
            }
        }
        class Package
        {
            public string name;
            public string content;
            public Package(string name, string content)
            {
                this.name = name;
                this.content = content;
            }
        }
        class Shelf
        {
            public string nameShelf;
            public Shelf(string Name)
            {
                this.nameShelf = Name;
            }
        }
    }
}
    