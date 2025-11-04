/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.HID;

public class BeeFSM : MonoBehaviour
{
    // current file allows for transitions between states for the bee
    public BeeState current;

    public Vector3 enemyDir = new Vector3(0f, 0f, 0f);
    public float enemySpeed = 0f;

    public bool isGrounded = false;
    public bool isPlayerContact = false; // is enemy in contact with players
    public bool isEnemyContact = false; // is enemy is around other enemies
    public bool isPlayerSeen = false; // are bees seeing player
    RaycastHit ray; //what allows the bee to see the player in the first place

    public GameObject player;

    private void Start()
    {
        isPlayerContact = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        //current state passes its values onto new parameters once called
        BeeState next = current?.Run(newDir, newEnemySpeed, newIsGrounded, newPlayerContact, newEnemyContact, newPlayerSeen);

        if (next != null)
        {
            newDir = current.enemyDir;
            newSpeed = current.enemySpeed;
            newIsGrounded = current.isGrounded;
            newPlayerContact = current.isPlayerContact;
            newEnemyContact = current.isEnemyContact;
            newPlayerSeen = current.isPlayerSeen;
            current = next;
        }

    }

    public BeeState getCurrentState()
    {
        return current;
    }

    public string CurrentStateAsString
    {
        get
        {
            switch (current)
            {
                case BeeSpawnState:
                    return "Spawning";
                case BeeIdleState:
                    return "Idling";
                case BeePursueState:
                    return "Pursuing";
                case BeeStingState:
                    return "oooh it stiiings";
                case BeeDespawnState:
                    return "Despawning";
            }
            return "Null";
        }
    }

    //triggers for the player having contact with the enemy
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player in contact with Bee");
            newPlayerContact = true;
        }

        if (other.CompareTag("Enemy"))
        {
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
            newEnemyContact = false;
        }
    }
} */