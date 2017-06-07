using System;
using System.Text;

namespace ComputerConfigurations.Importer
{
    public static class RandomGenerator
    {
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        private static Random random = new Random();

        public static int GetRandomNumber(int min = 0, int max = int.MaxValue / 2)
        {
            return random.Next(min, max + 1);
        }

        public static string GetRandomString(int minLength = 0, int maxLength = int.MaxValue / 2)
        {
            var length = random.Next(minLength, maxLength);
            var result = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                result.Append(Alphabet[random.Next(0, Alphabet.Length)]);
            }
            return result.ToString();
        }

        public static DateTime GetRandomDate(DateTime? after = null, DateTime? before = null)
        {
            DateTime minDate = after ?? new DateTime(1950, 1, 1, 0, 0, 0);
            DateTime maxDate = before ?? new DateTime(2050, 12, 31, 23, 59, 59);

            var seconds = GetRandomNumber(minDate.Second, maxDate.Second);
            var minutes = GetRandomNumber(minDate.Minute, maxDate.Minute);
            var hours = GetRandomNumber(minDate.Hour, maxDate.Hour);
            var day = GetRandomNumber(minDate.Day, maxDate.Day);
            var month = GetRandomNumber(minDate.Month, maxDate.Month);
            var year = GetRandomNumber(minDate.Year, maxDate.Year);

            if (day > 28)
            {
                day = 28;
            }

            return new DateTime(year, month, day, hours, minutes, seconds);
        }
    }
}
