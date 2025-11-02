using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BeeState : MonoBehaviour
{
    public Vector3 enemyDir = new Vector3(0f, 0f, 0f);
    public float enemySpeed = 0f;

    public bool isGrounded = false;
    public bool isPlayerContact = false; // is enemy in contact with players
    public bool isEnemyContact = false; // is enemy is around other enemies
    public bool isPlayerSeen = false; // are bees seeing player

    public abstract BeeState Run();
    public abstract BeeState Run(Vector3 enemyDir, float enemySpeed, bool isGrounded, bool isPlayerContact, bool isEnemyContact, bool isPlayerSeen);
}
