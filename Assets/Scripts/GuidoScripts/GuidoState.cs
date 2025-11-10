using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GuidoState : MonoBehaviour
{
    public Vector3 guidoDir = new Vector3(0f, 0f, 0f);
    public float guidoSpeed = 0f;

    public bool isGrounded = false;
    public bool isPlayerContact = false; // is guido in contact with players
    public bool isEnemyContact = false; // is guido is around other enemies
    public bool isPlayerSeen = false; // is guido seeing player
    public bool isBeeSeen = false; // does guido spot a bee

    public abstract GuidoState Run();
    public abstract GuidoState Run(Vector3 enemyDir, float enemySpeed, bool isGrounded, bool isPlayerContact, bool isEnemyContact, bool isPlayerSeen, bool isBeeSeen);
}
