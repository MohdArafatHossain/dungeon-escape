using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntrance : MonoBehaviour
{
    /*
    --------------
    START OF OLD CODE
    -----------------
    public string lastExitName;
    GameObject tpcObject;
    private static bool gameJustStarted = true;

    void Awake()
    {
        gameJustStarted = false;
    }

    // Start is called before the first frame update 
    void Start()
    {
        if(PlayerPrefs.GetString("LastExitName") == lastExitName)
        {
            //Debug.Log("Is the spawn portal position: " + transform.position);
            //PlayerScript.instance.transform.position = transform.position;
            //PlayerScript.instance.transform.eulerAngles = transform.eulerAngles;
            tpcObject = GameObject.Find("PlayerArmature");
            if(gameJustStarted == false)
            {
                StartCoroutine(DelayedPositionChange(0));
            } else {
                gameJustStarted = false;
            }
            
        }

        IEnumerator DelayedPositionChange(float duration)
        {
            yield return new WaitForSeconds(duration);
            tpcObject.transform.position = transform.position;
            tpcObject.transform.eulerAngles = transform.eulerAngles;
        }
      
    }
    
    ----------------
    END OF OLD CODE
    -----------------
    */
    
    /*
    public string lastExitName;
    private static bool gameJustStarted = true;

    void Awake()
    {
        gameJustStarted = true;
    }

    void Start()
    {
        if(PlayerPrefs.GetString("LastExitName") == lastExitName && gameJustStarted == false)
        {
            PlayerScript.instance.transform.position = transform.position;
            PlayerScript.instance.transform.eulerAngles = transform.eulerAngles;
        } else{
            gameJustStarted = false;
        }
    }
    */
    
}
