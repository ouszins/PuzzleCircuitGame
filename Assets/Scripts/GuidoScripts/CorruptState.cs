using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptState : State
{
    //plan for this one is just. to have guido enter corruption
    //over time, corruption should cause a progress bar to elapse
    // if progress bar becomes full, game is over
    // james will handle guido messing with the circuits

    // guido should turn purple. 
    // done by swapping materials over time
    // rgb parameter where guido would turn purple

    // if progress bar = x, then guido receives a tint/rgb value shift to x
    // if purple == true, game over

    // Start is called before the first frame update
    public override State RunCurrentState()
    {
        return this;
    }

    
}
