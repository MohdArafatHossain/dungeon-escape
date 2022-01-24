using System.Collections;
using UnityEngine;

public class ItemChest : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] Inventory inventory;
    [SerializeField] KeyCode itemPickupKeyCode = KeyCode.E;

    private bool isInRange;
    private bool isEmpty;

    private void Update()
    {
        if(isInRange && Input.GetKeyDown(itemPickupKeyCode))
        {
            if(!isEmpty)
            {
                //Debug.Log("I pressed E and got an item");
                inventory.AddItem(item);

                isEmpty = true;

                if(item.ItemName == "Key")
                {
                    Debug.Log("I have a key");
                    GameObject.Find("vMeleeController_PlayerBodyMesh").GetComponent<InteractionScript>().haveKey = true;
                    StartCoroutine(GotKeyMessage(2));
                }
            }
            
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            //Debug.Log("I am in Range of a chest to get item");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }

    }

    IEnumerator GotKeyMessage(float timer)
    {
        GameObject.Find("vMeleeController_PlayerBodyMesh").GetComponent<InteractionScript>().youGotKeyObject.SetActive(true);
        yield return new WaitForSeconds(timer);
        GameObject.Find("vMeleeController_PlayerBodyMesh").GetComponent<InteractionScript>().youGotKeyObject.SetActive(false);
    }
}
