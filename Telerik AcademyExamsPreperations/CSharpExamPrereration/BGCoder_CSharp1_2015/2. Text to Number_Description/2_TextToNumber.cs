using System;


class _Text_to_Number_Description
{
    static void Main()
    {
        long numberM = long.Parse (Console.ReadLine());
        string text = Console.ReadLine();
        long momentResult = 0;
        long result = 0;
        long valueOfchar;


            for (int i = 0; i < text.Length; i++)
	        {
	            char curentChar = text[i];
            
                if (curentChar == '@')
                {
                    break;
                }
            
                // If the current character is a digit (0-9), then multiply the RESULT by this digit

                if (curentChar > 47 && curentChar < 58)
	            {
                    valueOfchar = curentChar - 48;
		            result = momentResult * valueOfchar;
                    momentResult = result;
	            }
                
                // If the current character is a letter, add its number from the Latin alphabet to RESULT. 'A' is with number 0
                if (curentChar > 64 && curentChar < 91)
	            {   
		            valueOfchar = curentChar - 65;
                    result = momentResult + valueOfchar;
                    momentResult = result;

	            }
                
                if (curentChar > 96 && curentChar < 123)
	            {
		            valueOfchar = curentChar - 97;
                    result = momentResult + valueOfchar;
                    momentResult = result;
	            }

                // If the current character is a symbol, that is different from the ones above, create module of the RESULT by the provided number (M)
                if (curentChar > 31 && curentChar < 48)
	            {
                    result = momentResult % numberM;
                    momentResult = result;
	            }

                if (curentChar > 57 && curentChar < 64)
                {
                    result = momentResult % numberM;
                    momentResult = result;
                }

                if (curentChar > 90 && curentChar < 97)
                {
                    result = momentResult % numberM;
                    momentResult = result;
                }

                if (curentChar > 122 && curentChar < 127)
                {
                    result = momentResult % numberM;
                    momentResult = result;
                }
	        }

            Console.WriteLine(result);
    }
}


