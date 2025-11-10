using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidoAttackState : GuidoState

{
    public override GuidoState Run()
    {
        return this;
    }

    public override GuidoState Run(Vector3 guidoDir, float guidoSpeed, bool isGrounded, bool isPlayerContact, bool isEnemyContact, bool isPlayerSeen, bool isBeeSeen)
    {
        this.enemyDir = enemyDir;
        this.isGrounded = isGrounded;
        this.isEnemyContact = isEnemyContact;
        this.isPlayerContact = isPlayerContact;
        this.isPlayerSeen = isPlayerSeen;
        this.isBeeSeen = false;

        //This is just him being out here
    }
}
