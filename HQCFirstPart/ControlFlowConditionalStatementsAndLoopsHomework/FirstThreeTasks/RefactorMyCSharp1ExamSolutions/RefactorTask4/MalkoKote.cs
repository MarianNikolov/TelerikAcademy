using System;

class MalkoKote
{
    // 100 points in BgCoder during exam

    static void Main()
    {
        DrawCat();
    }

    private static void DrawCat()
    {
        int size = ReadIntagerInput();
        char character = ReadCharacterInput();

        int counterThatHelpForDrawingTheCat = GetCounterForHelpDrawingTheCat(size);

        DrawEars(character, counterThatHelpForDrawingTheCat);
        DrawHead(character, counterThatHelpForDrawingTheCat);
        DrawNeck(character, counterThatHelpForDrawingTheCat);
        DrawUpperBody(character, counterThatHelpForDrawingTheCat);
        DrawFirstPartOfLowerBodyWithTail(character, counterThatHelpForDrawingTheCat);
        DrawSecondPartOfLowerBodyWithTail(character, counterThatHelpForDrawingTheCat);
        DrawBasisForCat(character, counterThatHelpForDrawingTheCat);
    }

    private static int GetCounterForHelpDrawingTheCat(int size)
    {
        int counterThatHelpForDrawingTheCat = 1;
        for (int i = 10; i < size; i += 4)
        {
            counterThatHelpForDrawingTheCat++;
        }

        return counterThatHelpForDrawingTheCat;
    }

    private static void DrawBasisForCat(char character, int counterThatHelpForDrawingTheCat)
    {
        Console.Write(' ');
        Console.Write(new string(character, counterThatHelpForDrawingTheCat + 5));
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Press Enter to EXIT...");
        Console.ReadLine();
    }

    private static void DrawSecondPartOfLowerBodyWithTail(char character, int counterThatHelpForDrawingTheCat)
    {
        for (int i = 0; i < counterThatHelpForDrawingTheCat + 2; i++)
        {
            Console.Write(new string(character, counterThatHelpForDrawingTheCat + 4));
            Console.Write(' ');
            Console.Write(' ');
            Console.Write(new string(character, 1));
            Console.WriteLine();
        }
        Console.Write(new string(character, counterThatHelpForDrawingTheCat + 4));
        Console.Write(' ');
        Console.Write(new string(character, 2));
        Console.WriteLine();
    }

    private static void DrawFirstPartOfLowerBodyWithTail(char character, int counterThatHelpForDrawingTheCat)
    {
        Console.Write(' ');
        Console.Write(new string(character, counterThatHelpForDrawingTheCat + 2));
        Console.Write(' ');
        Console.Write(' ');
        Console.Write(' ');
        Console.Write(new string(character, counterThatHelpForDrawingTheCat + 1));
        Console.WriteLine();
    }

    private static void DrawUpperBody(char character, int counterThatHelpForDrawingTheCat)
    {
        for (int i = 0; i < counterThatHelpForDrawingTheCat; i++)
        {
            Console.Write(' ');
            Console.Write(new string(character, counterThatHelpForDrawingTheCat + 2));
            Console.Write(' ');
            Console.WriteLine();
        }
    }

    private static void DrawNeck(char character, int counterThatHelpForDrawingTheCat)
    {
        for (int i = 0; i < counterThatHelpForDrawingTheCat; i++)
        {
            Console.Write(' ');
            Console.Write(' ');
            Console.Write(new string(character, counterThatHelpForDrawingTheCat));
            Console.Write(' ');
            Console.Write(' ');
            Console.WriteLine();
        }
    }

    private static void DrawHead(char character, int counterThatHelpForDrawingTheCat)
    {
        for (int i = 0; i < counterThatHelpForDrawingTheCat; i++)
        {
            Console.Write(' ');
            Console.Write(new string(character, counterThatHelpForDrawingTheCat + 2));
            Console.Write(' ');
            Console.WriteLine();
        }
    }

    private static void DrawEars(char character, int counterThatHelpForDrawingTheCat)
    {
        Console.Write(' ');
        Console.Write(new string(character, 1));
        Console.Write(new string(' ', counterThatHelpForDrawingTheCat));
        Console.Write(new string(character, 1));
        Console.Write(' ');
        Console.WriteLine();
    }

    private static char ReadCharacterInput()
    {
        char readedChar = char.Parse(Console.ReadLine());

        return readedChar;
    }

    private static int ReadIntagerInput()
    {
        int readedNumber = int.Parse(Console.ReadLine());

        return readedNumber;
    }
}

