using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class FollowHim : State
{
    public Transform player; //will assigne to player
    public float followRadius = 10f; // the distance he should be around the player
    public float StopRadius = 10f; // the distance he should stop from the player
    public float GooberSpeed = 5f; // speed of the goober(i love autocomplete)
    public float HeightOffGround = 1.5f; // height off the ground the NPC will stay at
   


    // Update is called once per frame
    public override State RunCurrentState()
    {
        if (player == null)//to stop errors atm, will properly assign a permamnet "player" later
        
            player = GameObject.FindGameObjectWithTag("Player").transform; // find the player by tag if not assigned
        Debug.Log("Player not found");
        if (player == null)
            return this; // if still null, stay in this state
            Debug.Log("Follow State Active");
        float distance = Vector3.Distance(transform.position, player.position);
        //only moves if farther than Stopdistance and within follow distance
        if (distance >  StopRadius && distance < followRadius)
        {
            Debug.Log($"{name}: Following this" );
            // Move towards the player
            Vector3 AimPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
            Vector3 direction = (player.position - transform.position).normalized;

            Vector3 targetStopPos = player.position - player.forward * StopRadius;//should calculate distance away from player to stop at
            targetStopPos.y = transform.position.y;

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
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.position, StopRadius); // visualise the  stop radius
    }

}
