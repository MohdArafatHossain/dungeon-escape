using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
	Image Filler;
	public Slider slider;
	public float health;
    public GameObject hpFiller;
    private Image hpBarImage;
    public GameObject damageIndicatorimage;
    public GameObject playerDiedNotification;
    public float youDiedTimer = 3f;
    public float hurtTimer = 2f;
    float startTime;

	// Use this for initialization
	void Start () {
		hpFiller = GameObject.FindGameObjectWithTag("Tag_PlayerHP");
        hpBarImage = hpFiller.gameObject.GetComponent<Image>();
		health = 1f;
		damageIndicatorimage.SetActive(false);
        playerDiedNotification.SetActive(false);
		//Filler = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		hpBarImage.fillAmount = health;
	}

	void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.tag == "TrapNeedleDrop")
        {
            health = 0f;
            StartCoroutine(HurtFlash());
            StartCoroutine(PlayerDiedScreen());
            Invoke("RespawnAfterDeath", 3);
        }

        if(obj.gameObject.tag == "TrapSawBlade")
        {
            health-=0.10f;
            StartCoroutine(HurtFlash());
            if(health<=0f)
            {
                StartCoroutine(PlayerDiedScreen());
                Invoke("RespawnAfterDeath", 3);
            }
        }
    }

    void RespawnAfterDeath()
    {
            Destroy(GameObject.Find("ThirdPersonCharacter"));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator PlayerDiedScreen()
    {
        playerDiedNotification.SetActive(true);
        while(true)
        {
            yield return new WaitForSeconds(youDiedTimer);
            playerDiedNotification.SetActive(false);
        }
        
    }

    IEnumerator HurtFlash()
    {
        startTime = Time.time;
        damageIndicatorimage.SetActive(true);
        while(true)
        {
            yield return new WaitForSeconds(hurtTimer);
            if(Time.time - startTime > 1f)
            {
                damageIndicatorimage.SetActive(false);
                break;
            }
            
        }
    }
}
