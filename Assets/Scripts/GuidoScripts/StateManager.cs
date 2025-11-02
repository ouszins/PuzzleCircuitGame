using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public State currentState;

    
    // Update is called once per frame
    void Update()
    {
        RunStateMachine();
    }
    private void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState();// If variable is not null run current state, if not run
        //Will run the state and return the next state to switch to when done

        if (nextState != null)
        {
            //switch to the enxt state
            SwitchToTheNextState(nextState);
        }
    }
    private void SwitchToTheNextState(State nextState) //switch current state to the state we pass in
    {
        currentState = nextState;
    }
}
