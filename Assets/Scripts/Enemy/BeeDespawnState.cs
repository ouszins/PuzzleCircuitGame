using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeDespawnState : BeeState
{
    public override BeeDespawnState Run()
    {
        return this;
    }

    public override BeeDespawnState Run(Vector3 enemyDir, float enemySpeed, bool isGrounded, bool isPlayerContact, bool isEnemyContact, bool isPlayerSeen)
    {

        //Focus on Despawning first
        DespawnBee();
        return this;
    }

    public void DespawnBee()
    {
        Destroy(transform.parent.parent.gameObject);
    }
}
