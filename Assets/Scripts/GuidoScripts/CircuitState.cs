using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class CircuitState : State
{

    public string TargetCircuitTag = "Sensor"; // Tag of the circuit to interact with
    private Transform TargetCircuit;

    public float moveSpeed = 5f; // Speed of movement towards the circuit
    public float stopDistance = 0.5f; // Distance to stop from the circuit
    public float heightOffGround = 1.5f; // Height off the ground to maintain
    public float FollowRadius = 10f; // The distance he should be around the target object


    public float circuitTimeout = 5f; // Time to spend interacting with the circuit
    private float timer = 0f;

    public State nextState; // The state to transition to after completing the circuit interaction
    public override State RunCurrentState()
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
            transform.position += direction * moveSpeed * Time.deltaTime;
            transform.LookAt(TargetCircuit); // Face the circuit while moving
        }
        else if (distance > FollowRadius)
        {
            // Circuit is out of follow radius, reset target to search again
            Debug.Log($"{name}: Circuit '{TargetCircuitTag}' is out of follow radius. Searching again.");
            TargetCircuit = null;
            return nextState; // Transition to next state if circuit is out of range
        }



        transform.position = new Vector3(transform.position.x, heightOffGround, transform.position.z); // Maintain height off the ground

        return this; // Continue in the current state
    }
    private void OnDrawGizmosSelected()
    {
        // Draw follow radius
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, FollowRadius);
        // Draw stop distance
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }
}



