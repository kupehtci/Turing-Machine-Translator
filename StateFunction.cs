using System.Collections.Generic;

/// <summary>
/// This enum has the different strip movements that the reading head can perform with the Strip of the Turing Machine. 
/// </summary>
public enum StripMovement
{
    LEFT = -1, 
    RIGHT = 1, 
    STOP = 0
}

/// <summary>
/// StateFunction represent a function that the Turing Machine executes for each symbol that can found in the strip in the turing machine.
/// This function contains:
/// * _nextState reference for switching to the next state once it has finished its execution for the next symbol in the strip
/// * _symbol replacement symbol to exchange in the strip
/// * _movement StripMovement that represent the next movement of the strip
/// </summary>
public class StateFunction
{
    public State _nextState;
    public char _symbol;
    public StripMovement _movement;

    public StateFunction(State nextState, char symbol, StripMovement movement)
    {
        _nextState = nextState;
        _symbol = symbol;
        _movement = movement; 
    }
}

public abstract class MathUtil
{
    public static int Max(int a, int b)
    {
        return a > b ? a : b; 
    }
    
}