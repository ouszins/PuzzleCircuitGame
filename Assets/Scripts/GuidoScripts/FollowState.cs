using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class FollowHim : State
{
    public Transform player; //will assigne to player
    public float followRadius = 10f; // the distance he should be around the player
    public float StopRadius = 5f; // the distance he should stop from the player
    public float GooberSpeed = 5f; // speed of the goober(i love autocomplete)
    public float HeightOffGround = 1.5f; // height off the ground the NPC will stay at

    //for timer for circuits later
    public float followTime = 10f; // time to follow before switching states
    private float Timer = 0f;

    public State circuitState; // state to switch to after following

    // Update is called once per frame
    public override State RunCurrentState()
    {
        if (player == null)//to stop errors atm, will properly assign a permamnet "player" later
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            
                player = playerObj.transform;
            
            else
            {
                Debug.LogWarning($"{name}: Player not found in scene.");
                return null; // Exit if player is not found
            }
        }
           
        Timer += Time.deltaTime;
        float distance = Vector3.Distance(transform.position, player.position);

        //only moves if farther than Stopdistance and within follow distance
        if (distance >  StopRadius && distance < followRadius)
        {
            Debug.Log($"{name}: Following player" );
            // Move towards the player
            Vector3 AimPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
            Vector3 direction = (player.position - transform.position).normalized;

            Vector3 targetStopPos = player.position - player.forward * StopRadius;//should calculate distance away from player to stop at
            targetStopPos.y = transform.position.y;

            transform.position += direction * GooberSpeed * Time.deltaTime;

            transform.LookAt(player); // Make the NPC face the player while moving
           
        }
        transform.position = new Vector3(transform.position.x, HeightOffGround, transform.position.z); // keep the NPC on the ground level

        if (Timer >= followTime)
        {
            Debug.Log($"{name}: Finished following player, switching to CircuitState.");
            Timer = 0f; // Reset timer for next time
            return circuitState; // Switch to CircuitState after followTime seconds
        }
        return this;
    }
    private void OnDrawGizmosSelected() 
    {
        if (player == null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(player.position, followRadius);// something similar could be used so sense if circuits are completed?
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(player.position, StopRadius); // visualise the  stop radius
        }
    }

}
