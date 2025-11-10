using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidoFollowState : BeeState
{
    public GameObject Guido;
    public GameObject player;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //so that guido can actually see player.
    }
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

        //This is just him being out here for the time being.
        //must figure out how to get him to follow player.
    }

}

