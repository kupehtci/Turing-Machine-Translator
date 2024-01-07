// #define mTEST
using System;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        TuringMachine turingMachine = InitializeTuringMachinePAT();

        
        while (true)
        {
            Console.Write("Enter the seed using the following language i, m, t, b, p, a, t: ");
            string inputSeed = Console.ReadLine(); 
            
            turingMachine.SetInput(inputSeed);

            turingMachine.Run(); 
        }
    }

    /// <summary>
    /// Initialization of the Turing Machine defining its states.
    /// This set of states and its transitions define the machine to accept the following language:
    ///  Γ = {i, m, t, b, p, a, t}
    /// </summary>
    /// <returns></returns>
    static TuringMachine InitializeTuringMachinePAT()
    {
        State stateSINI = new State("Initial Room state");
        State stateSINT = new State("Intermediate Room state");
        State stateST = new State("Treasure Room state");
        State stateSB = new State("Boss Room state");
        
        // StateSINI transitions declaration 
        stateSINI.transitions['i'] = new StateFunction(stateSINI, 'i', StripMovement.RIGHT);
        stateSINI.transitions['m'] = new StateFunction(stateSINI, 'i', StripMovement.RIGHT); 
        stateSINI.transitions['t'] = new StateFunction(stateSINI, 'i', StripMovement.RIGHT); 
        stateSINI.transitions['b'] = new StateFunction(stateSINI, 'i', StripMovement.RIGHT);
        stateSINI.transitions['p'] = new StateFunction(stateSINT, 'i', StripMovement.RIGHT); 
        stateSINI.transitions['a'] = new StateFunction(stateSB, 'i', StripMovement.RIGHT);
        stateSINI.transitions['t'] = new StateFunction(stateSINT, 'i', StripMovement.RIGHT);
        
        // StateSINT transitions declaration 
        stateSINT.transitions['i'] = new StateFunction(stateSINI, 'm', StripMovement.LEFT);
        stateSINT.transitions['m'] = new StateFunction(stateSINI, 'm', StripMovement.RIGHT); 
        stateSINT.transitions['t'] = new StateFunction(stateSINI, 'm', StripMovement.LEFT); 
        stateSINT.transitions['b'] = new StateFunction(stateSINI, 'm', StripMovement.RIGHT);
        stateSINT.transitions['p'] = new StateFunction(stateSB, 'm', StripMovement.RIGHT); 
        stateSINT.transitions['a'] = new StateFunction(stateSINT, 'm', StripMovement.RIGHT);
        stateSINT.transitions['t'] = new StateFunction(stateST, 'm', StripMovement.RIGHT);

        // StateST transitions declaration 
        stateST.transitions['i'] = new StateFunction(stateSINI, 't', StripMovement.RIGHT);
        stateST.transitions['m'] = new StateFunction(stateSINI, 't', StripMovement.LEFT); 
        stateST.transitions['t'] = new StateFunction(stateSINI, 't', StripMovement.LEFT); 
        stateST.transitions['b'] = new StateFunction(stateSINI, 't', StripMovement.RIGHT);
        stateST.transitions['p'] = new StateFunction(stateSB, 't', StripMovement.RIGHT); 
        stateST.transitions['a'] = new StateFunction(stateSB, 't', StripMovement.RIGHT);
        stateST.transitions['t'] = new StateFunction(stateSINT, 't', StripMovement.RIGHT);
        
        // StateSINT transitions declaration 
        stateSB.transitions['i'] = new StateFunction(stateSINI, 'b', StripMovement.RIGHT);
        stateSB.transitions['m'] = new StateFunction(stateSINI, 'b', StripMovement.LEFT); 
        stateSB.transitions['t'] = new StateFunction(stateSINI, 'b', StripMovement.LEFT); 
        stateSB.transitions['b'] = new StateFunction(stateSINI, 'b', StripMovement.LEFT);
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
    
    /// <summary>
    /// Simple structure initialization of the Turing Machine for using a bynary symbols Turing Machine wich language consis of:
    /// {0, 1, _} being "_" the representation of a blank space
    /// </summary>
    public void InitializeTuringMachineBinary()
    {
        // Define states and transitions
        State state0 = new State("StateQ0");
        State state1 = new State("StateQ1");
        State state2 = new State("StateQ2");
        
        state0.transitions['0'] = new StateFunction(state1, '1', StripMovement.RIGHT);
        state0.transitions['1'] = new StateFunction(state0, '1', StripMovement.RIGHT);
        state0.transitions['_'] = new StateFunction(state0, '_', StripMovement.STOP);
        
        state1.transitions['0'] = new StateFunction(state1, '0', StripMovement.RIGHT);
        state1.transitions['1'] = new StateFunction(state2, '1', StripMovement.RIGHT);
        state1.transitions['_'] = new StateFunction(state0, '_', StripMovement.STOP);
        
        state2.transitions['0'] = new StateFunction(state1, '1', StripMovement.RIGHT);
        state2.transitions['1'] = new StateFunction(state0, '0', StripMovement.RIGHT);
        state2.transitions['_'] = new StateFunction(state2, '_', StripMovement.STOP);
        
        TuringMachine turingMachine = new TuringMachine("0011", state0); 
        turingMachine.AddState(state0);
        turingMachine.AddState(state1);
        turingMachine.AddState(state2);
    }
}
