namespace Dealership.Common
{
    public interface IValidateRangeProvider
    {
        void ValidateRange(int? value, int min, int max, string message);
    }
}