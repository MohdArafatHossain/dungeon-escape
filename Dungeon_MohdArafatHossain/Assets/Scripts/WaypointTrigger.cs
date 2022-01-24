using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointTrigger : MonoBehaviour
{
    GameObject playerObject;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("I triggered something"); 
        playerObject = GameObject.Find("vMeleeController_PlayerBodyMesh");
        if(other.tag == "WaypointTag")
        {
            //Debug.Log("I'm on waypoint");
            playerObject.transform.parent = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerObject.transform.parent = null;
    }
}
