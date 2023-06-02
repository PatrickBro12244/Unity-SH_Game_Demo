using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    public CharacterMovement script;
    public InventoryOpen Open;
    public UseItem2 script2;
    public UseMicrowave script21;
    public OpenDoor2 script22;
    public Pickup script3;
    public Pickup script4;
    public Pickup script5;
    public Pickup script6;
    public Pickup script7;
    public Pickup script8;
    public Pickup script9;
    public Pickup script10;

    public Image img1;
    public Image img2;
    public Image img21;
    public Image img3;  
    public Image img4;
    public Image img5;
    public Image img6;
    public Image img7;
    public Image img8;

     public GameObject Item1Desc;
    public GameObject Item2Desc;
    public GameObject Item21Desc;
    public GameObject Item3Desc;
    public GameObject Item4Desc;
    public GameObject Item5Desc;
    public GameObject Item6Desc;
    public GameObject Item7Desc;
    public GameObject Item8Desc;
    public bool melted = false;
    
    // Start is called before the first frame update
   
 
    void Start()
    {
        img1.enabled = false;
        Item1Desc.SetActive(false);
        img2.enabled = false;
        Item2Desc.SetActive(false);
        img21.enabled = false;
        Item21Desc.SetActive(false);
        img3.enabled = false;
        Item3Desc.SetActive(false);
        img4.enabled = false;
        Item4Desc.SetActive(false);
        img5.enabled = false;
        Item5Desc.SetActive(false);
        img6.enabled = false;
        Item6Desc.SetActive(false);
        img7.enabled = false;
        Item7Desc.SetActive(false);
        img8.enabled = false;
        Item8Desc.SetActive(false);










    }   

    // Update is called once per frame
    void Update()
    {

        if (script3.pickup1)
        {
            img1.enabled = true;
        }
        if (script4.pickup2)
        {
            img2.enabled = true;
        }
        if (script5.pickup2)
        {
            img2.enabled = false;
            img21.enabled = true;
            melted = true;
        }
    }



    public void Item1Selected()
    {
        if (img1.enabled)
        {
            Item1Desc.SetActive(true);
            script.ItemCode = 1;
            Item2Desc.SetActive(false);
            Item21Desc.SetActive(false);
            Item3Desc.SetActive(false);
            Item4Desc.SetActive(false);
            Item5Desc.SetActive(false);
            Item6Desc.SetActive(false);
            Item7Desc.SetActive(false);
            Item8Desc.SetActive(false);
        }

    }

    public void Item2Selected()
    {
        if (img2.enabled)
        {
            Item2Desc.SetActive(true);
            script.ItemCode = 2;
            Item1Desc.SetActive(false);
            Item3Desc.SetActive(false);
            Item4Desc.SetActive(false);
            Item5Desc.SetActive(false);
            Item6Desc.SetActive(false);
            Item7Desc.SetActive(false);
            Item8Desc.SetActive(false);
        }
        else if(img21.enabled)
        {
            Item21Desc.SetActive(true);
            script.ItemCode = 21;
            Item1Desc.SetActive(false);
            Item2Desc.SetActive(false);
            Item3Desc.SetActive(false);
            Item4Desc.SetActive(false);
            Item5Desc.SetActive(false);
            Item6Desc.SetActive(false);
            Item7Desc.SetActive(false);
            Item8Desc.SetActive(false);

        }
    }
    public void Use()
    {
        if (script2.inside)
        {
            script.usedItem = true;
            Open.Resume();
        } 
        else if (script21.inside)
        {
            script.usedItem = true;
            Open.Resume();
        }
        else if (script22.inside)
        {
            script.usedItem = true;
            Open.Resume();
        }
        else
        {
            script.usedItem = false;
        }

    }
    public void Cancel()
    {
        script.usedItem = false;
        Item1Desc.SetActive(false);
        Item2Desc.SetActive(false);
        Item21Desc.SetActive(false);
        Item3Desc.SetActive(false);
        Item4Desc.SetActive(false);
        Item5Desc.SetActive(false);
        Item6Desc.SetActive(false);
        Item7Desc.SetActive(false);
        Item8Desc.SetActive(false);
        
    }


}
