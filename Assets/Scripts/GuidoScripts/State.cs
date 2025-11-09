using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GuidoState : MonoBehaviour
{

    public float moveSpeed = 0f; // Movement speed for Guido in this state
    public bool IsFollowingPlayer = false; // Is Guido following the player in this state 
    public bool IsFollowingCircuit = false; // Is Guido following a circuit in this state 
    public abstract GuidoState RunCurrentState();
}
 