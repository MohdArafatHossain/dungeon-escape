using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivationPressurePlate : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Triggerd collision!!!");
        if(other.CompareTag("Player"))
        {
            //Debug.Log("Triggered player!!!");
            transform.GetComponent<Animator>().Play("TrapTriggerThorns_Anim");
        }
    }

    
}