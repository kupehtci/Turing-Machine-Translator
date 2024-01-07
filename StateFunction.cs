using System.Collections.Generic;

public enum StripMovement
{
    LEFT = -1, 
    RIGHT = 1, 
    STOP = 0
}

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
