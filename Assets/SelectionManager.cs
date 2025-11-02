using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string SelectedTag = "Selectable";
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material highlighterMaterial;
    
    private Transform currentSelection;

    // Update is called once per frame
    void Update()
    {
        if(currentSelection != null)
        {
            var selectionRenderer = currentSelection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            currentSelection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);// put limit on ray length if needed

        float maxdistance = 6f;
        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxdistance))
        {
            var selection = hitInfo.transform; //turns the object a different color when selected
            if (selection.CompareTag(SelectedTag)) 
            { 

            var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = highlighterMaterial;
            }

            currentSelection = selection;
                if (Input.GetMouseButtonDown(0)) // 0 = left click held down
                {
                    selection.transform.position += new Vector3(0f, 10f, 0f); // moves the object up by 1 unit
                    selection.Rotate(0f, 90f, 0f); // rotates the object 90 degrees on the y axis

                    WaitForSeconds wait = new WaitForSeconds(0.2f); // waits for 0.5 seconds
                    selection.transform.position += new Vector3(0f, -10f, 0f); // moves the object up by 1 unit
                }
                if (Input.GetMouseButtonDown(1)) { // 1 = right click held down
                    selection.transform.position += new Vector3(0f, 10f, 0f); // moves the object down by 1 unit
                    selection.Rotate(0f, -90f, 0f); // rotates the object -90 degrees on the y axis
                    WaitForSeconds wait = new WaitForSeconds(0.2f); // waits for 0.5 seconds
                    selection.transform.position += new Vector3(0f, -10f, 0f); // moves the object up by 1 unit
                }
            }
        }
    }
}
