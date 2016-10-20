namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Represents an action read input which provides response.
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Reads the command from user.
        /// </summary>
        /// <returns>String command</returns>
        string ReadCommand();
    }
}
