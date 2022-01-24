using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;

    public void StartGame()
    {
        StartCoroutine(LoadLevel(4));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadLevel(float timer)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(timer);
        transition.SetTrigger("Start");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        transition.SetTrigger("Start");
    }
}
