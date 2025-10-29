using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CircuitSensor : MonoBehaviour
{
    public bool isConnected = false;

    private void OnTriggerEnter(Collider other)
    {
        //This checks if the Sensor is interacting to another sensor
        if (other.CompareTag("Sensor"))
        {
            Debug.Log($"{name} connected to {other.name}");
            isConnected = true;

            //Telling the parent to change colour (as debug or as an interaction)
            transform.parent.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if it is not touching another sensor it changes the parent colour to a different one, debug/interaction purposes
        if (other.CompareTag("Sensor"))
        {
            Debug.Log($"{name} disconnected from {other.name}");
            isConnected = false;

            transform.parent.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    
    }
