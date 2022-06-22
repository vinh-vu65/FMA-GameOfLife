namespace GameOfLife.Code.Exceptions;

public class BoundaryNotFoundException : Exception
{
    public BoundaryNotFoundException() : base(message:"Boundary not found, please ensure the last line of seed file " +
                                                      "contains an asterisk <*> and try again.")
    { }
}