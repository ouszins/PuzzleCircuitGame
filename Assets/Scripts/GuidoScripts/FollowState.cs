using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class FollowHim : State
{
    public Transform player; //will assigne to player
    public float followRadius = 10f; // the distance he should be around the player

    public float GooberSpeed = 5f; // speed of the goober(i love autocomplete)
    public float HeightOffGround = 1.5f; // height off the ground the NPC will stay at
   


    // Update is called once per frame
    public override State RunCurrentState()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > followRadius)
        {
            // Move towards the player
            Vector3 AimPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * GooberSpeed * Time.deltaTime;

            transform.LookAt(player); // Make the NPC face the player while moving
           
        }
        transform.position = new Vector3(transform.position.x, HeightOffGround, transform.position.z); // keep the NPC on the ground level

        return null;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(player.position, followRadius);// something similar could be used so sense if circuits are completed?
    }

}
