using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeIdleState : BeeState
{
    //to be fair, this isnt really too necessary for just exclusively the bees
    // but it helps it so that if the bees are stuck, they just retreat to this then they're capable of switching yet again.
    
    public override BeeState Run()
    {
        return this;
    }

    public override BeeState Run(Vector3 enemyDir, float enemySpeed, bool isGrounded, bool isPlayerContact, bool isEnemyContact, bool isPlayerSeen)
    {
        this.enemyDir = enemyDir;
        this.isGrounded = isGrounded;
        this.isEnemyContact = isEnemyContact;
        this.isPlayerContact = isPlayerContact;
        this.isPlayerSeen = isPlayerSeen;

        return this;
    }
}
