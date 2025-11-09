using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidoFSM : MonoBehaviour
{
    public GuidoState current; // current file allows for transitions between state

    public GameObject player; // reference to player object

    public GuidoState FollowState;
    public GuidoState CircuitState;

    //WHAT IS THIS


    public bool newIsGrounded = false;
    public bool newPlayerContact = false; //soGuido doesnt bump into player
    public bool newPlayerSeen = false; // to keep player in sight.
    
    //planning to establish as well a ChaseState, for when he is chasing player
    //This is if I have the time.
    //You know, since this is just me now.

    // Update is called once per frame

    public void Start()
    {
        // Find and assign the player object at the start, just to be safe yk
        //WHAT DO YOU MEAN TO BE SAFE. YOU NEED THIS. 
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        if (current == null)
        {
            Debug.LogWarning($"{name}: No current state assigned in FSM.");
            return;
        }
        // Run the current state and get the next state if there's a transition
        current.RunCurrentState();

        switch (current)
        {
            case FollowHim: 
                if (current.IsFollowingCircuit == false)
                {   
                    Debug.Log("FSM changing to Follow State");
                    SwitchToThisState(CircuitState);
                }
                break;
            case CircuitFinder:
                if (current.IsFollowingCircuit == false)
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

    //what is any of that. that literally looks like ai. like holy FUCK.
    

    public void SwitchToThisState(GuidoState newState)
    {
        current = newState;
        EnableOnlyCurrentState();
    }

    //This is Stupid. Why do you need a whole ass stupid fucking function to switch fucking states.
    //SWITCH CASES SWITCH THE FUCKING CASES. ITS IN THE NAME.

    public void EnableOnlyCurrentState()
    {
        if (FollowState != null)
            FollowState.enabled = (current == FollowState);
        if (CircuitState != null)
            CircuitState.enabled = (current == CircuitState);
    }

    //WHY IS THIS HERE.
}