using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.HID;

public class GuidoFSMachine : MonoBehaviour
{
    public GuidoState current; // current file allows for transitions between state
    public Vector3 newGuidoDir = new Vector3(0f,0f, 0f);
    public float newGuidoSpeed = 0f;

    public GameObject player; // reference to player object

    public bool newIsGrounded = false;
    public bool newPlayerContact = false; //soGuido doesnt bump into player
    public bool newEnemyContact = false; //so guido isnt bumping into enemies persay.
    public bool newPlayerSeen = false; // to keep player in sight.
    public bool newBeesSeen = false;
    RaycastHit ray; //what allows guido to see anything and anyone in the first place.

    //planning to establish as well a ChaseState, for when he is chasing player
    //This is if I have the time.
    //You know, since this is just me now.

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void FixedUpdate()
    {
        //current states pass its values onto new parameters once called
        GuidoState next = current?.Run(newGuidoDir, newGuidoSpeed, newIsGrounded, newPlayerContact, newEnemyContact, newPlayerSeen, newBeesSeen);
        if (next != null) 
        {
            newGuidoDir = current.guidoDir;
            newGuidoSpeed = current.guidoSpeed;
            newIsGrounded = current.isGrounded;
            newPlayerContact = current.playerContact;
            newEnemyContact = current.enemyContact;
            newPlayerSeen = current.playerSeen;
            newBeesSeen = current.beesSeen;
            current = next;
        }

    }

    public guidoState getCurrentState()
    {
        return current;
    }

    //taken from my OWN code from the BeeAI throughout this entire file.
    //triggers for player coming into contact with Guido

    public string CurrentStateAsString
    {
        get
        {
            switch (current)
            {
                case GuidoSpawnState:
                    return "Spawning..";
                case GuidoIdleState:
                    return "Idling..";
                case GuidoFollowState:
                    return "Following..";
                case GuidoAttackState:
                    return "Attacking Bees..";
                case GuidoDespawnState:
                    return "Despawning..";
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player in contact with Bee");
            newPlayerContact = true;
        }

        if (other.CompareTag("Enemy"))
        {
            //Enemy in contact with the player
            newEnemyContact = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("NOT in contact with Bee");
            newPlayerContact = false;
        }
        if (other.CompareTag("Enemy"))
        {
            //Enemy not in contact
            newEnemyContact = false;
        }
    }
}