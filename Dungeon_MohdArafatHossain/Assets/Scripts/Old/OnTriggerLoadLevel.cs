using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTriggerLoadLevel : MonoBehaviour
{
    public GameObject guiObject;
    public string levelToLoad;
    private bool tryingToUseDoor;

    // Start is called before the first frame update
    void Start()
    {
        guiObject.SetActive(false);
    }

    void Update(){
        if(Input.GetButtonDown("UseDoor") && guiObject.activeInHierarchy == true)
        {
            tryingToUseDoor = true;
            
        }
    }

    //Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        guiObject.SetActive(true);
        if(tryingToUseDoor == true && guiObject.activeInHierarchy == true)
        {
            Debug.Log("Recognized you pressed E next to a door!");
            SceneManager.LoadScene(levelToLoad);
            //Application.LoadLevel(levelToLoad);
            tryingToUseDoor = false;
        }
    }

    void OnTriggerExit()
    {
        guiObject.SetActive(false);
    }
}
