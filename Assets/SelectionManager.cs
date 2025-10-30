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
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            var selection = hitInfo.transform;
            if (selection.CompareTag(SelectedTag)) 
            { 

            var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = highlighterMaterial;
            }

            currentSelection = selection;
            }
        }
    }
}
