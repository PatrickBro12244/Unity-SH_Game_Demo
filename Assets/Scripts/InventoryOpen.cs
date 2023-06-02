using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpen : MonoBehaviour
{
    //public Inventory script;
    //public CharacterMovement script2;
    public  bool ItemOpen = false;
    public Inventory script;
    public GameObject inventoryUI;
    public AudioSource inventoryOpen;
    public AudioSource inventoryClose;
    // Start is called before the first frame update
   
    void Start()
    {
        inventoryUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (ItemOpen)
            {
                Resume();
            }
            else
            {
                OpenInventory();
            }
        }

    }

    public void Resume()
    {
        
        inventoryUI.SetActive(false);
        Time.timeScale = 1f;
        ItemOpen = false;
        inventoryClose.Play();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        script.Item1Desc.SetActive(false);
        script.Item2Desc.SetActive(false);
        script.Item3Desc.SetActive(false);
        script.Item4Desc.SetActive(false);
        script.Item5Desc.SetActive(false);
        script.Item6Desc.SetActive(false);
        script.Item7Desc.SetActive(false);
        script.Item8Desc.SetActive(false);
        //script.usedItem = false;
        //script2.ItemCode = 0;


    }
    public void OpenInventory()
    {
        inventoryUI.SetActive(true);
        Time.timeScale = 0f;
        ItemOpen = true;
        inventoryOpen.Play();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
