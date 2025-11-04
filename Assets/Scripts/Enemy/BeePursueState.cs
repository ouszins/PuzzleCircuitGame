using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeePursueState : BeeState
{
    public GameObject Bee;
    public GameObject player;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

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
