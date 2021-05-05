using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WFCGUI : Editor
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnSceneGUI() 
    {
        Ray worldRay = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(worldRay, out hitInfo, Mathf.Infinity))
        {
            if (hitInfo.collider.gameObject != null)
            {
                Debug.Log(hitInfo.transform.name);
            }
        }
    }
}
