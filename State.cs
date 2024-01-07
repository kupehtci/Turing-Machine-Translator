using System;
using System.Collections; 

public class State
{
    public string name = ""; 
    public Dictionary<char, StateFunction> transitions = new Dictionary<char, StateFunction>();

    public State(string name)
    {
        this.name = name; 
    }
}