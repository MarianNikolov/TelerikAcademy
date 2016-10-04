namespace DefineClass
{
    using System;

    public class Display
    {
        private int size;
        private int numberOfColors;

        public Display(int size = 0, int numberOfColors = 0)
        {
            this.Size = size;
            this.NumberOfColors = numberOfColors;
        }

        public int Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Size must be positive integer!");
                }
                this.size = value;
            }
        }

        public int NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Number of colors must be positive integer!");
                }
                this.numberOfColors = value;
            }
        }

        public override string ToString()
        {
            string result = string.Empty;
            if (size > 0)
            {
                result += string.Format("Size of display is {0} ", Size);
            }

            if (numberOfColors > 0)
            {
                result += string.Format("Number of colors of display is {0} ", NumberOfColors);
            }

            return result;
        }


    }
}
