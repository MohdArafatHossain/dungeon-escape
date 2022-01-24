using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour
{

    Animator BackToMainMenuAnimator;
    GameObject SETextObject;
    GameObject SETextBackgroundObject;

    public void Awake()
    {
        SETextObject = GameObject.Find("SEText");
        SETextObject.SetActive(false);
        SETextBackgroundObject = GameObject.Find("SETextBackground");
        SETextBackgroundObject.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
            /*
            BackToMainMenuAnimator = GameObject.Find("Crossfade").GetComponent<Animator>();
            BackToMainMenuAnimator.SetTrigger("Start");
            Destroy(GameObject.Find("Inventory_CanvasUI"));
            Destroy(GameObject.Find("MainCamera"));
            Destroy(GameObject.Find("vGameController_Example Instance"));
            Destroy(GameObject.Find("vMeleeController_PlayerBodyMesh"));
            StartCoroutine(BackToMainMenu(4));
            */
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        BackToMainMenuAnimator = GameObject.Find("Crossfade").GetComponent<Animator>();
        BackToMainMenuAnimator.SetTrigger("Start");
        Destroy(GameObject.Find("Inventory_CanvasUI"));
        Destroy(GameObject.Find("MainCamera"));
        Destroy(GameObject.Find("vGameController_Example Instance"));
        Destroy(GameObject.Find("vMeleeController_PlayerBodyMesh"));
        StartCoroutine(EndTheGame(4));
    }


    IEnumerator EndTheGame(float timer)
    {
        SETextObject.SetActive(true);
        SETextBackgroundObject.SetActive(true);
        BackToMainMenuAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(timer);
        BackToMainMenuAnimator.SetTrigger("Start");
        SceneManager.LoadScene(0);
        BackToMainMenuAnimator.SetTrigger("Start");
    }

    /*
    IEnumerator BackToMainMenu(float timer)
    {
        BackToMainMenuAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(timer);
        BackToMainMenuAnimator.SetTrigger("Start");
        SceneManager.LoadScene(0);
        BackToMainMenuAnimator.SetTrigger("Start");
    }
    */
}
