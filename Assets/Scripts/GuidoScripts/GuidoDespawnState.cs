using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidoDespawnState : GuidoState
{
    public override GuidoState Run()
    {
        return this;
    }

    public override GuidoState Run(Vector3 guidoDir, float guidoSpeed, bool isGrounded, bool isPlayerContact, bool isEnemyContact, bool isPlayerSeen, bool isBeeSeen)
    {
        this.guidoDir = guidoDir;
        this.isGrounded = isGrounded;
        this.isEnemyContact = isEnemyContact;
        this.isPlayerContact = isPlayerContact;
        this.isPlayerSeen = isPlayerSeen;
        this.isBeeSeen = isBeeSeen;

        //Focus on Despawning first
        Debug.Log("Guido gone");
        DespawnGuido();
        return this;
    }

    public void DespawnGuido()
    {
        Destroy(transform.parent.parent.gameObject);
    }
}