using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeStingState : BeeState
{

    /* plan, to break this down into simple terms:
        - bee approaches you
        - bee confirms you're there
        - bee does 5 damage to you
        - upon doing 5 damage, die
        - dont forget, health for player. :]
    */
    public override BeeState Run()
    {
        return this;
    }

    public override BeeState Run(Vector3 enemyDir, float enemySpeed, bool isGrounded, bool isPlayerContact, bool isEnemyContact, bool isPlayerSeen)
    {
        this.isGrounded = isGrounded;
        this.enemySpeed = enemySpeed;
        this.isPlayerContact = isPlayerContact;
        this.isEnemyContact = isEnemyContact;
        this.isPlayerSeen = isPlayerSeen;

        return this;
    }
}