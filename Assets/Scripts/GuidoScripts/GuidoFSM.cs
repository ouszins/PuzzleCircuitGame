using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidoFSM : MonoBehaviour
{
    public State currentState; // must assign in inspector(starting state)


    // Update is called once per frame

    private void Update()
    {
        State nextState = currentState?.RunCurrentState();// If variable is not null run current state, if not run
        //Will run the state and return the next state to switch to when done
        Debug.Log("Update is running, current state is: " + currentState);
        if (nextState != null && nextState != currentState)
        {
            //switch to the enxt state
            SwitchToTheNextState(nextState);
            Debug.Log("Switched to next state: " + currentState);
        }
    }
    private void SwitchToTheNextState(State nextState) //switch current state to the state we pass in
    {
        Debug.Log("Switching from " + currentState + " to " + nextState);
        currentState = nextState;
    }
}
