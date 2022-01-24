using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    GameObject playerObject;

    public GameObject[] waypoints;
    int currentWaypoint = 0;
    public float toWaypointSpeed;
    float waypointRadius = 1;

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(waypoints[currentWaypoint].transform.position, transform.position) < waypointRadius)
        {
            currentWaypoint++;
            if(currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime*toWaypointSpeed);
    }

}
