using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class BeePursueState : BeeState
{
    public GameObject Bee;
    public GameObject player;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

=======
<<<<<<<< HEAD:Assets/Scripts/Enemy/BeeIdleState.cs
public class BeeIdleState : BeeState
========
public class BeePursueState : BeeState
>>>>>>>> 9b157944c081aa2447086c1643e91aaeadba4f99:Assets/Scripts/Enemy/BeePursueState.cs
{
>>>>>>> 9b157944c081aa2447086c1643e91aaeadba4f99
    public override BeeState Run()
    {
        return this;
    }

    public override BeeState Run(Vector3 enemyDir, float enemySpeed, bool isGrounded, bool isPlayerContact, bool isEnemyContact, bool isPlayerSeen)
    {
<<<<<<< HEAD
=======

>>>>>>> 9b157944c081aa2447086c1643e91aaeadba4f99
        this.enemyDir = enemyDir;
        this.isGrounded = isGrounded;
        this.isEnemyContact = isEnemyContact;
        this.isPlayerContact = isPlayerContact;
        this.isPlayerSeen = isPlayerSeen;

        return this;
    }
}
