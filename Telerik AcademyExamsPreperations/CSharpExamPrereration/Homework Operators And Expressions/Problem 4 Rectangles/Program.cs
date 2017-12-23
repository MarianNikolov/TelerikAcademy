using System;

class Program
{

    /*
     Problem 4. Rectangles

    Write an expression that calculates rectangle’s perimeter and area by given width and height.

Examples:
    width 	height 	perimeter 	area
    3 	    4 	    14 	        12
    2.5 	3 	    11 	        7.5
    5 	    5 	    20 	        25
     */

    static void Main()
    {
        Console.Write("Enter width: ");
        double width = double.Parse(Console.ReadLine());
        Console.Write("Enter height: ");
        double height = double.Parse(Console.ReadLine());
        double perimeter = (width * 2) + (height * 2);
        double area = width * height;
        Console.WriteLine("Perimeter is: " + perimeter);
        Console.WriteLine("Area is: " + area);
    }
}

