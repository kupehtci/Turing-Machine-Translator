# Turing Machine Simulator

This repository contains a simple implementation of a Turing machine simulator in C# using the console. 
This structure can be easily adapted to accept a specific language by the creation of new states with transitions for each symbol of the new lenguage adapted.  

## Overview

The Turing machine implementation is constrain to its basic structure and consists of the following key components:

- **TuringMachine**: The main class representing the Turing machine. It initializes with an input tape and a specified initial state. The machine executes transitions until a stop condition is reached or it gets to the end of the `strip`
  
- **State**: A class representing a state of the Turing machine. Each state has a set of transitions defined for specific input symbols, determining the next state, symbol to write in the strip, and head movement. This transitions are saved in a dictionary to save each function with its correspondent char symbol. 

- **StateFunction**: A helper class encapsulating the information for a transition, including the next state, symbol to write, and head movement.

- **StripMovement**: An enumerator that represent the strip movement. It renames the -1, 0, 1 movements into a more legible keys. 

## Usage

To use the Turing machine, follow these steps:

1. Create instances of the `State` class to represent different states in the machine.
2. Define transitions for each state by specifying the next state, symbol to write, and head movement for each input symbol.
3. Initialize a `TuringMachine` with the initial input tape and the initial state.
4. Run the machine using the `Run` method, and observe the state transitions and tape modifications.

## Example

Here's an example scenario implemented in the provided code:

- Initial Room State (`stateSINI`)
  - Transitions:
    - 'p' => Move to Intermediate Room (`stateSINT`) and move the head to the right.
    - 'a' => Move to Boss Room (`stateSB`) and move the head to the right.
    - 't' => Move to Intermediate Room (`stateSINT`) and move the head to the right.
    - 'i', 'm', 'b' => Stop the machine.

- Intermediate Room State (`stateSINT`)
  - Transitions:
    - 'p', 'a' => Move to Boss Room (`stateSB`) and move the head to the right.
    - 't' => Move to Initial Room (`stateSINI`) and move the head to the right.
    - 'i', 'm', 'b' => Stop the machine.

- Treasure Room State (`stateST`)
  - Transitions:
    - 'p', 'a' => Move to Boss Room (`stateSB`) and move the head to the right.
    - 't' => Move to Intermediate Room (`stateSINT`) and move the head to the right.
    - 'i', 'm', 'b' => Stop the machine.

- Boss Room State (`stateSB`)
  - Transitions:
    - 'p' => Move to Treasure Room (`stateST`) and move the head to the right.
    - 'a' => Move to Intermediate Room (`stateSINT`) and move the head to the right.
    - 't' => Move to Intermediate Room (`stateSINT`) and move the head to the right.
    - 'i', 'm', 'b' => Stop the machine.

## How to adapt to an specific language

To adapt the Turing machine to accept an specific language or specific symbol, there is only needed to create the correct states and its own functions to that symbols in the turing machine intitialization method. 

The new `state` can be declared by creating the new state with a name for debug purposes and declare a `new transition` for each symbol of this language : 
```CSHARP
State stateQ0 = new State("State Q0");

// StateSINI transitions declaration 
stateQ0.transitions['a'] = new StateFunction(stateQ2, 'l', StripMovement.STOP);
stateQ0.transitions['b'] = new StateFunction(stateQ3, 'o', StripMovement.STOP); 
stateQ0.transitions['c'] = new StateFunction(stateQ7, 'y', StripMovement.STOP); 
stateQ0.transitions['d'] = new StateFunction(stateQ9, 'r', StripMovement.STOP);
stateQ0.transitions['e'] = new StateFunction(stateQ5, 'w', StripMovement.RIGHT); 
stateQ0.transitions['f'] = new StateFunction(stateQ0, 'q', StripMovement.RIGHT);
stateQ0.transitions['g'] = new StateFunction(stateQ5, 'g', StripMovement.RIGHT);
// ... More symbols impplementation
```


## How to Run

1. Compile the C# code using your preferred development environment.

2. Execute the compiled executable.

3. Enter the seed using symbols 'p', 'a', 't', 'i', 'm', 't', 'b' to see the machine's behavior.

## License

Feel free to modify and extend the code based on your specific requirements!
