using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidoFSM : MonoBehaviour
{
    public GuidoState currentState; // must assign in inspector(starting state)

    public GameObject player; // reference to player object

    public GuidoState FollowState;
    public GuidoState CircuitState;
    

    // Update is called once per frame

    public void Start()
    {
        // Find and assign the player object at the start, just to be safe yk
        player = GameObject.FindGameObjectWithTag("Player");
        if (currentState == null)
        {
            Debug.LogWarning($"{name}: No state assigned at start :(( .");
            currentState = FollowState; // default to FollowState if none assigned
        }

        EnableOnlyCurrentState();

    }

    private void Update()
    {
        if (currentState == null)
        {
            Debug.LogWarning($"{name}: No current state assigned in FSM.");
            return;
        }
        // Run the current state and get the next state if there's a transition
        currentState.RunCurrentState();

        switch (currentState)
        {
            case FollowHim: 
                if (currentState.IsFollowingCircuit == false)
                {
                    Debug.Log("FSM changing to Follow State");
                    SwitchToThisState(CircuitState);
                }
                break;
            case CircuitFinder:
                if (currentState.IsFollowingCircuit == false)
                {
                    Debug.Log("FSM changing to Follow State");
                    SwitchToThisState(FollowState);
                }
                break;
            default:
                Debug.LogWarning($"{name}: Current state is unrecognized.");
                break;
        }
    }

    public void SwitchToThisState(GuidoState newState)
    {
        currentState = newState;
        EnableOnlyCurrentState();
    }

    public void EnableOnlyCurrentState()
    {
        if (FollowState != null)
            FollowState.enabled = (currentState == FollowState);
        if (CircuitState != null)
            CircuitState.enabled = (currentState == CircuitState);
    }

}