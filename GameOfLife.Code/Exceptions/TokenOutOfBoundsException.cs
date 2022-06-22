namespace GameOfLife.Code.Exceptions;

public class TokenOutOfBoundsException : Exception
{
    public TokenOutOfBoundsException(int y) : base(message: $"Seed file has a token beyond bounds set by <*> in file on Row {y+1}. " +
                                                       "Ensure all tokens are within bounds and try again.")
    { }
}