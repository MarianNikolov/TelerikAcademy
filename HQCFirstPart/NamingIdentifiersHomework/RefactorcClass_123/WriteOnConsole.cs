using System;

namespace RefactorcClass_123
{
    public class WriteOnConsole
    {
        private const int MaxCount = 6;

        public WriteOnConsole()
        {

        }

        public void DefaultNameOfTheTypeOfTheObject(bool BooleanType)
        {
            string DefaultToStringNameOfBooleanType = BooleanType.ToString();
            Console.WriteLine(DefaultToStringNameOfBooleanType);
        }
    }
}
