// #define mTEST
using System;
using System.Collections.Generic;


public class TuringMachine
{
    private List<State> states = new List<State>();
    private State currentState;
    private List<char> strip = new List<char>();
    private int headPosition;

    public TuringMachine(string input, State initialState)
    {
        strip.AddRange(input.ToCharArray());
        headPosition = 0;
        currentState = initialState;
    }

    public void SetInput(string input)
    {
        strip.Clear();
        strip.AddRange(input.ToCharArray());
    }

    public void AddState(State state)
    {
        states.Add(state);
    }

    public void Run()
    {
        while (true)
        {
            if (headPosition < 0 || headPosition >= strip.Count)
            {
                Console.WriteLine("Tape out of bounds");
                break;
            }

            char currentSymbol = strip[headPosition];

            if (!currentState.transitions.ContainsKey(currentSymbol))
            {
                Console.WriteLine("No transition defined for state " + currentState + " and symbol " + currentSymbol);
                break;
            }

            StateFunction transition = currentState.transitions[currentSymbol];
            strip[headPosition] = transition._symbol;
            currentState = transition._nextState;
            headPosition += (int)transition._movement;

            Console.WriteLine($"State: {currentState.name}, Tape: {string.Join("", strip)}, Head Position: {headPosition}");
            
            if (transition._movement == StripMovement.STOP)
            {
                Console.WriteLine("Found a stop movement");
                break; 
            }
        }

        Console.WriteLine("Result: " + string.Join("", strip));
    }
}

class Program
{
    static void Main()
    {
        TuringMachine turingMachine = InitializeTuringMachinePAT();

        
        while (true)
        {
            Console.WriteLine("Enter the seed using p,a,t: ");
            string inputSeed = Console.ReadLine(); 
            
            turingMachine.SetInput(inputSeed);

            turingMachine.Run(); 
        }
    }

    static TuringMachine InitializeTuringMachinePAT()
    {
        State stateSINI = new State("Initial Room state");
        State stateSINT = new State("Intermediate Room state");
        State stateST = new State("Treasure Room state");
        State stateSB = new State("Boss Room state");
        
        // StateSINI transitions declaration 
        stateSINI.transitions['i'] = new StateFunction(stateSINI, 'i', StripMovement.STOP);
        stateSINI.transitions['m'] = new StateFunction(stateSINI, 'i', StripMovement.STOP); 
        stateSINI.transitions['t'] = new StateFunction(stateSINI, 'i', StripMovement.STOP); 
        stateSINI.transitions['b'] = new StateFunction(stateSINI, 'i', StripMovement.STOP);
        stateSINI.transitions['p'] = new StateFunction(stateSINT, 'i', StripMovement.RIGHT); 
        stateSINI.transitions['a'] = new StateFunction(stateSB, 'i', StripMovement.RIGHT);
        stateSINI.transitions['t'] = new StateFunction(stateSINT, 'i', StripMovement.RIGHT);
        
        // StateSINT transitions declaration 
        stateSINT.transitions['i'] = new StateFunction(stateSINI, 'm', StripMovement.STOP);
        stateSINT.transitions['m'] = new StateFunction(stateSINI, 'm', StripMovement.STOP); 
        stateSINT.transitions['t'] = new StateFunction(stateSINI, 'm', StripMovement.STOP); 
        stateSINT.transitions['b'] = new StateFunction(stateSINI, 'm', StripMovement.STOP);
        stateSINT.transitions['p'] = new StateFunction(stateSB, 'm', StripMovement.RIGHT); 
        stateSINT.transitions['a'] = new StateFunction(stateSB, 'm', StripMovement.RIGHT);
        stateSINT.transitions['t'] = new StateFunction(stateSINT, 'm', StripMovement.RIGHT);

        // StateST transitions declaration 
        stateST.transitions['i'] = new StateFunction(stateSINI, 't', StripMovement.STOP);
        stateST.transitions['m'] = new StateFunction(stateSINI, 't', StripMovement.STOP); 
        stateST.transitions['t'] = new StateFunction(stateSINI, 't', StripMovement.STOP); 
        stateST.transitions['b'] = new StateFunction(stateSINI, 't', StripMovement.STOP);
        stateST.transitions['p'] = new StateFunction(stateSB, 't', StripMovement.RIGHT); 
        stateST.transitions['a'] = new StateFunction(stateSB, 't', StripMovement.RIGHT);
        stateST.transitions['t'] = new StateFunction(stateSINT, 't', StripMovement.RIGHT);
        
        // StateSINT transitions declaration 
        stateSB.transitions['i'] = new StateFunction(stateSINI, 'b', StripMovement.STOP);
        stateSB.transitions['m'] = new StateFunction(stateSINI, 'b', StripMovement.STOP); 
        stateSB.transitions['t'] = new StateFunction(stateSINI, 'b', StripMovement.STOP); 
        stateSB.transitions['b'] = new StateFunction(stateSINI, 'b', StripMovement.STOP);
        stateSB.transitions['p'] = new StateFunction(stateST, 'b', StripMovement.RIGHT); 
        stateSB.transitions['a'] = new StateFunction(stateSINT, 'b', StripMovement.RIGHT);
        stateSB.transitions['t'] = new StateFunction(stateSINT, 'b', StripMovement.RIGHT);
        
        TuringMachine turingMachine = new TuringMachine("", stateSINI); 
        turingMachine.AddState(stateSINI);
        turingMachine.AddState(stateSINT);
        turingMachine.AddState(stateST);
        turingMachine.AddState(stateSB);
        
        return turingMachine;
    }
    
    
    // Binary strip usage
    #if mTEST
    public void InitializeTuringMachineBinary()
    {
        // // Define states and transitions
        // State state0 = new State();
        // State state1 = new State();
        // State state2 = new State();
        //
        // state0.transitions['0'] = new StateFunction(state1, '1', StripMovement.RIGHT);
        // state0.transitions['1'] = new StateFunction(state0, '1', StripMovement.RIGHT);
        // state0.transitions['_'] = new StateFunction(state0, '_', StripMovement.STOP);
        //
        // state1.transitions['0'] = new StateFunction(state1, '0', StripMovement.RIGHT);
        // state1.transitions['1'] = new StateFunction(state2, '1', StripMovement.RIGHT);
        // state1.transitions['_'] = new StateFunction(state0, '_', StripMovement.STOP);
        //
        // state2.transitions['0'] = new StateFunction(state1, '1', StripMovement.RIGHT);
        // state2.transitions['1'] = new StateFunction(state0, '0', StripMovement.RIGHT);
        // state2.transitions['_'] = new StateFunction(state2, '_', StripMovement.STOP);
        //
        // TuringMachine turingMachine = new TuringMachine("0011", state0); 
        // turingMachine.AddState(state0);
        // turingMachine.AddState(state1);
        // turingMachine.AddState(state2);
    }
    #endif
}
