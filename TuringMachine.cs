public class TuringMachine
{
    private List<State> states = new List<State>();
    private State currentState;
    private List<char> strip = new List<char>();
    private int headPosition = 0;

    public TuringMachine(string input, State initialState)
    {
        strip.AddRange(input.ToCharArray());
        headPosition = 0;
        currentState = initialState;
    }

    /// <summary>
    /// Clear the strip and replace with the new one and reset the reading head position
    /// </summary>
    /// <param name="input">New strip in form of string</param>
    public void SetInput(string input)
    {
        strip.Clear();
        headPosition = 0; 
        strip.AddRange(input.ToCharArray());
    }

    /// <summary>
    /// Add a state to the Turing Machine
    /// </summary>
    /// <param name="state">new state to add to the machine</param>
    public void AddState(State state)
    {
        states.Add(state);
    }

    /// <summary>
    /// Execute the Turing Machine.
    /// Starts reading the strip and executing the depending StateFunction depending on the current State and
    /// the function defined for that symbol of the strip. 
    /// </summary>
    public void Run()
    {
        // Read all strip until gets a stop
        while (headPosition >= 0 && headPosition < strip.Count)
        {
            char currentSymbol = strip[headPosition];

            if (!currentState.transitions.ContainsKey(currentSymbol))
            {
                Console.WriteLine("No transition defined for state " + currentState + " and symbol " + currentSymbol);
                break;
            }

            StateFunction transition = currentState.transitions[currentSymbol];
            Console.ForegroundColor = ConsoleColor.Cyan; 
            Console.WriteLine($"Function {strip[headPosition]};({transition._nextState.name}, '{transition._symbol}', {transition._movement.ToString()})");
            
            strip[headPosition] = transition._symbol;
            currentState = transition._nextState;
            headPosition += MathUtil.Max(0, (int)transition._movement);
            
            Console.ForegroundColor = ConsoleColor.Magenta; 
            Console.WriteLine($"State: {currentState.name}, Tape: {string.Join("", strip)}, Head Position: {headPosition}\n");
        }

        Console.ForegroundColor = ConsoleColor.White; 
        Console.WriteLine("Result: " + string.Join("", strip));
    }
}