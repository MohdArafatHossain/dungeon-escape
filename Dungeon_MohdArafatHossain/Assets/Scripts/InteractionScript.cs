using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    public Transform PlayerBody;
    [Header("MaxDistance you can open or close the door.")]
    public float MaxDistance = 0.001f;
 
    private bool doorOpened = true;
    private bool treasureOpened = true;
    private  Animator anim;

    public bool didPress;

    GameObject doorLockedTextObject;
    public GameObject youGotKeyObject;
    GameObject doorUnlockedTextObject;

    public bool haveKey = false;

    void Awake()
    {
        doorLockedTextObject = GameObject.Find("DoorLockedText");
        doorLockedTextObject.SetActive(false);
        youGotKeyObject = GameObject.Find("YouGotKey");
        youGotKeyObject.SetActive(false);
        doorUnlockedTextObject = GameObject.Find("DoorUnlockedText");
        doorUnlockedTextObject.SetActive(false);
    }
 
 
 
    void Update()
    {
        //This will tell if the player press E on the Keyboard. P.S. You can change the key if you want.
        if (Input.GetKeyDown(KeyCode.E))
        {
            didPress = true;
            //Pressed();
        }
    }

    void FixedUpdate()
    {
        if(didPress)
        {
            Pressed();
            didPress = false;
        }
    }
 
    void Pressed()
    {
        //This will name the Raycasthit and came information of which object the raycast hit.
        RaycastHit interactableObject;
 
        if (Physics.Raycast(PlayerBody.transform.position, PlayerBody.transform.forward, out interactableObject, MaxDistance))
        {
 
            // if raycast hits, then it checks if it hit an object with the tag Door.
            if (interactableObject.transform.tag == "Door")
            {
 
                //This line will get the Animator from  Parent of the door that was hit by the raycast.
                anim = interactableObject.transform.GetComponentInParent<Animator>();
 
                //This will set the bool the opposite of what it is.
                doorOpened = !doorOpened;
 
                //This line will set the bool true so it will play the animation.
                anim.SetBool("IsDoorOpened", !doorOpened);

                //This will set the bool the opposite of what it is.
                //doorOpened = !doorOpened;
            }

            else if (interactableObject.transform.tag == "Tag_Treasure")
            {
                //Debug.Log("Next to treasure chest!");
 
                //This line will get the Animator from  Parent of the door that was hit by the raycast.
                anim = interactableObject.transform.GetComponentInParent<Animator>();
 
                //This will set the bool the opposite of what it is.
                treasureOpened = !treasureOpened;
 
                //This line will set the bool true so it will play the animation.
                anim.SetBool("IsTreasureOpened", !treasureOpened);

                //This will set the bool the opposite of what it is.
                treasureOpened = !treasureOpened;
            }

            else if (interactableObject.transform.tag == "LockedDoor" && haveKey == false)
            {
                //doorLockedTextObject.SetActive(true);
                StartCoroutine(ShowLockedMessage(2));
            }

            else if(interactableObject.transform.tag == "LockedDoor" && haveKey == true)
            {
                StartCoroutine(ShowUnlockedMessage(2));

                //This line will get the Animator from  Parent of the door that was hit by the raycast.
                anim = interactableObject.transform.GetComponentInParent<Animator>();
 
                //This will set the bool the opposite of what it is.
                doorOpened = !doorOpened;
 
                //This line will set the bool true so it will play the animation.
                anim.SetBool("IsDoorOpened", !doorOpened);
            }
        }
    }

    IEnumerator ShowLockedMessage (float delay)
    {
        doorLockedTextObject.SetActive(true);
        yield return new WaitForSeconds(delay);
        doorLockedTextObject.SetActive(false);
    }

    IEnumerator ShowUnlockedMessage(float delay)
    {
        doorUnlockedTextObject.SetActive(true);
        yield return new WaitForSeconds(delay);
        doorUnlockedTextObject.SetActive(false);
    }

    
}
