using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    // Start is called before the first frame update
    public bool canSeePlayer = false;
    public FollowHim followState;
    public override State RunCurrentState()
    {
        if (canSeePlayer)
        {
            Debug.Log("Switching to Follow State");
            return followState;
        }
        else
        {
            return this;
        }
    }
}
