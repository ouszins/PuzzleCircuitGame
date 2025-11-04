using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class CircuitState : State
{

    public string TargetCircuitTag = "Sensor"; // Tag of the circuit to interact with
    private Transform TargetCircuit;
    public float moveSpeed = 5f; // Speed of movement towards the circuit
    public float stopDistance = 1f; // Distance to stop from the circuit
    public float heightOffGround = 1.5f; // Height off the ground to maintain
    public float bufferDistance = 0.5f; // Additional buffer distance to prevent overshooting


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
        Vector3 direction = (TargetCircuit.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, TargetCircuit.position);

        if (distance > stopDistance + bufferDistance)
        {
            // Move towards the circuit
            transform.position += direction * moveSpeed * Time.deltaTime;
            transform.LookAt(TargetCircuit); // Face the circuit while moving
        }
        else
        {
            // Interact with the circuit (e.g., complete it)
            Debug.Log($"{name}: Interacted with circuit '{TargetCircuitTag}'.");
            TargetCircuit = null; // Reset target 
            // Transition to the next state
            return nextState;
        }
 

        transform.position = new Vector3(transform.position.x, heightOffGround, transform.position.z); // Maintain height off the ground

        return this; // Continue in the current state
    }
    private void OnDrawGizmosSelected()
    {
        if (!string.IsNullOrEmpty(TargetCircuitTag))
        {
            // Find all active objects with the tag
            GameObject[] targets = GameObject.FindGameObjectsWithTag(TargetCircuitTag);
            if (targets != null && targets.Length > 0)
            {
                Gizmos.color = Color.red; // Color for stop distance
                foreach (GameObject target in targets)
                {
                    if (target != null)
                    {
                        Gizmos.DrawWireSphere(target.transform.position, stopDistance);
                    }
                }
            }
        }
    }
}
