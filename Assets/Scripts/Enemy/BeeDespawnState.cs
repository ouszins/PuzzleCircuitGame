using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeDespawnState : BeeState
{
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

        //Focus on Despawning first
        Debug.Log("Bee dead");
        DespawnBee();
        return this;
    }

    public void DespawnBee()
    {
        Destroy(transform.parent.parent.gameObject);
    }
}