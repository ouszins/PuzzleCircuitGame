using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSpawnState : BeeState
{
<<<<<<< HEAD
    /* essentially whats needed here:
     * planning for the bee to spawn in two formats
     * two goals in mind essentially
        - attack guido
        - attack player
     * this shouldnt be so bad.
    */
=======
    // essentially whats needed here:
>>>>>>> 9b157944c081aa2447086c1643e91aaeadba4f99

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

