using System;

class MalkoKote
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        char character = char.Parse(Console.ReadLine());
        int counter = 1;

        for (int i = 10; i < size; i += 4)
        {
            counter++;
        }

        // ushaci
        Console.Write(' ');
        Console.Write(new string(character, 1));
        Console.Write(new string(' ', counter));
        Console.Write(new string(character, 1));
        Console.Write(' ');
        Console.WriteLine();

        // glava 
        for (int i = 0; i < counter; i++)
        {
            Console.Write(' ');
            Console.Write(new string(character, counter + 2));
            Console.Write(' ');
            Console.WriteLine();
        }

        // vrat
        for (int i = 0; i < counter; i++)
        {
            Console.Write(' ');
            Console.Write(' ');
            Console.Write(new string(character, counter));
            Console.Write(' ');
            Console.Write(' ');
            Console.WriteLine();
        }

        // body 1
        for (int i = 0; i < counter; i++)
        {
            Console.Write(' ');
            Console.Write(new string(character, counter + 2));
            Console.Write(' ');
            Console.WriteLine();
        }

        // body 2 with tail
        Console.Write(' ');
        Console.Write(new string(character, counter + 2));
        Console.Write(' ');
        Console.Write(' ');
        Console.Write(' ');
        Console.Write(new string(character, counter + 1));

        
        Console.WriteLine();

        // body 3
        for (int i = 0; i < counter + 2; i++)
        {
            Console.Write(new string(character, counter + 4));
            Console.Write(' ');
            Console.Write(' ');
            Console.Write(new string(character, 1));

            Console.WriteLine();

        }
        Console.Write(new string(character, counter + 4));
        Console.Write(' ');
        Console.Write(new string(character, 2));
        Console.WriteLine();

        // bottom
        Console.Write(' ');
        Console.Write(new string(character, counter + 5));
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Press Enter to EXIT...");
        Console.ReadLine();

    }
}

