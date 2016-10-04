using System;

namespace ClassSizeInCSharpTask
{
    public class Size
    {
        private double width; 
        private double height;

        public Size(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public static Size GetRotatedSize(Size size, double angleOfTheFigureThatWillBeRotated)
        {
            var curentWidth = Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotated)) * size.width +
                    Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotated)) * size.height;
            var curentHeight = Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotated)) * size.width +
                    Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotated)) * size.height;

            var finalSize = new Size(curentWidth, curentHeight);

            return finalSize;
        }
    }
}
