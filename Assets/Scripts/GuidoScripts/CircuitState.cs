using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class CircuitFinder : GuidoState
{

    public string TargetCircuitTag = "Sensor"; // Tag of the circuit to interact with, will change in time
    private Transform TargetCircuit;


    public float MooveSpeed = 5f; // Speed of movement towards the circuit
    public float stopDistance = 0.5f; // Distance to stop from the circuit
    public float heightOffGround = 1.5f; // Height off the ground to maintain
    public float FollowRadius = 10f; // The distance he should be around the target object


    public float circuitTimeout = 5f; // Time to spend interacting with the circuit
    private float timer = 0f;

    public GuidoState nextState; // The state to transition to after completing the circuit interaction
    private void OnEnable()
    {
        IsFollowingCircuit = true; // Reset flag when state is enabled
        timer = 0f; // Reset timer when state is enabled
    }
    private void Start()
    {
        IsFollowingCircuit = true; // Start by following the circuit
    }
    public override GuidoState RunCurrentState()
    {

        if (TargetCircuit == null)
        {
            GameObject circuitObj = GameObject.FindGameObjectWithTag(TargetCircuitTag);
            if (circuitObj != null)
            {
                TargetCircuit = circuitObj.transform;
                timer = 0f; // Reset timer when circuit is found
                Debug.Log($"{name}: Found target circuit '{TargetCircuitTag}'.");


            }
            else
            {

                Debug.LogWarning($"{name}: Target circuit with tag '{TargetCircuitTag}' not found in scene.");
                // Exit if target circuit is not found
                timer += Time.deltaTime;
                if (timer >= circuitTimeout)
                {
                    Debug.LogWarning($"{name}: Timeout reached while searching for circuit '{TargetCircuitTag}'.");
                    return nextState; // Transition to next state on timeout
                }
                return this;

            }
        }

        float distance = Vector3.Distance(transform.position, TargetCircuit.position);
        Vector3 direction = (TargetCircuit.position - transform.position).normalized;

        if (distance <= FollowRadius && distance > stopDistance)
        {
            // Move towards the circuit
            transform.position += direction * MooveSpeed * Time.deltaTime;
            transform.LookAt(TargetCircuit); // Face the circuit while moving
        }
        else if (distance > FollowRadius)
        {
            // Circuit is out of follow radius, reset target to search again
            Debug.Log($"{name}: Circuit '{TargetCircuitTag}' is out of follow radius. Searching again.");
            TargetCircuit = null;
            IsFollowingCircuit = false; // Transition to next state if circuit is out of range
        }
        else if (distance <= stopDistance ) {

            //add interaction logic here later(Move the circuit a certain direction until a bool is true)

            timer += Time.deltaTime; // Increment timer while within stop distance
            if (timer >= circuitTimeout)
            {
                Debug.Log($"{name}: Completed interaction with circuit '{TargetCircuitTag}'. Transitioning to next state.");
                IsFollowingCircuit = false; // Transition to next state after timeout
            }
        }



        transform.position = new Vector3(transform.position.x, heightOffGround, transform.position.z); // Maintain height off the ground

        return this; // Continue in the current state
    }
    private void OnDrawGizmosSelected() //allows you to see the radius of each parameter in the editor
    {
        // Draw follow radius
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, FollowRadius);
        // Draw stop distance
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }
}



